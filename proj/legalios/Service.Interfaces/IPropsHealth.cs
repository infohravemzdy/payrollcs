using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPropsHealth : IProps
    {
        Int32 MinMonthlyBasis { get; }
        Int32 MaxAnnualsBasis { get; }
        Int32 LimMonthlyState { get; }
        Int32 LimMonthlyDis50 { get; }
        decimal FactorCompound { get; }
        decimal FactorEmployee { get; }
        Int32 MarginIncomeEmp { get; }
        Int32 MarginIncomeAgr { get; }
        bool ValueEquals(IPropsHealth other);
        bool HasParticy(WorkHealthTerms term, Int32 incomeTerm, Int32 incomeSpec);
        Int32 RoundedCompoundPaym(Int32 basisResult);
        Int32 RoundedEmployeePaym(Int32 basisResult);
        Int32 RoundedAugmentEmployeePaym(Int32 basisGenerals, Int32 basisAugment);
        Int32 RoundedAugmentEmployerPaym(Int32 basisGenerals, Int32 baseEmployee, Int32 baseEmployer);
        Int32 RoundedEmployerPaym(Int32 basisResult);
        Tuple<Int32, Int32, IEnumerable<IParticyResult>> AnnualsBasisCut(IEnumerable<IParticyResult> incomeList, Int32 annuityBasis);
    }
}
