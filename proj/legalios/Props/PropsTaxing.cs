using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsTaxing : PropsBase, IPropsTaxing
    {
        public static IPropsTaxing Empty()
        {
            return new PropsTaxing(VERSION_ZERO);
        }
        public PropsTaxing(Int16 version) : base(version)
        {
            this.AllowancePayer = 0;
            this.AllowanceDisab1st = 0;
            this.AllowanceDisab2nd = 0;
            this.AllowanceDisab3rd = 0;
            this.AllowanceStudy = 0;
            this.AllowanceChild1st = 0;
            this.AllowanceChild2nd = 0;
            this.AllowanceChild3rd = 0;
            this.FactorAdvances = 0m;
            this.FactorWithhold = 0m;
            this.FactorSolidary = 0m;
            this.FactorTaxRate2 = 0m;
            this.MinAmountOfTaxBonus = 0;
            this.MaxAmountOfTaxBonus = 0;
            this.MarginIncomeOfTaxBonus = 0;
            this.MarginIncomeOfRounding = 0;
            this.MarginIncomeOfWithhold = 0;
            this.MarginIncomeOfSolidary = 0;
            this.MarginIncomeOfTaxRate2 = 0;
            this.MarginIncomeOfWthEmp = 0;
            this.MarginIncomeOfWthAgr = 0;
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
            Int32 marginIncomeOfWthEmp, Int32 marginIncomeOfWthAgr) : base(version)
        {
            this.AllowancePayer = allowancePayer;
            this.AllowanceDisab1st = allowanceDisab1st;
            this.AllowanceDisab2nd = allowanceDisab2nd;
            this.AllowanceDisab3rd = allowanceDisab3rd;
            this.AllowanceStudy = allowanceStudy;
            this.AllowanceChild1st = allowanceChild1st;
            this.AllowanceChild2nd = allowanceChild2nd;
            this.AllowanceChild3rd = allowanceChild3rd;
            this.FactorAdvances = factorAdvances;
            this.FactorWithhold = factorWithhold;
            this.FactorSolidary = factorSolidary;
            this.FactorTaxRate2 = factorTaxRate2;
            this.MinAmountOfTaxBonus = minAmountOfTaxBonus;
            this.MaxAmountOfTaxBonus = maxAmountOfTaxBonus;
            this.MarginIncomeOfTaxBonus = marginIncomeOfTaxBonus;
            this.MarginIncomeOfRounding = marginIncomeOfRounding;
            this.MarginIncomeOfWithhold = marginIncomeOfWithhold;
            this.MarginIncomeOfSolidary = marginIncomeOfSolidary;
            this.MarginIncomeOfTaxRate2 = marginIncomeOfTaxRate2;
            this.MarginIncomeOfWthEmp = marginIncomeOfWthEmp;
            this.MarginIncomeOfWthAgr = marginIncomeOfWthAgr;
        }

        public Int32 AllowancePayer { get; set; }
        public Int32 AllowanceDisab1st { get; set; }
        public Int32 AllowanceDisab2nd { get; set; }
        public Int32 AllowanceDisab3rd { get; set; }
        public Int32 AllowanceStudy { get; set; }
        public Int32 AllowanceChild1st { get; set; }
        public Int32 AllowanceChild2nd { get; set; }
        public Int32 AllowanceChild3rd { get; set; }
        public decimal FactorAdvances { get; set; }
        public decimal FactorWithhold { get; set; }
        public decimal FactorSolidary { get; set; }
        public decimal FactorTaxRate2 { get; set; }
        public Int32 MinAmountOfTaxBonus { get; set; }
        public Int32 MaxAmountOfTaxBonus { get; set; }
        public Int32 MarginIncomeOfTaxBonus { get; set; }
        public Int32 MarginIncomeOfRounding { get; set; }
        public Int32 MarginIncomeOfWithhold { get; set; }
        public Int32 MarginIncomeOfSolidary { get; set; }
        public Int32 MarginIncomeOfTaxRate2 { get; set; }
        public Int32 MarginIncomeOfWthEmp { get; set; }
        public Int32 MarginIncomeOfWthAgr { get; set; }

    }
}
