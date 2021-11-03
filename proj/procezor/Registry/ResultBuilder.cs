using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Registry.Factories;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IEnumerable<Result<ITermResult, ITermResultError>>>;
    class ResultBuilder : IResultBuilder
    {
        public VersionCode Version { get; private set; }
        public IPeriod PeriodInit { get; private set; }

        public IList<ArticleCode> ArticleOrder { get; private set; }
        public IDictionary<ArticleCode, IEnumerable<IArticleDefine>> ArticlePaths { get; private set; }
        private IEnumerable<IArticleSpec> articleModel { get; set; }
        private IEnumerable<IConceptSpec> conceptModel { get; set; }
        public ResultBuilder()
        {
            Version = VersionCode.New();
            PeriodInit = Period.New();

            articleModel = new List<IArticleSpec>();
            conceptModel = new List<IConceptSpec>();

            ArticleOrder = new List<ArticleCode>();
            ArticlePaths = new Dictionary<ArticleCode, IEnumerable<IArticleDefine>>();
        }
        public bool InitWithPeriod(VersionCode version, IPeriod period, IArticleSpecFactory articleFactory, IConceptSpecFactory conceptFactory)
        {
            Version = version;
            PeriodInit = period;

            articleModel = articleFactory.GetSpecList(period, Version);

            conceptModel = conceptFactory.GetSpecList(period, Version);

            var dependencyGraph = new DependencyGraph();

            (ArticleOrder, ArticlePaths) = dependencyGraph.InitGraphModel(articleModel, conceptModel);

            return true;
        }
        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IBundleProps ruleset, IEnumerable<ITermTarget> targets, IArticleDefine finDefs)
        {
            IEnumerable<ITermCalcul> calculTargets = BuildCalculsList(PeriodInit, targets, finDefs);

            IEnumerable<Result<ITermResult, ITermResultError>> calculResults = BuildResultsList(PeriodInit, ruleset, calculTargets);

            return calculResults;
        }
        private IEnumerable<ITermCalcul> BuildCalculsList(IPeriod period, IEnumerable<ITermTarget> targets, IArticleDefine finDefs)
        {
            IArticleDefine finDefine = new ArticleDefine(finDefs);

            IEnumerable<ITermTarget> targetsSpec = AddFinDefToTargets(period, targets.ToList(), finDefine);

            IEnumerable<ITermTarget> targetsStep = AddExternToTargets(period, targetsSpec);

            //ServiceDebugUtils?.LogArticleTargetsToFiles(targetList);

            IEnumerable<ITermCalcul> calculsList = AddTargetToCalculs(targetsStep);

            return calculsList;
        }
        private IEnumerable<Result<ITermResult, ITermResultError>> BuildResultsList(IPeriod period, IBundleProps ruleset, IEnumerable<ITermCalcul> calculs)
        { 
            IList<Result<ITermResult, ITermResultError>> resultsInit = new List<Result<ITermResult, ITermResultError>>();

            return calculs.Aggregate(resultsInit, (agr, x) => (MergeResults(agr, x.GetResults(period, ruleset, agr).ToArray()))).ToList();
        }
        private static IList<Result<ITermResult, ITermResultError>> MergeResults(IList<Result<ITermResult, ITermResultError>> results, params Result<ITermResult, ITermResultError>[] resultValues)
        {
            return results.Concat(resultValues).ToList();
        }
        private IEnumerable<ITermTarget> AddFinDefToTargets(IPeriod period, IEnumerable<ITermTarget> targets, IArticleDefine finDef)
        {
            return MergeItemPendings(period, targets, finDef);
        }
        private IEnumerable<ITermTarget> AddExternToTargets(IPeriod period, IEnumerable<ITermTarget> targets)
        {
            IEnumerable<ITermTarget> targetsInit = targets.ToList();

            var targetList = targets.Aggregate(targetsInit, 
                (agr, item) => (MergePendings(period, agr, item))).ToList();

            var targetSort = targetList.OrderBy((x) => (x), new TargetComparator(ArticleOrder)).ToList();

            return targetSort;
        }
        private IEnumerable<ITermCalcul> AddTargetToCalculs(IEnumerable<ITermTarget> targets)
        {
            return targets.Select((x) => (new TermCalcul(x, GetCalculFunc(conceptModel, x.Concept)))).ToList();
        }
        private IEnumerable<ITermTarget> MergePendings(IPeriod period, IEnumerable<ITermTarget> init, ITermTarget target)
        {
            IEnumerable<ITermTarget> resultList = init.ToList();

            var pendingsSpec = ArticlePaths.FirstOrDefault((x) => (x.Key == target.Article));
            var pendingsPath = pendingsSpec.Value;

            if (pendingsPath != null)
            {
                resultList = pendingsPath.Aggregate(resultList, (agr, def) => (MergeItemPendings(period, agr, def))).ToList();
            }

            return resultList;
        }
        private IEnumerable<ITermTarget> MergeItemPendings(IPeriod period, IEnumerable<ITermTarget> init, IArticleDefine articleDefs)
        {
            MonthCode monthCode = MonthCode.Get(period.Code);

            ContractCode contract = ContractCode.New();
            PositionCode position = PositionCode.New();

            IEnumerable<ITermTarget> resultList = init.ToList();

            var initTarget = init.FirstOrDefault((x) => (x.Article == articleDefs.Code));

            if (initTarget == null)
            {
                VariantCode variant = VariantCode.Get(1);

                var resultItem = new TermTarget(monthCode, contract, position, variant, articleDefs.Code, articleDefs.Role);

                resultList = resultList.Concat(new List<ITermTarget>() { resultItem }).ToList();
            }

            return resultList;
        }
        private ResultFunc GetCalculFunc(IEnumerable<IConceptSpec> conceptsModel, ConceptCode concept)
        {
            var conceptSpec = conceptsModel.FirstOrDefault((a) => (a.Code == concept));
            if (conceptSpec == null)
            {
                return NotFoundCalculFunc;
            }
            return conceptSpec.ResultDelegate;
        }
        private IEnumerable<Result<ITermResult, ITermResultError>> NotFoundCalculFunc(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            return new Result<ITermResult, ITermResultError>[] { NoResultFuncError.CreateResultError(period, target) };
        }
        private class TargetComparator : IComparer<ITermTarget>
        {
            private IList<ArticleCode> TopoOrders;
            public TargetComparator(IList<ArticleCode> topoOrders)
            {
                TopoOrders = topoOrders.ToList();
            }

            public int Compare(ITermTarget x, ITermTarget y)
            {
                var xIndex = TopoOrders.IndexOf(x.Article);

                var yIndex = TopoOrders.IndexOf(y.Article);

                if (xIndex == -1 && yIndex == -1)
                {
                    return 0;
                }

                if (xIndex == -1 && yIndex != -1)
                {
                    return -1;
                }

                if (xIndex != -1 && yIndex == -1)
                {
                    return 1;
                }

                return xIndex.CompareTo(yIndex);
            }
        }
    }
}