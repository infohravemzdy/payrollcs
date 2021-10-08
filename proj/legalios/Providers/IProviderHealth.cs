using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    public interface IProviderHealth : IPropsProvider<IPropsHealth>
    {
        Int32 MinMonthlyBasis(IPeriod period);
        Int32 MaxAnnualsBasis(IPeriod period);
        Int32 LimMonthlyState(IPeriod period);
        Int32 LimMonthlyDis50(IPeriod period);
        decimal FactorCompound(IPeriod period);
        decimal FactorEmployee(IPeriod period);
        Int32 MarginIncomeEmp(IPeriod period);
        Int32 MarginIncomeAgr(IPeriod period);
    }
}
