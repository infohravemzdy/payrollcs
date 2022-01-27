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
        decimal CoeffWithPartAndFullHours(decimal fullWorkHours, decimal partWorkHours);
        decimal PaymentWithMonthlyAndFullWeekAndFullAndWorkHours(decimal amountMonthly,
            Int32 fullWeekHours, Int32 partWeekHours,
            Int32 fullWorkHours, Int32 partWorkHours);
        decimal PaymentRoundUpWithMonthlyAndFullWeekAndFullAndWorkHours(decimal amountMonthly,
            Int32 fullWeekHours, Int32 partWeekHours,
            Int32 fullWorkHours, Int32 partWorkHours);
        decimal PaymentWithMonthlyAndCoeffAndFullAndWorkHours(decimal amountMonthly, 
            decimal monthlyCoeff, Int32 fullWorkHours, Int32 partWorkHours);
        decimal PaymentRoundUpWithMonthlyAndCoeffAndFullAndWorkHours(decimal amountMonthly, 
            decimal monthlyCoeff, Int32 fullWorkHours, Int32 partWorkHours);
        decimal PaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly,
            decimal monthlyCoeff, decimal workingCoeff);
        decimal PaymentRoundUpWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly,
            decimal monthlyCoeff, decimal workingCoeff);
        decimal RelativeAmountWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal RelativeTariffWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal RelativePaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal ReverzedAmountWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal ReverzedTariffWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal ReverzedPaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, 
            decimal monthlyCoeff, decimal workingCoeff);
        decimal PaymentWithTariffAndHours(decimal tariffHourly, decimal workingsHours);
        decimal PaymentRoundUpWithTariffAndHours(decimal tariffHourly, decimal workingsHours);
        decimal TariffWithPaymentAndHours(decimal amountHourly, decimal workingsHours);
        decimal PaymentWithAmountFixed(decimal amountFixed);
        decimal PaymentRoundUpWithAmountFixed(decimal amountFixed);
        decimal HoursToHalfHoursUp(decimal hoursVakue);
        decimal HoursToQuartHoursUp(decimal hoursVakue);
        decimal HoursToHalfHoursDown(decimal hoursVakue);
        decimal HoursToQuartHoursDown(decimal hoursVakue);
        decimal HoursToHalfHoursNorm(decimal hoursVakue);
        decimal HoursToQuartHoursNorm(decimal hoursVakue);
        decimal MoneyToRoundDown(decimal moneyVakue);
        decimal MoneyToRoundUp(decimal moneyVakue);
        decimal MoneyToRoundNorm(decimal moneyVakue);
    }
}
