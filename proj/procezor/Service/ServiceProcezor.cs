using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Registry;
using HraveMzdy.Procezor.Registry.Factories;
using ResultMonad;

namespace HraveMzdy.Procezor.Service
{
    public abstract class ServiceProcezor<EA, EC> : IServiceProcezor<EA, EC>
        where EA : struct, IComparable where EC : struct, IComparable
    {
        public VersionCode Version { get; }
        public IArticleDefine FinDefs { get; }
        protected IArticleSpecFactory ArticleFactory { get; set; }
        protected IConceptSpecFactory ConceptFactory { get; set; }
        protected IResultBuilder<EA, EC> Builder { get; set; }
        public IList<ArticleCode> BuilderOrder { get { return Builder.ArticleOrder; } }
        public IDictionary<ArticleCode, IEnumerable<IArticleDefine>> BuilderPaths { get { return Builder.ArticlePaths; } }

        public ServiceProcezor(Int32 version, IArticleDefine finDefs)
        {
            this.Version = new VersionCode(version);

            this.FinDefs = finDefs;

            this.Builder = new ResultBuilder<EA, EC>();

            BuildFactories();
        }
        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IEnumerable<ITermTarget> targets)
        {
            IEnumerable<Result<ITermResult, ITermResultError>> results = new List<Result<ITermResult, ITermResultError>>();

            bool success = InitWithPeriod(period);

            if (success == false)
            {
                return (results);
            }
            if (Builder != null)
            {
                results = Builder.GetResults(targets, FinDefs);
            }
            return (results);
        }
        public bool InitWithPeriod(IPeriod period)
        {
            bool initResult = false;

            if (Builder != null)
            {
                initResult = true;
            }

            bool initBuilder = false;

            if (Builder != null)
            {
                initBuilder = (Builder.PeriodInit != period);
            }

            if (initBuilder && ArticleFactory != null && ConceptFactory != null) 
            {
                initResult = Builder.InitWithPeriod(Version, period, ArticleFactory, ConceptFactory);
            }

            return initResult;
        }
        public bool BuildFactories()
        {
            bool articleFactorySuccess = BuildArticleFactory();

            bool conceptFactorySuccess = BuildConceptFactory();

            return (articleFactorySuccess && conceptFactorySuccess);
        }
        public IArticleSpec GetArticleSpec(ArticleCode code, IPeriod period, VersionCode version)
        {
            if (ArticleFactory == null)
            {
                return null;
            }
            return ArticleFactory.GetSpec(code, period, version);
        }
        public IConceptSpec GetConceptSpec(ConceptCode code, IPeriod period, VersionCode version)
        {
            if (ConceptFactory == null)
            {
                return null;
            }
            return ConceptFactory.GetSpec(code, period, version);
        }
        protected abstract bool BuildArticleFactory();
        protected abstract bool BuildConceptFactory();

    }
}
