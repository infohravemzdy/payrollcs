using System;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    public interface ITermResult : ITermSymbol
    {
        ITermTarget Target { get; }
        ConceptCode Concept { get; }
        string ResultDescr { get; }
        Int32 ResultBasis { get; }
        Int32 ResultValue { get; }
        string ConceptDescr();
    }
}
