using System;
using HraveMzdy.Legalios.Interfaces;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPropsSalary : IProps
    {
        Int32 WorkingShiftWeek { get; }
        Int32 WorkingShiftTime { get; }
        Int32 MinMonthlyWage { get; }
        Int32 MinHourlyWage { get; }
    }
}
