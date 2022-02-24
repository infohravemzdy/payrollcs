using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public abstract class PropsHealthBase : PropsBase, IPropsHealth
    {
        public PropsHealthBase(Int16 version) : base(version)
        {
            this.MinMonthlyBasis = 0;
            this.MaxAnnualsBasis = 0;
            this.LimMonthlyState = 0;
            this.LimMonthlyDis50 = 0;
            this.FactorCompound = 0m;
            this.FactorEmployee = 0m;
            this.MarginIncomeEmp = 0;
            this.MarginIncomeAgr = 0;
        }
        public PropsHealthBase(VersionId version,
            Int32 minMonthlyBasis, Int32 maxAnnualsBasis,
            Int32 limMonthlyState, Int32 limMonthlyDis50,
            decimal factorCompound, decimal factorEmployee,
            Int32 marginIncomeEmp, Int32 marginIncomeAgr) : base(version)
        {
            this.MinMonthlyBasis = minMonthlyBasis;
            this.MaxAnnualsBasis = maxAnnualsBasis;
            this.LimMonthlyState = limMonthlyState;
            this.LimMonthlyDis50 = limMonthlyDis50;
            this.FactorCompound = factorCompound;
            this.FactorEmployee = factorEmployee;
            this.MarginIncomeEmp = marginIncomeEmp;
            this.MarginIncomeAgr = marginIncomeAgr;
        }
        public Int32 MinMonthlyBasis { get; set; }
        public Int32 MaxAnnualsBasis { get; set; }
        public Int32 LimMonthlyState { get; set; }
        public Int32 LimMonthlyDis50 { get; set; }
        public decimal FactorCompound { get; set; }
        public decimal FactorEmployee { get; set; }
        public Int32 MarginIncomeEmp { get; set; }
        public Int32 MarginIncomeAgr { get; set; }
        public bool ValueEquals(IPropsHealth other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.MinMonthlyBasis == other.MinMonthlyBasis &&
                    this.MaxAnnualsBasis == other.MaxAnnualsBasis &&
                    this.LimMonthlyState == other.LimMonthlyState &&
                    this.LimMonthlyDis50 == other.LimMonthlyDis50 &&
                    this.FactorCompound == other.FactorCompound &&
                    this.FactorEmployee == other.FactorEmployee &&
                    this.MarginIncomeEmp == other.MarginIncomeEmp &&
                    this.MarginIncomeAgr == other.MarginIncomeAgr);
        }
        public bool HasParticy(WorkHealthTerms term, Int32 incomeTerm, Int32 incomeSpec)
        {
            bool particySpec = true;
            if (HasTermExemptionParticy(term))
            {
                particySpec = false;
            }
            else if (HasIncomeBasedAgreementsParticy(term) && MarginIncomeAgr > 0)
            {
                particySpec = false;
                if (HasIncomeCumulatedParticy(term))
                {
                    if (incomeTerm >= MarginIncomeAgr)
                    {
                        particySpec = true;
                    }
                }
                else
                {
                    if (incomeSpec >= MarginIncomeAgr)
                    {
                        particySpec = true;
                    }
                }
            }
            else if (HasIncomeBasedEmploymentParticy(term) && MarginIncomeEmp > 0)
            {
                particySpec = false;
                if (HasIncomeCumulatedParticy(term))
                {
                    if (incomeTerm >= MarginIncomeEmp)
                    {
                        particySpec = true;
                    }
                }
                else
                {
                    if (incomeSpec >= MarginIncomeEmp)
                    {
                        particySpec = true;
                    }
                }
            }
            return particySpec;
        }
        protected abstract bool HasTermExemptionParticy(WorkHealthTerms term);
        protected abstract bool HasIncomeBasedEmploymentParticy(WorkHealthTerms term);
        protected abstract bool HasIncomeBasedAgreementsParticy(WorkHealthTerms term);
        protected abstract bool HasIncomeCumulatedParticy(WorkHealthTerms term);

        public decimal DecInsuranceRoundUp(decimal valueDec)
        {
            return OperationsRound.RoundUp(valueDec);
        }

        public Int32 IntInsuranceRoundUp(decimal valueDec)
        {
            return OperationsRound.RoundUp(valueDec);
        }
        public Int32 RoundedCompoundPaym(Int32 basisResult)
        {
            decimal factorCompound = OperationsDec.Divide(FactorCompound, 100);

            Int32 compoundPayment = IntInsuranceRoundUp(OperationsDec.Multiply(basisResult, factorCompound));
            return compoundPayment;
        }
        public Int32 RoundedEmployeePaym(Int32 basisResult)
        {
            decimal factorCompound = OperationsDec.Divide(FactorCompound, 100);
            Int32 employeePayment = IntInsuranceRoundUp(OperationsDec.MultiplyAndDivide(basisResult, factorCompound, FactorEmployee));
            return employeePayment;

        }
        public Int32 RoundedAugmentEmployeePaym(Int32 basisGenerals, Int32 basisAugment)
        {
            decimal factorCompound = OperationsDec.Divide(FactorCompound, 100);

            Int32 employeePayment = IntInsuranceRoundUp(
                OperationsDec.Multiply(basisAugment, factorCompound)
                + OperationsDec.MultiplyAndDivide(basisGenerals, factorCompound, FactorEmployee));
            return employeePayment;
        }

        public Int32 RoundedAugmentEmployerPaym(Int32 basisGenerals, Int32 baseEmployee, Int32 baseEmployer)
        {
            decimal factorCompound = OperationsDec.Divide(FactorCompound, 100);

            Int32 compoundBasis = baseEmployer + baseEmployee + basisGenerals;

            Int32 compoundPayment = IntInsuranceRoundUp(OperationsDec.Multiply(compoundBasis, factorCompound));
            Int32 employeePayment = IntInsuranceRoundUp(OperationsDec.Multiply(baseEmployee, factorCompound)
                + OperationsDec.MultiplyAndDivide(basisGenerals, factorCompound, FactorEmployee));
            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);

            return employerPayment;
        }

        public Int32 RoundedEmployerPaym(Int32 basisResult)
        {
            Int32 compoundPayment = RoundedCompoundPaym(basisResult);
            Int32 employeePayment = RoundedEmployeePaym(basisResult);

            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);
            return employerPayment;
        }

        public Tuple<Int32, Int32, IEnumerable<ParticyHealthResult>> AnnualsBasisCut(IEnumerable<ParticyHealthTarget> incomeList, Int32 annuityBasis)
        {
            Int32 annualyMaxim = this.MaxAnnualsBasis;
            Int32 annualsBasis = Math.Max(0, annualyMaxim - annuityBasis);
            var resultInit = new Tuple<Int32, Int32, IEnumerable<ParticyHealthResult>>(
                annualyMaxim, annualsBasis, Array.Empty<ParticyHealthResult>());

            var resultList = incomeList.Aggregate(resultInit,
                (agr, x) => {
                    Int32 cutAnnualsBasis = 0;
                    Int32 rawAnnualsBasis = x.TargetsBase;
                    Int32 remAnnualsBasis = agr.Item2;

                    if (x.ParticyCode != 0)
                    {
                        cutAnnualsBasis = rawAnnualsBasis;
                        if (agr.Item1 > 0)
                        {
                            var ovrAnnualsBasis = Math.Max(0, rawAnnualsBasis - agr.Item2);
                            cutAnnualsBasis = (rawAnnualsBasis - ovrAnnualsBasis);
                        }
                        remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));
                    }

                    ParticyHealthResult r = new ParticyHealthResult(x.ContractCode, x.SubjectType, x.InterestCode, x.SubjectTerm, x.ParticyCode, x.TargetsBase, Math.Max(0, cutAnnualsBasis));
                    return new Tuple<Int32, Int32, IEnumerable<ParticyHealthResult>>(
                        agr.Item1, remAnnualsBasis, agr.Item3.Concat(new ParticyHealthResult[] { r }).ToArray());
                });

            return resultList;
        }
    }
}
