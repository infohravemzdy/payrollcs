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
        public decimal PaymentFromAmount(decimal amountMonthly, Int32 fullworkHours, Int32 workingsHours)
        {
            Int32 totalHours = TotalHoursForPayment(fullworkHours, workingsHours);

            decimal payment = OperationsDec.MultiplyAndDivide(amountMonthly, totalHours, fullworkHours);

            return payment;
        }
        public decimal PaymentFromTariff(decimal tariffHourly, decimal workingsHours)
        {
            decimal totalHours = Math.Max(0m, workingsHours);

            decimal payment = OperationsDec.Multiply(totalHours, tariffHourly);

            return payment;
        }
        public decimal TariffFromPayment(decimal amountHourly, decimal workingsHours)
        {
            decimal totalHours = Math.Max(0m, workingsHours);

            decimal tariff = OperationsDec.Divide(amountHourly, totalHours);

            return tariff;
        }
        public decimal PaymentFromFixedAmount(decimal amountFixed)
        {
            decimal payment = amountFixed;

            return payment;
        }
        public decimal PartTariffWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, Int32 fullworkHours, Int32 workingsHours)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = PaymentFromAmount(amountFactor, fullworkHours, workingsHours);

            return DecRoundNorm(paymentValue);
        }
        public decimal PartTariffWithWorkingCoeff(decimal amountMonthly, decimal scheduleFactor, decimal workingsFactor)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = FactorizeValue(amountFactor, workingsFactor);

            return DecRoundNorm(paymentValue);
        }
        public decimal FullTariffWithWorkingCoeff(decimal amountMonthly, decimal scheduleFactor, decimal workingsFactor)
        {
            decimal amountFactor = DefactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = DefactorizeValue(amountFactor, workingsFactor);

            return DecRoundNorm(paymentValue);
        }
        public decimal MonthlyAmountWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, Int32 fullworkHours, Int32 workingsHours)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = PaymentFromAmount(amountFactor, fullworkHours, workingsHours);

            return DecRoundUp(paymentValue);
        }
        public decimal MonthlyAmountWithWorkingCoeff(decimal amountMonthly, decimal scheduleFactor, decimal workingsFactor)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, scheduleFactor);

            decimal paymentValue = FactorizeValue(amountFactor, workingsFactor);

            return DecRoundUp(paymentValue);
        }
        public decimal WorkingHoursCoeff(decimal fullworkHour, decimal workingsHours)
        {
            decimal coeffWorking = Math.Min(1.0m, OperationsDec.Divide(workingsHours, fullworkHour));

            return coeffWorking;
        }
        public decimal SalaryAmountScheduleWork(decimal amountMonthly,
            Int32 fullWeekHours, Int32 workWeekHours,
            Int32 fullworkHours, Int32 workingsHours)
        {
            decimal coeffSalary = WorkingHoursCoeff(workWeekHours, fullWeekHours); // 1.0m;

            decimal salaryValue = MonthlyAmountWithWorkingHours(amountMonthly, coeffSalary, fullworkHours, workingsHours);

            return salaryValue;
        }
        public decimal SalaryAmountScheduleCoeff(decimal amountMonthly, decimal coeffSalary,
            Int32 fullworkHours, Int32 workingsHours)
        {
            decimal salaryValue = MonthlyAmountWithWorkingHours(amountMonthly, coeffSalary, fullworkHours, workingsHours);

            return salaryValue;
        }
        public decimal SalaryTariffWorkHourCoeff(decimal amountMonthly, decimal coeffSalary, decimal coeffWorking)
        {
            decimal salaryValue = PartTariffWithWorkingCoeff(amountMonthly, coeffSalary, coeffWorking);

            return salaryValue;
        }
        public decimal ReverzTariffWorkHourCoeff(decimal amountMonthly, decimal coeffSalary, decimal coeffWorking)
        {
            decimal salaryValue = FullTariffWithWorkingCoeff(amountMonthly, coeffSalary, coeffWorking);

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
        public decimal SalaryAmountHourlyBasis(decimal amountHourly, decimal workingsHours)
        {
            decimal tariffValue = TariffFromPayment(amountHourly, workingsHours);

            return MoneyToRoundNorm(tariffValue);
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
        public decimal MoneyToRoundDown(decimal moneyVakue)
        {
            return DecRoundDown01(moneyVakue);
        }
        public decimal MoneyToRoundUp(decimal moneyVakue)
        {
            return DecRoundUp01(moneyVakue);
        }
        public decimal MoneyToRoundNorm(decimal moneyVakue)
        {
            return DecRoundNorm01(moneyVakue);
        }

        public decimal FactorizeValue(decimal baseVakue, decimal factor)
        {
            decimal result = OperationsDec.Multiply(baseVakue, factor);

            return result;
        }
        public decimal DefactorizeValue(decimal baseVakue, decimal factor)
        {
            decimal result = OperationsDec.Multiply(baseVakue, OperationsDec.Divide(1m, factor));

            return result;
        }
    }
}
