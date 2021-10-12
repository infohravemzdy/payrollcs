using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermTarget : ITermSymbol
    {
        ConceptCode Concept { get; }
        Int32 TargetBasis { get; }
        string TargetDescr { get; }
        IArticleDefine Defs();
        string ArticleEnumDescr<EA>() where EA : struct, Enum;
        string ConceptEnumDescr<EC>() where EC : struct, Enum;
        string ArticleDescr();
        string ConceptDescr();
    }
}
