using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Providers
{
    public interface IProviderSocial : IPropsProvider<IPropsSocial>
    {
        Int32 MaxAnnualsBasis(IPeriod period);
        decimal FactorEmployer(IPeriod period);
        decimal FactorEmployerHigher(IPeriod period);
        decimal FactorEmployee(IPeriod period);
        decimal FactorEmployeeGarant(IPeriod period);
        decimal FactorEmployeeReduce(IPeriod period);
        Int32 MarginIncomeEmp(IPeriod period);
        Int32 MarginIncomeAgr(IPeriod period);
    }
}
