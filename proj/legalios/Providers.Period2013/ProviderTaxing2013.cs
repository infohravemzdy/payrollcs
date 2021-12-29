using System;
using HraveMzdy.Legalios.Providers.Period2013;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderTaxing2013 : ProviderBase, IProviderTaxing
    {
        public ProviderTaxing2013() : base(HistoryConstTaxing2013.VERSION_CODE)
        {
        }

        public IPropsTaxing GetProps(IPeriod period)
        {
            return new PropsTaxing2010(Version,
                AllowancePayer(period),
                AllowanceDisab1st(period),
                AllowanceDisab2nd(period),
                AllowanceDisab3rd(period),
                AllowanceStudy(period),
                AllowanceChild1st(period),
                AllowanceChild2nd(period),
                AllowanceChild3rd(period),
                FactorAdvances(period),
                FactorWithhold(period),
                FactorSolidary(period),
                FactorTaxRate2(period),
                MinAmountOfTaxBonus(period),
                MaxAmountOfTaxBonus(period),
                MarginIncomeOfTaxBonus(period),
                MarginIncomeOfRounding(period),
                MarginIncomeOfWithhold(period),
                MarginIncomeOfSolidary(period),
                MarginIncomeOfTaxRate2(period),
                MarginIncomeOfWthEmp(period),
                MarginIncomeOfWthAgr(period));
        }

        public Int32 AllowancePayer(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_PAYER;
        }
        public Int32 AllowanceDisab1st(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_DISAB_1ST;
        }
        public Int32 AllowanceDisab2nd(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_DISAB_2ND;
        }
        public Int32 AllowanceDisab3rd(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_DISAB_3RD;
        }
        public Int32 AllowanceStudy(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_STUDY;
        }
        public Int32 AllowanceChild1st(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_CHILD_1ST;
        }
        public Int32 AllowanceChild2nd(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_CHILD_2ND;
        }
        public Int32 AllowanceChild3rd(IPeriod period)
        {
            return HistoryConstTaxing2013.ALLOWANCE_CHILD_3RD;
        }
        public decimal FactorAdvances(IPeriod period)
        {
            return HistoryConstTaxing2013.FACTOR_ADVANCES;
        }
        public decimal FactorWithhold(IPeriod period)
        {
            return HistoryConstTaxing2013.FACTOR_WITHHOLD;
        }
        public decimal FactorSolidary(IPeriod period)
        {
            return HistoryConstTaxing2013.FACTOR_SOLIDARY;
        }
        public decimal FactorTaxRate2(IPeriod period)
        {
            return HistoryConstTaxing2013.FACTOR_TAXRATE2;
        }
        public Int32 MinAmountOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2013.MIN_AMOUNT_OF_TAXBONUS;
        }
        public Int32 MaxAmountOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2013.MAX_AMOUNT_OF_TAXBONUS;
        }
        public Int32 MarginIncomeOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_TAXBONUS;
        }
        public Int32 MarginIncomeOfRounding(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_ROUNDING;
        }
        public Int32 MarginIncomeOfWithhold(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_WITHHOLD;
        }
        public Int32 MarginIncomeOfSolidary(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_SOLIDARY;
        }
        public Int32 MarginIncomeOfTaxRate2(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_TAXRATE2;
        }
        public Int32 MarginIncomeOfWthEmp(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_WHT_EMP;
        }
        public Int32 MarginIncomeOfWthAgr(IPeriod period)
        {
            return HistoryConstTaxing2013.MARGIN_INCOME_OF_WHT_AGR;
        }
    }
}
