using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermResult : ITermSymbol
    {
        ITermTarget Target { get; }
        IArticleSpec Spec { get; }
        ConceptCode Concept { get; }
        string ResultDescr { get; }
        Int32 ResultBasis { get; }
        Int32 ResultValue { get; }
        string ConceptDescr();
        string ResultMessage();
        Int32 AddResultBasis(Int32 basis);
        Int32 SetResultBasis(Int32 basis);
        Int32 AddResultValue(Int32 value);
        Int32 SetResultValue(Int32 value);
    }
}
