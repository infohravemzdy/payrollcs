using System;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Types;

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
        bool HasWithholdIncome(WorkTaxingTerms termOpt, 
            TaxDeclSignOption signOpt, TaxNoneSignOption noneOpt, Int32 incomeSum);
        Int32 BenefitAllowancePayer(TaxDeclBenfOption benefitOpts);
        Int32 BenefitAllowanceDisab(TaxDeclDisabOption benefitOpts);
        Int32 BenefitAllowanceStudy(TaxDeclBenfOption benefitOpts);
        Int32 BenefitAllowanceChild(TaxDeclBenfOption benefitOpts, Int32 benefitOrds, Int32 disabelOpts);
        Int32 BonusChildRaw(Int32 income, Int32 benefit, Int32 rebated);
        Int32 BonusChildFix(Int32 income, Int32 benefit, Int32 rebated);
        Int32 TaxableIncomeSupers(Int32 incomeResult, Int32 healthResult, Int32 socialResult);
        Int32 RoundedBaseAdvances(Int32 incomeResult, Int32 healthResult, Int32 socialResult);
        Int32 RoundedBaseSolidary(Int32 incomeResult);
        Int32 RoundedAdvancesPaym(Int32 supersResult, Int32 basisResult);
        Int32 RoundedSolidaryPaym(Int32 basisResult);
        Int32 RoundedBaseWithhold(Int32 incomeResult);
        Int32 RoundedWithholdPaym(Int32 supersResult, Int32 basisResult); 
   }
}
