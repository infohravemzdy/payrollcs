﻿using System;
using HraveMzdy.Legalios.Providers.Period2020;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderTaxing2020 : ProviderBase, IProviderTaxing
    {
        public ProviderTaxing2020() : base(HistoryConstTaxing2020.VERSION_CODE)
        {
        }

        public IPropsTaxing GetProps(IPeriod period)
        {
            return new PropsTaxing(Version,
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
                FactorSolitary(period),
                MinAmountOfTaxBonus(period),
                MaxAmountOfTaxBonus(period),
                MarginIncomeOfTaxBonus(period),
                MarginIncomeOfRounding(period),
                MarginIncomeOfWithhold(period),
                MarginIncomeOfSolitary(period),
                MarginIncomeOfWthEmp(period),
                MarginIncomeOfWthAgr(period));
        }

        public Int32 AllowancePayer(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_PAYER;
        }
        public Int32 AllowanceDisab1st(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_DISAB_1ST;
        }
        public Int32 AllowanceDisab2nd(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_DISAB_2ND;
        }
        public Int32 AllowanceDisab3rd(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_DISAB_3RD;
        }
        public Int32 AllowanceStudy(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_STUDY;
        }
        public Int32 AllowanceChild1st(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_CHILD_1ST;
        }
        public Int32 AllowanceChild2nd(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_CHILD_2ND;
        }
        public Int32 AllowanceChild3rd(IPeriod period)
        {
            return HistoryConstTaxing2020.ALLOWANCE_CHILD_3RD;
        }
        public decimal FactorAdvances(IPeriod period)
        {
            return HistoryConstTaxing2020.FACTOR_ADVANCES;
        }
        public decimal FactorWithhold(IPeriod period)
        {
            return HistoryConstTaxing2020.FACTOR_WITHHOLD;
        }
        public decimal FactorSolitary(IPeriod period)
        {
            return HistoryConstTaxing2020.FACTOR_SOLITARY;
        }
        public Int32 MinAmountOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2020.MIN_AMOUNT_OF_TAXBONUS;
        }
        public Int32 MaxAmountOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2020.MAX_AMOUNT_OF_TAXBONUS;
        }
        public Int32 MarginIncomeOfTaxBonus(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_TAXBONUS;
        }
        public Int32 MarginIncomeOfRounding(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_ROUNDING;
        }
        public Int32 MarginIncomeOfWithhold(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_WITHHOLD;
        }
        public Int32 MarginIncomeOfSolitary(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_SOLITARY;
        }
        public Int32 MarginIncomeOfWthEmp(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_WHT_EMP;
        }
        public Int32 MarginIncomeOfWthAgr(IPeriod period)
        {
            return HistoryConstTaxing2020.MARGIN_INCOME_OF_WHT_AGR;
        }
    }
}