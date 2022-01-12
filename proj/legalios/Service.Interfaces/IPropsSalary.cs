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
        decimal SalaryAmountScheduleWork(decimal amountMonthly,
            Int32 fullWeekHour, Int32 workWeekHours,
            Int32 fulltimeHour, Int32 workingsHours);
        decimal SalaryAmountScheduleCoeff(decimal amountMonthly, 
            decimal coeffSalary, Int32 fulltimeHour, Int32 workingsHours);
        decimal SalaryTariffWorkHourCoeff(decimal amountMonthly, 
            decimal coeffSalary, decimal coeffWorking);
        decimal SalaryAmountHourlyValue(decimal tariffHourly, decimal workingsHours);
        decimal SalaryAmountFixedValue(decimal amountFixed);
        decimal WorkingHoursCoeff(decimal fulltimeHour, decimal workingsHours);
        decimal FactorizeValue(decimal baseVakue, decimal factor);
        decimal HoursToHalfHoursUp(decimal hoursVakue);
        decimal HoursToQuartsHoursUp(decimal hoursVakue);
        decimal HoursToHalfHoursDown(decimal hoursVakue);
        decimal HoursToQuartsHoursDown(decimal hoursVakue);
        decimal HoursToHalfHoursNorm(decimal hoursVakue);
        decimal HoursToQuartsHoursNorm(decimal hoursVakue);
        Int32 RoundUp(decimal valueDec);
        Int32 RoundDown(decimal valueDec);
        Int32 RoundNorm(decimal valueDec);
    }
}
