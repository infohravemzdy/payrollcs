using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsTaxing2010 : PropsTaxingBase, IPropsTaxing
    {
        public static IPropsTaxing Empty()
        {
            return new PropsTaxing2010(VERSION_ZERO);
        }
        public PropsTaxing2010(Int16 version) : base(version)
        {
        }
        public PropsTaxing2010(VersionId version,
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
            // Tax income for advance from Year 2008 to Year 2013
            //*****************************************************************************
            // - withhold tax (non-signed declaration) and income is less than X CZK
            //*****************************************************************************
            bool withholdIncome = false;
            if (signOpt != TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                return withholdIncome;
            }
            if (noneOpt != TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
            {
                return withholdIncome;
            }
            if (MarginIncomeOfWithhold == 0 || incomeSum <= MarginIncomeOfWithhold)
            {
                withholdIncome = true;
            }
            return withholdIncome;
        }
        public override Int32 RoundedAdvancesPaym(Int32 supersResult, Int32 basisResult)
        {
            decimal factorAdvances = OperationsDec.Divide(FactorAdvances, 100);

            Int32 advanceTaxing = 0;
            if (basisResult <= MarginIncomeOfRounding)
            {
                advanceTaxing = IntTaxRoundUp(OperationsDec.Multiply(supersResult, factorAdvances));
            }
            else
            {
                advanceTaxing = IntTaxRoundUp(OperationsDec.Multiply(supersResult, factorAdvances));
            }

            return advanceTaxing;
        }
    }
}
