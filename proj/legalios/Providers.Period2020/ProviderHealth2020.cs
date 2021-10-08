using System;
using HraveMzdy.Legalios.Providers.Period2020;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderHealth2020 : ProviderBase, IProviderHealth
    {
        public ProviderHealth2020() : base(HistoryConstHealth2020.VERSION_CODE)
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
            return HistoryConstHealth2020.MIN_MONTHLY_BASIS;
        }

        public Int32 MaxAnnualsBasis(IPeriod period)
        {
            return HistoryConstHealth2020.MAX_ANNUALS_BASIS;
        }

        public Int32 LimMonthlyState(IPeriod period)
        {
            return HistoryConstHealth2020.LIM_MONTHLY_STATE;
        }

        public Int32 LimMonthlyDis50(IPeriod period)
        {
            if (IsPeriodGreaterOrEqualThan(period, 2020, 6))
            {
                return HistoryConstHealth2020var06.LIM_MONTHLY_DIS50;
            }
            return HistoryConstHealth2020.LIM_MONTHLY_DIS50;
        }

        public decimal FactorCompound(IPeriod period)
        {
            return HistoryConstHealth2020.FACTOR_COMPOUND;
        }

        public decimal FactorEmployee(IPeriod period)
        {
            return HistoryConstHealth2020.FACTOR_EMPLOYEE;
        }

        public Int32 MarginIncomeEmp(IPeriod period)
        {
            return HistoryConstHealth2020.MARGIN_INCOME_EMP;
        }
        public Int32 MarginIncomeAgr(IPeriod period)
        {
            return HistoryConstHealth2020.MARGIN_INCOME_AGR;
        }
    }
}
