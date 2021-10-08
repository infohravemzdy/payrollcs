using System;
using HraveMzdy.Legalios.Providers.Period2014;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderHealth2014 : ProviderBase, IProviderHealth
    {
        public ProviderHealth2014() : base(HistoryConstHealth2014.VERSION_CODE)
        {
        }

        public IPropsHealth GetProps(IPeriod period)
        {
            return new PropsHealth(Version,
                MinMonthlyBasis(period),
                MaxAnnualsBasis(period),
                LimMonthlyState(period),
                LimMonthlyDis50(period),
                FactorCompound(period),
                FactorEmployee(period),
                MarginIncomeEmp(period),
                MarginIncomeAgr(period));
        }

        public Int32 MinMonthlyBasis(IPeriod period)
        {
            return HistoryConstHealth2014.MIN_MONTHLY_BASIS;
        }

        public Int32 MaxAnnualsBasis(IPeriod period)
        {
            return HistoryConstHealth2014.MAX_ANNUALS_BASIS;
        }

        public Int32 LimMonthlyState(IPeriod period)
        {
            return HistoryConstHealth2014.LIM_MONTHLY_STATE;
        }

        public Int32 LimMonthlyDis50(IPeriod period)
        {
            if (IsPeriodGreaterOrEqualThan(period, 2014, 7))
            {
                return HistoryConstHealth2014var07.LIM_MONTHLY_DIS50;
            }
            return HistoryConstHealth2014.LIM_MONTHLY_DIS50;
        }

        public decimal FactorCompound(IPeriod period)
        {
            return HistoryConstHealth2014.FACTOR_COMPOUND;
        }

        public decimal FactorEmployee(IPeriod period)
        {
            return HistoryConstHealth2014.FACTOR_EMPLOYEE;
        }

        public Int32 MarginIncomeEmp(IPeriod period)
        {
            return HistoryConstHealth2014.MARGIN_INCOME_EMP;
        }
        public Int32 MarginIncomeAgr(IPeriod period)
        {
            return HistoryConstHealth2014.MARGIN_INCOME_AGR;
        }
    }
}
