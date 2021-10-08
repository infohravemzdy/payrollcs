using System;
using HraveMzdy.Legalios.Providers.Period2013;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderSalary2013 : ProviderBase, IProviderSalary
    {
        public ProviderSalary2013() : base(HistoryConstSalary2013.VERSION_CODE)
        {
        }

        public IPropsSalary GetProps(IPeriod period)
        {
            return new PropsSalary(Version,
                WorkingShiftWeek(period), WorkingShiftTime(period),
                MinMonthlyWage(period), MinHourlyWage(period));
        }

        public Int32 WorkingShiftWeek(IPeriod period)
        {
            return HistoryConstSalary2013.WORKING_SHIFT_WEEK;
        }
        public Int32 WorkingShiftTime(IPeriod period)
        {
            return HistoryConstSalary2013.WORKING_SHIFT_TIME;
        }
        public Int32 MinMonthlyWage(IPeriod period)
        {
            if (IsPeriodGreaterOrEqualThan(period, 2013, 8))
            {
                return HistoryConstSalary2013var08.MIN_MONTHLY_WAGE;
            }
            return HistoryConstSalary2013.MIN_MONTHLY_WAGE;
        }
        public Int32 MinHourlyWage(IPeriod period)
        {
            if (IsPeriodGreaterOrEqualThan(period, 2013, 8))
            {
                return HistoryConstSalary2013var08.MIN_HOURLY_WAGE;
            }
            return HistoryConstSalary2013.MIN_HOURLY_WAGE;
        }
    }
}
