using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Registry
{
    sealed record ArticleEdge(ArticleCode start, ArticleCode stops)
    {
        public static ArticleEdge New(ArticleCode start, ArticleCode stops) => new(start, stops);
    }
    class DependencyGraph
    {
        public DependencyGraph()
        {
        }
        public Tuple<IList<ArticleCode>, IDictionary<ArticleCode, IEnumerable<IArticleDefine>>> InitGraphModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleCode> vertModel = CreateVertModel(articlesModel);

            IEnumerable<ArticleEdge> edgeModel = CreateEdgeModel(articlesModel, conceptsModel);

            IEnumerable<ArticleEdge> depsModel = CreatePendModel(articlesModel, conceptsModel);

            var order = CreateTopoModel(vertModel, edgeModel);

            var paths = CreatePathModel(articlesModel, vertModel, depsModel, order);

            return new Tuple<IList<ArticleCode>, IDictionary<ArticleCode, IEnumerable<IArticleDefine>>>(order, paths);
        }
        private IEnumerable<ArticleCode> CreateVertModel(IEnumerable<IArticleSpec> articlesModel)
        {
            return articlesModel.Select((a) => (a.Code)).OrderBy((o) => (o)).ToList();
        }
        private IEnumerable<ArticleEdge> CreateEdgeModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleEdge> init = new HashSet<ArticleEdge>();

            var edgeComparer = Comparer<ArticleEdge>.Create(
                (x, y) => {
                    if (x.start == y.start)
                    {
                        return x.stops.CompareTo(y.stops);
                    }
                    return x.start.CompareTo(y.start);
                });

            return articlesModel.Aggregate(init, (agr, x) => MergeEdges(conceptsModel, agr, x))
                .OrderBy((o) => (o), edgeComparer);
        }
        private IEnumerable<ArticleEdge> CreatePendModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<IConceptSpec> conceptsModel)
        {
            IEnumerable<ArticleEdge> init = new HashSet<ArticleEdge>();

            var edgeComparer = Comparer<ArticleEdge>.Create(
                (x, y) => {
                    if (x.start == y.start)
                    {
                        return x.stops.CompareTo(y.stops);
                    }
                    return x.start.CompareTo(y.start);
                });

            return articlesModel.Aggregate(init, (agr, x) => MergePends(conceptsModel, agr, x))
                .OrderBy((o) => (o), edgeComparer);
        }
        private IList<ArticleCode> CreateTopoModel(IEnumerable<ArticleCode> vertModel, IEnumerable<ArticleEdge> edgeModel)
        {
            IList<ArticleCode> articlesOrder = new List<ArticleCode>();

            IDictionary<ArticleCode, Int32> degrees = vertModel.Select((x) => (x))
                .ToDictionary((k) => (k), (v) => (edgeModel).Count((e) => (e.stops == v)));

            Queue<ArticleCode> queues = new Queue<ArticleCode>(degrees.Where((x) => (x.Value == 0)).Select((x) => (x.Key)).OrderBy((o) => (o)));

            int index = 0;
            while (queues.Count != 0)
            {
                index++;
                var article = queues.Dequeue();
                articlesOrder.Add(article);
                IList<ArticleCode> paths = edgeModel
                    .Where((x) => (x.start == article)).Select((x) => (x.stops)).ToList();
                paths.ToList().ForEach((p) => {
                    degrees[p] -= 1;
                    if (degrees[p] == 0)
                    {
                        queues.Enqueue(p);
                    }
                });
            }
            if (index != vertModel.Count())
            {
                return new List<ArticleCode>();
            }
            return articlesOrder;
        }
        private IDictionary<ArticleCode, IEnumerable<IArticleDefine>> CreatePathModel(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleCode> vertModel, IEnumerable<ArticleEdge> edgeModel, IList<ArticleCode> vertOrder)
        {
            return vertModel.Select((x) => (x)).ToDictionary((k) => (k), (v) => (MergePaths(articlesModel, edgeModel, vertOrder, v)));
        }
        private IEnumerable<ArticleEdge> MergeEdges(IEnumerable<IConceptSpec> conceptsModel, IEnumerable<ArticleEdge> agr, IArticleSpec article)
        {
            IEnumerable<ArticleEdge> result = agr.ToHashSet();

            var concept = conceptsModel.FirstOrDefault((c) => (c.Code == article.Role));

            result = article?.Sums.Select((s) => ArticleEdge.New(article.Code, s)).Concat(result).ToHashSet();

            result = concept?.Path.Select((p) => ArticleEdge.New(p, article.Code)).Concat(result).ToHashSet();

            return result;
        }
        private IEnumerable<ArticleEdge> MergePends(IEnumerable<IConceptSpec> conceptsModel, IEnumerable<ArticleEdge> agr, IArticleSpec article)
        {
            IEnumerable<ArticleEdge> result = agr.ToHashSet();

            var concept = conceptsModel.FirstOrDefault((c) => (c.Code == article.Role));

            result = concept?.Path.Select((p) => ArticleEdge.New(p, article.Code)).Concat(result).ToHashSet();

            return result;
        }
        private IEnumerable<IArticleDefine> MergePaths(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleEdge> edgeModel, IList<ArticleCode> vertOrder, ArticleCode article)
        {
            IEnumerable<IArticleDefine> articleInit = edgeModel
                .Where((e) => (e.stops == article)).Select((e) => GetArticleDefs(e.start, articlesModel)).ToList();
            IEnumerable<IArticleDefine> articlePath = articleInit
                .Aggregate(articleInit, (agr, x) => MergeVert(articlesModel, edgeModel, agr, x));
            return articlePath.Distinct().OrderBy((x) => (x), new DefineComparator(vertOrder));
        }
        private IList<IArticleDefine> MergeVert(IEnumerable<IArticleSpec> articlesModel, IEnumerable<ArticleEdge> edgeModel, IEnumerable<IArticleDefine> agr, IArticleDefine x)
        {
            IEnumerable<IArticleDefine> resultInit = edgeModel.Where((e) => (e.stops == x.Code)).Select((e) => GetArticleDefs(e.start, articlesModel));
            IEnumerable<IArticleDefine> resultList = resultInit.Aggregate(resultInit, (agr, x) => MergeVert(articlesModel, edgeModel, agr, x));
            return agr.Concat(resultList).Concat(new[] { x }).ToList();
        }
        private static IArticleDefine GetArticleDefs(ArticleCode article, IEnumerable<IArticleSpec> articlesModel)
        {
            IArticleSpec articleSpec = articlesModel.FirstOrDefault((m) => (m.Code == article));
            if (articleSpec == null)
            {
                return new ArticleDefine();
            }
            return articleSpec.Defs();
        }
        private class DefineComparator : IComparer<IArticleDefine>
        {
            private IList<ArticleCode> TopoOrders;
            public DefineComparator(IList<ArticleCode> topoOrders)
            {
                TopoOrders = topoOrders.ToList();
            }

            public int Compare(IArticleDefine x, IArticleDefine y)
            {
                var xIndex = TopoOrders.IndexOf(x.Code);

                var yIndex = TopoOrders.IndexOf(y.Code);

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
