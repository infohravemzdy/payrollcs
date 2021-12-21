﻿using System;
using HraveMzdy.Legalios.Interfaces;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPropsTaxing : IProps
    {
        Int32 AllowancePayer { get; }
        Int32 AllowanceDisab1st { get; }
        Int32 AllowanceDisab2nd { get; }
        Int32 AllowanceDisab3rd { get; }
        Int32 AllowanceStudy { get; }
        Int32 AllowanceChild1st { get; }
        Int32 AllowanceChild2nd { get; }
        Int32 AllowanceChild3rd { get; }
        decimal FactorAdvances { get; }
        decimal FactorWithhold { get; }
        decimal FactorSolidary { get; }
        decimal FactorTaxRate2 { get; }
        Int32 MinAmountOfTaxBonus { get; }
        Int32 MaxAmountOfTaxBonus { get; }
        Int32 MarginIncomeOfTaxBonus { get; }
        Int32 MarginIncomeOfRounding { get; }
        Int32 MarginIncomeOfWithhold { get; }
        Int32 MarginIncomeOfSolidary { get; }
        Int32 MarginIncomeOfTaxRate2 { get; }
        Int32 MarginIncomeOfWthEmp { get; }
        Int32 MarginIncomeOfWthAgr { get; }
        bool ValueEquals(IPropsTaxing other);
    }
}
