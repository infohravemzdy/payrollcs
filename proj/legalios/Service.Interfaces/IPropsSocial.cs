using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPropsSocial : IProps
    {
        Int32 MaxAnnualsBasis { get; }
        decimal FactorEmployer { get; }
        decimal FactorEmployerHigher { get; }
        decimal FactorEmployee { get; }
        decimal FactorEmployeeGarant { get; }
        decimal FactorEmployeeReduce { get; }
        Int32 MarginIncomeEmp { get; }
        Int32 MarginIncomeAgr { get; }
        bool ValueEquals(IPropsSocial other);
        bool HasParticy(WorkSocialTerms term, Int32 incomeTerm, Int32 incomeSpec);
        Int32 RoundedEmployeePaym(Int32 basisResult);
        Int32 RoundedEmployerPaym(Int32 basisResult);
        Tuple<Int32, Int32> ResultOvercaps(Int32 baseSuma, Int32 overCaps);
        Tuple<Int32, Int32, IEnumerable<ParticySocialResult>> AnnualsBasisCut(IEnumerable<ParticySocialTarget> incomeList, Int32 annuityBasis);
    }
}
