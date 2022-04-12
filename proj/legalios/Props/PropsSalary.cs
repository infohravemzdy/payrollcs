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

        protected Int32 TotalHoursWithFullAndPartHours(Int32 fullWorkHours, Int32 partWorkHours)
        {
            Int32 totalsHours = Math.Max(0, partWorkHours);

            Int32 resultHours = Math.Min(fullWorkHours, totalsHours);

            return resultHours;
        }
        protected decimal DecPaymentWithMonthlyAndCoeffAndFullAndWorkHours(decimal amountMonthly, decimal monthlyCoeff, Int32 fullWorkHours, Int32 partWorkHours)
        {
            decimal coeffAmount = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal payment = DecPaymentWithMonthlyAndFullAndWorkHours(coeffAmount, fullWorkHours, partWorkHours);

            return payment;
        }
        protected decimal DecPaymentWithMonthlyAndFullAndWorkHours(decimal amountMonthly, Int32 fullWorkHours, Int32 partWorkHours)
        {
            Int32 paymWorkHours = TotalHoursWithFullAndPartHours(fullWorkHours, partWorkHours);

            decimal payment = OperationsDec.MultiplyAndDivide(amountMonthly, paymWorkHours, fullWorkHours);

            return payment;
        }
        protected decimal DecPaymentWithTariffAndUnits(decimal tariffPerUnit, decimal workingsUnits)
        {
            decimal totalHours = Math.Max(0m, workingsUnits);

            decimal payment = OperationsDec.Multiply(totalHours, tariffPerUnit);

            return payment;
        }
        protected decimal DecTariffWithPaymentAndUnits(decimal amountPerUnit, decimal workingsUnits)
        {
            decimal totalUnits = Math.Max(0m, workingsUnits);

            decimal tariff = OperationsDec.Divide(amountPerUnit, totalUnits);

            return tariff;
        }
        protected decimal DecPaymentWithAmountFixed(decimal amountFixed)
        {
            decimal payment = amountFixed;

            return payment;
        }
        public decimal CoeffWithPartAndFullHours(decimal fullWorkHours, decimal partWorkHours)
        {
            decimal coeffWorking = Math.Min(1.0m, OperationsDec.Divide(partWorkHours, fullWorkHours));

            return coeffWorking;
        }
        public decimal RelativeAmountWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal amountCoeffs = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal relativeAmount = FactorizeValue(amountCoeffs, workingCoeff);

            return relativeAmount;
        }
        public decimal ReverzedAmountWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal amountCoeffs = ReverzedFactorizeValue(amountMonthly, monthlyCoeff);

            decimal reverzedAmount = ReverzedFactorizeValue(amountCoeffs, workingCoeff);

            return reverzedAmount;
        }
        public decimal RelativeTariffWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal paymentValue = RelativeAmountWithMonthlyAndCoeffAndWorkCoeff(amountMonthly, monthlyCoeff, workingCoeff);

            return OperationsRound.DecRoundNorm01(paymentValue);
        }
        public decimal ReverzedTariffWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal paymentValue = ReverzedAmountWithMonthlyAndCoeffAndWorkCoeff(amountMonthly, monthlyCoeff, workingCoeff);

            return OperationsRound.DecRoundNorm01(paymentValue);
        }
        public decimal RelativePaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal paymentValue = RelativeAmountWithMonthlyAndCoeffAndWorkCoeff(amountMonthly, monthlyCoeff, workingCoeff);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal ReverzedPaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal paymentValue = ReverzedAmountWithMonthlyAndCoeffAndWorkCoeff(amountMonthly, monthlyCoeff, workingCoeff);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal PaymentWithAmountFixed(decimal amountFixed)
        {
            decimal paymentValue = DecPaymentWithAmountFixed(amountFixed);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal PaymentRoundUpWithAmountFixed(decimal amountFixed)
        {
            decimal paymentValue = DecPaymentWithAmountFixed(amountFixed);

            return OperationsRound.DecRoundUp(paymentValue);
        }
        public decimal PaymentWithTariffAndUnits(decimal tariffPerUnit, decimal workingsUnits)
        {
            decimal paymentValue = DecPaymentWithTariffAndUnits(tariffPerUnit, workingsUnits);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal PaymentRoundUpWithTariffAndUnits(decimal tariffPerUnit, decimal workingsUnits)
        {
            decimal paymentValue = DecPaymentWithTariffAndUnits(tariffPerUnit, workingsUnits);

            return OperationsRound.DecRoundUp(paymentValue);
        }
        public decimal PaymentRoundDownWithTariffAndUnits(decimal tariffPerUnit, decimal workingsUnits)
        {
            decimal paymentValue = DecPaymentWithTariffAndUnits(tariffPerUnit, workingsUnits);

            return OperationsRound.DecRoundDown(paymentValue);
        }
        public decimal TariffWithPaymentAndUnits(decimal amountPerUnit, decimal workingsUnits)
        {
            decimal tariffValue = DecTariffWithPaymentAndUnits(amountPerUnit, workingsUnits);

            return MoneyToRoundNorm(tariffValue);
        }

        public decimal PaymentWithMonthlyAndCoeffAndFullAndWorkHours(decimal amountMonthly, decimal monthlyCoeff, Int32 fullWorkHours, Int32 partWorkHours)
        {
            decimal amountCoeffs = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal paymentValue = DecPaymentWithMonthlyAndFullAndWorkHours(amountCoeffs, fullWorkHours, partWorkHours);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal PaymentRoundUpWithMonthlyAndCoeffAndFullAndWorkHours(decimal amountMonthly, decimal monthlyCoeff, Int32 fullworkHours, Int32 partWorkHours)
        {
            decimal amountCoeffs = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal paymentValue = DecPaymentWithMonthlyAndFullAndWorkHours(amountCoeffs, fullworkHours, partWorkHours);

            return OperationsRound.DecRoundUp(paymentValue);
        }
        public decimal PaymentWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal paymentValue = FactorizeValue(amountFactor, workingCoeff);

            return OperationsRound.DecRoundNorm(paymentValue);
        }
        public decimal PaymentRoundUpWithMonthlyAndCoeffAndWorkCoeff(decimal amountMonthly, decimal monthlyCoeff, decimal workingCoeff)
        {
            decimal amountFactor = FactorizeValue(amountMonthly, monthlyCoeff);

            decimal paymentValue = FactorizeValue(amountFactor, workingCoeff);

            return OperationsRound.DecRoundUp(paymentValue);
        }
        public decimal PaymentWithMonthlyAndFullWeekAndFullAndWorkHours(decimal amountMonthly,
            Int32 fullWeekHours, Int32 partWeekHours,
            Int32 fullWorkHours, Int32 partWorkHours)
        {
            decimal coeffSalary = CoeffWithPartAndFullHours(partWeekHours, fullWeekHours); // 1.0m;

            decimal salaryValue = PaymentWithMonthlyAndCoeffAndFullAndWorkHours(amountMonthly, coeffSalary, fullWorkHours, partWorkHours);

            return salaryValue;
        }
        public decimal PaymentRoundUpWithMonthlyAndFullWeekAndFullAndWorkHours(decimal amountMonthly,
            Int32 fullWeekHours, Int32 partWeekHours,
            Int32 fullWorkHours, Int32 partWorkHours)
        {
            decimal coeffSalary = CoeffWithPartAndFullHours(partWeekHours, fullWeekHours); // 1.0m;

            decimal salaryValue = PaymentRoundUpWithMonthlyAndCoeffAndFullAndWorkHours(amountMonthly, coeffSalary, fullWorkHours, partWorkHours);

            return salaryValue;
        }
        public decimal HoursToHalfHoursUp(decimal hoursVakue)
        {
            return OperationsRound.DecRoundUp50(hoursVakue);
        }
        public decimal HoursToQuartHoursUp(decimal hoursVakue)
        {
            return OperationsRound.DecRoundUp25(hoursVakue);
        }
        public decimal HoursToHalfHoursDown(decimal hoursVakue)
        {
            return OperationsRound.DecRoundDown50(hoursVakue);
        }
        public decimal HoursToQuartHoursDown(decimal hoursVakue)
        {
            return OperationsRound.DecRoundDown25(hoursVakue);
        }
        public decimal HoursToHalfHoursNorm(decimal hoursVakue)
        {
            return OperationsRound.DecRoundNorm50(hoursVakue);
        }
        public decimal HoursToQuartHoursNorm(decimal hoursVakue)
        {
            return OperationsRound.DecRoundNorm25(hoursVakue);
        }
        public decimal MoneyToRoundDown(decimal moneyValue)
        {
            return OperationsRound.DecRoundDown01(moneyValue);
        }
        public decimal MoneyToRoundUp(decimal moneyValue)
        {
            return OperationsRound.DecRoundUp01(moneyValue);
        }
        public decimal MoneyToRoundNorm(decimal moneyValue)
        {
            return OperationsRound.DecRoundNorm01(moneyValue);
        }

        public decimal FactorizeValue(decimal baseVakue, decimal factor)
        {
            decimal result = OperationsDec.Multiply(baseVakue, factor);

            return result;
        }
        public decimal ReverzedFactorizeValue(decimal baseVakue, decimal factor)
        {
            decimal result = OperationsDec.Multiply(baseVakue, OperationsDec.Divide(1m, factor));

            return result;
        }
    }
}
