using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    public interface IProviderTaxing : IPropsProvider<IPropsTaxing>
    {
        Int32 AllowancePayer(IPeriod period);
        Int32 AllowanceDisab1st(IPeriod period);
        Int32 AllowanceDisab2nd(IPeriod period);
        Int32 AllowanceDisab3rd(IPeriod period);
        Int32 AllowanceStudy(IPeriod period);
        Int32 AllowanceChild1st(IPeriod period);
        Int32 AllowanceChild2nd(IPeriod period);
        Int32 AllowanceChild3rd(IPeriod period);
        decimal FactorAdvances(IPeriod period);
        decimal FactorWithhold(IPeriod period);
        decimal FactorSolidary(IPeriod period);
        Int32 MinAmountOfTaxBonus(IPeriod period);
        Int32 MaxAmountOfTaxBonus(IPeriod period);
        Int32 MarginIncomeOfTaxBonus(IPeriod period);
        Int32 MarginIncomeOfRounding(IPeriod period);
        Int32 MarginIncomeOfWithhold(IPeriod period);
        Int32 MarginIncomeOfSolidary(IPeriod period);
        Int32 MarginIncomeOfWthEmp(IPeriod period);
        Int32 MarginIncomeOfWthAgr(IPeriod period);
    }
}
