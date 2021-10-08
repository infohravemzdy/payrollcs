using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    public interface IProviderSalary : IPropsProvider<IPropsSalary>
    {
        Int32 WorkingShiftWeek(IPeriod period);
        Int32 WorkingShiftTime(IPeriod period);
        Int32 MinMonthlyWage(IPeriod period);
        Int32 MinHourlyWage(IPeriod period);
    }
}
