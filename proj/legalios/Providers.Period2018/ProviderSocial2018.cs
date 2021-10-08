using System;
using HraveMzdy.Legalios.Providers.Period2018;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderSocial2018 : ProviderBase, IProviderSocial
    {
        public ProviderSocial2018() : base(HistoryConstSocial2018.VERSION_CODE)
        {
        }

        public IPropsSocial GetProps(IPeriod period)
        {
            return new PropsSocial(Version,
                MaxAnnualsBasis(period),
                FactorEmployer(period),
                FactorEmployerHigher(period),
                FactorEmployee(period),
                FactorEmployeeGarant(period),
                FactorEmployeeReduce(period),
                MarginIncomeEmp(period),
                MarginIncomeAgr(period));
        }

        public Int32 MaxAnnualsBasis(IPeriod period)
        {
            return HistoryConstSocial2018.MAX_ANNUALS_BASIS;
        }
        public decimal FactorEmployer(IPeriod period)
        {
            return HistoryConstSocial2018.FACTOR_EMPLOYER;
        }
        public decimal FactorEmployerHigher(IPeriod period)
        {
            return HistoryConstSocial2018.FACTOR_EMPLOYER_HIGHER;
        }
        public decimal FactorEmployee(IPeriod period)
        {
            return HistoryConstSocial2018.FACTOR_EMPLOYEE;
        }
        public decimal FactorEmployeeGarant(IPeriod period)
        {
            return HistoryConstSocial2018.FACTOR_EMPLOYEE_GARANT;
        }
        public decimal FactorEmployeeReduce(IPeriod period)
        {
            return HistoryConstSocial2018.FACTOR_EMPLOYEE_REDUCE;
        }
        public Int32 MarginIncomeEmp(IPeriod period)
        {
            return HistoryConstSocial2018.MARGIN_INCOME_EMP;
        }
        public Int32 MarginIncomeAgr(IPeriod period)
        {
            return HistoryConstSocial2018.MARGIN_INCOME_AGR;
        }
    }
}
