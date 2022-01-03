using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsTaxing : PropsTaxingBase, IPropsTaxing
    {
        public static IPropsTaxing Empty()
        {
            return new PropsTaxing(VERSION_ZERO);
        }
        public PropsTaxing(Int16 version) : base(version)
        {
        }
        public PropsTaxing(VersionId version,
            Int32 allowancePayer,
            Int32 allowanceDisab1st, Int32 allowanceDisab2nd, Int32 allowanceDisab3rd,
            Int32 allowanceStudy,
            Int32 allowanceChild1st, Int32 allowanceChild2nd, Int32 allowanceChild3rd,
            decimal factorAdvances, decimal factorWithhold,
            decimal factorSolidary, decimal factorTaxRate2,
            Int32 minAmountOfTaxBonus, Int32 maxAmountOfTaxBonus, Int32 marginIncomeOfTaxBonus,
            Int32 marginIncomeOfRounding, Int32 marginIncomeOfWithhold,
            Int32 marginIncomeOfSolidary, Int32 marginIncomeOfTaxRate2,
            Int32 marginIncomeOfWthEmp, Int32 marginIncomeOfWthAgr)
            : base(version, 
                allowancePayer, 
                allowanceDisab1st, allowanceDisab2nd, allowanceDisab3rd,
                allowanceStudy,
                allowanceChild1st, allowanceChild2nd, allowanceChild3rd,
                factorAdvances, factorWithhold, 
                factorSolidary, factorTaxRate2,
                minAmountOfTaxBonus, maxAmountOfTaxBonus, 
                marginIncomeOfTaxBonus,
                marginIncomeOfRounding, marginIncomeOfWithhold,
                marginIncomeOfSolidary, marginIncomeOfTaxRate2,
                marginIncomeOfWthEmp, marginIncomeOfWthAgr)
        { 
        }

        public override bool HasWithholdIncome(WorkTaxingTerms termOpt, TaxDeclSignOption signOpt, TaxNoneSignOption noneOpt, int incomeSum)
        {
            //*****************************************************************************
            // Tax income for advance from Year 2014 to Year 2017
            //*****************************************************************************
            // - withhold tax (non-signed declaration) and income
            // if (period.Year >= 2018)
            // -- income from DPP is less than X CZK
            // -- income from low-income employment is less than X CZK
            // -- income from statutory employment and non-resident is always withhold tax

            bool withholdIncome = false;
            if (signOpt != TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                return withholdIncome;
            }
            if (noneOpt != TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
            {
                return withholdIncome;
            }
            if (termOpt == WorkTaxingTerms.TAXING_TERM_AGREEM_TASK)
            {
                if (MarginIncomeOfWthAgr == 0 || incomeSum <= MarginIncomeOfWthAgr)
                {
                    if (incomeSum > 0)
                    {
                        withholdIncome = true;
                    }
                }
            }
            else if (termOpt == WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS)
            {
                if (MarginIncomeOfWthEmp == 0 || incomeSum <= MarginIncomeOfWthEmp)
                {
                    if (incomeSum > 0)
                    {
                        withholdIncome = true;
                    }
                }
            }
            else if (termOpt == WorkTaxingTerms.TAXING_TERM_STATUT_PART)
            {
                if (incomeSum > 0)
                {
                    withholdIncome = true;
                }
            }
            return withholdIncome;
        }
        public override Int32 RoundedAdvancesPaym(Int32 basisResult, Int32 foundResult)
        {
            decimal factorAdvances = OperationsDec.Divide(FactorAdvances, 100);
            decimal factorTaxRate2 = OperationsDec.Divide(FactorTaxRate2, 100);

            Int32 taxRate1Basis = basisResult;
            Int32 taxRate2Basis = 0;
            if (MarginIncomeOfTaxRate2 != 0)
            {
                taxRate1Basis = Math.Min(basisResult, MarginIncomeOfTaxRate2);
                taxRate2Basis = Math.Max(0, basisResult - MarginIncomeOfTaxRate2);
            }
            decimal taxRate1Taxing = 0;
            if (foundResult <= MarginIncomeOfRounding)
            {
                taxRate1Taxing = OperationsDec.Multiply(taxRate1Basis, factorAdvances);
            }
            else
            {
                taxRate1Taxing = OperationsDec.Multiply(taxRate1Basis, factorAdvances);
            }
            decimal taxRate2Taxing = 0;
            if (MarginIncomeOfTaxRate2 != 0)
            {
                taxRate2Taxing = OperationsDec.Multiply(taxRate2Basis, factorTaxRate2);
            }
            return IntTaxRoundUp(taxRate1Taxing + taxRate2Taxing);
        }
    }
}
