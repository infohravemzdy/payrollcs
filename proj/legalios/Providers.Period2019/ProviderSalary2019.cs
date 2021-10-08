using System;
using HraveMzdy.Legalios.Providers.Period2019;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderSalary2019 : ProviderBase, IProviderSalary
    {
        public ProviderSalary2019() : base(HistoryConstSalary2019.VERSION_CODE)
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
            return HistoryConstSalary2019.WORKING_SHIFT_WEEK;
        }
        public Int32 WorkingShiftTime(IPeriod period)
        {
            return HistoryConstSalary2019.WORKING_SHIFT_TIME;
        }
        public Int32 MinMonthlyWage(IPeriod period)
        {
            return HistoryConstSalary2019.MIN_MONTHLY_WAGE;
        }
        public Int32 MinHourlyWage(IPeriod period)
        {
            return HistoryConstSalary2019.MIN_HOURLY_WAGE;
        }
    }
}
