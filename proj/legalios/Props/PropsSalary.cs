using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsSalary : PropsBase, IPropsSalary
    {
        public static IPropsSalary Empty()
        {
            return new PropsSalary(VERSION_ZERO);
        }
        public PropsSalary(Int16 version) : base(version)
        {
            this.WorkingShiftWeek = 0;
            this.WorkingShiftTime = 0;
            this.MinMonthlyWage = 0;
            this.MinHourlyWage = 0;
        }
        public PropsSalary(VersionId version,
            Int32 workingShiftWeek, Int32 workingShiftTime,
            Int32 minMonthlyWage, Int32 minHourlyWage) : base(version)
        {
            this.WorkingShiftWeek = workingShiftWeek;
            this.WorkingShiftTime = workingShiftTime;
            this.MinMonthlyWage = minMonthlyWage;
            this.MinHourlyWage = minHourlyWage;
        }
        public Int32 WorkingShiftWeek { get; set; }
        public Int32 WorkingShiftTime { get; set; }
        public Int32 MinMonthlyWage { get; set; }
        public Int32 MinHourlyWage { get; set; }

        public bool ValueEquals(IPropsSalary other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.WorkingShiftWeek == other.WorkingShiftWeek &&
                    this.WorkingShiftTime == other.WorkingShiftTime &&
                    this.MinMonthlyWage == other.MinMonthlyWage &&
                    this.MinHourlyWage == other.MinHourlyWage);
        }

        public Int32 TotalHoursForPayment(Int32 scheduledHours, Int32 workingsHours)
        {
            Int32 totalsHours = Math.Max(0, workingsHours);

            Int32 resultHours = Math.Min(scheduledHours, totalsHours);

            return resultHours;
        }
        public decimal PaymentFromAmount(decimal amountMonthly, Int32 scheduledHours, Int32 workingsHours)
        {
            Int32 totalHours = TotalHoursForPayment(scheduledHours, workingsHours);

            decimal payment = OperationsDec.MultiplyAndDivide(totalHours, amountMonthly, scheduledHours);

            return payment;
        }
        public decimal PaymentFromTariff(decimal tariffHourly, decimal workingsHours)
        {
            decimal totalHours = Math.Max(0m, workingsHours);

            decimal payment = OperationsDec.Multiply(totalHours, tariffHourly);

            return payment;
        }
        public decimal PaymentFromFixedAmount(decimal amountFixed)
        {
            decimal payment = amountFixed;

            return payment;
        }
        public decimal TariffWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, int scheduledHours, int workingsHours)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = PaymentFromAmount(amountFactor, scheduledHours, workingsHours);

            return DecRoundNorm(paymentValue);
        }
        public decimal TariffWithWorkingCoeff(decimal amountMonthly, decimal scheduleFactor, decimal workingsFactor)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, workingsFactor);

            decimal paymentValue = FactorizeValue(amountFactor, workingsFactor);

            return DecRoundNorm(paymentValue);
        }
        public decimal MonthlyAmountWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, int scheduledHours, int workingsHours)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = PaymentFromAmount(amountFactor, scheduledHours, workingsHours);

            return DecRoundUp(paymentValue);
        }
        public decimal MonthlyAmountWithWorkingCoeff(decimal amountMonthly, decimal scheduleFactor, decimal workingsFactor)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, workingsFactor);

            decimal paymentValue = FactorizeValue(amountFactor, workingsFactor);

            return DecRoundUp(paymentValue);
        }
        public decimal WorkingHoursCoeff(decimal fulltimeHour, decimal workingsHours)
        {
            decimal coeffWorking = Math.Min(1.0m, OperationsDec.Divide(workingsHours, fulltimeHour));

            return coeffWorking;
        }
        public decimal SalaryAmountScheduleWork(decimal amountMonthly,
            Int32 fullWeekHour, Int32 workWeekHours,
            Int32 fulltimeHour, Int32 workingsHours)
        {
            decimal coeffSalary = WorkingHoursCoeff(workWeekHours, fullWeekHour); // 1.0m;

            decimal salaryValue = MonthlyAmountWithWorkingHours(amountMonthly, coeffSalary, fulltimeHour, workingsHours);

            return salaryValue;
        }
        public decimal SalaryAmountScheduleCoeff(decimal amountMonthly, decimal coeffSalary,
            Int32 fulltimeHour, Int32 workingsHours)
        {
            decimal salaryValue = MonthlyAmountWithWorkingHours(amountMonthly, coeffSalary, fulltimeHour, workingsHours);

            return salaryValue;
        }
        public decimal SalaryTariffWorkHourCoeff(decimal amountMonthly, decimal coeffSalary, decimal coeffWorking)
        {
            decimal salaryValue = TariffWithWorkingCoeff(amountMonthly, coeffSalary, coeffWorking);

            return salaryValue;
        }
        public decimal SalaryAmountFixedValue(decimal amountFixed)
        {
            decimal paymentValue = PaymentFromFixedAmount(amountFixed);

            return DecRoundUp(paymentValue);
        }
        public decimal SalaryAmountHourlyValue(decimal tariffHourly, decimal workingsHours)
        {
            decimal paymentValue = PaymentFromTariff(tariffHourly, workingsHours);

            return DecRoundUp(paymentValue);
        }
        public decimal HoursToHalfHoursUp(decimal hoursVakue)
        {
            return DecRoundUp50(hoursVakue);
        }
        public decimal HoursToQuartsHoursUp(decimal hoursVakue)
        {
            return DecRoundUp25(hoursVakue);
        }
        public decimal HoursToHalfHoursDown(decimal hoursVakue)
        {
            return DecRoundDown50(hoursVakue);
        }
        public decimal HoursToQuartsHoursDown(decimal hoursVakue)
        {
            return DecRoundDown25(hoursVakue);
        }
        public decimal HoursToHalfHoursNorm(decimal hoursVakue)
        {
            return DecRoundNorm50(hoursVakue);
        }
        public decimal HoursToQuartsHoursNorm(decimal hoursVakue)
        {
            return DecRoundNorm25(hoursVakue);
        }

        public decimal FactorizeValue(decimal baseVakue, decimal factor)
        {
            decimal result = OperationsDec.Multiply(baseVakue, factor);

            return result;
        }
    }
}
