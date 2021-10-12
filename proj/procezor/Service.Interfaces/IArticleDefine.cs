using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface IArticleDefine : ISpecDefine<ArticleCode>
    {
        ConceptCode Role { get; }
    }
}
