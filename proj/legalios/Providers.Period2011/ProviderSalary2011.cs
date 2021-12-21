using System;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Providers.Period2011;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderSalary2011 : ProviderBase, IProviderSalary
    {
        public ProviderSalary2011() : base(HistoryConstSalary2011.VERSION_CODE)
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
            return HistoryConstSalary2011.WORKING_SHIFT_WEEK;
        }
        public Int32 WorkingShiftTime(IPeriod period)
        {
            return HistoryConstSalary2011.WORKING_SHIFT_TIME;
        }
        public Int32 MinMonthlyWage(IPeriod period)
        {
            return HistoryConstSalary2011.MIN_MONTHLY_WAGE;
        }
        public Int32 MinHourlyWage(IPeriod period)
        {
            return HistoryConstSalary2011.MIN_HOURLY_WAGE;
        }
    }
}
