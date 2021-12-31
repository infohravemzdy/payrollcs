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
        bool ValueEquals(IPropsSalary other);
        Decimal SalaryAmountScheduleWork(Decimal amountMonthly,
            Int32 fullWeekHour, Int32 workWeekHours,
            Int32 fulltimeHour, Int32 workingsHours);
        Decimal SalaryAmountFixedValue(Decimal amountFixed);
        Int32 RoundUp(decimal valueDec);
        Int32 RoundDown(decimal valueDec);
    }
}
