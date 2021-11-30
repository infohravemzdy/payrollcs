using HraveMzdy.Legalios.Service;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using Procezor.Payrolex.Registry.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.PayrolexTest.Examples
{
    public class ExampleParam
    {
        public bool salaryGen { get; set; }
        public Int32 salaryGenKc { get; set; }
        public bool agreemGen { get; set; }
        public Int32 agreemGenKc { get; set; }
        public bool salaryMaxBon { get; set; }
        public bool salaryMinZdr { get; set; }
        public bool salaryMinZdrPrev { get; set; }
        public Int32 salaryMinZdrKc { get; set; }
        public bool salaryMaxZdr { get; set; }
        public bool salaryMaxZdrPrev { get; set; }
        public Int32 salaryMaxZdrKc { get; set; }
        public bool salaryMaxSoc { get; set; }
        public bool salaryMaxSocPrev { get; set; }
        public Int32 salaryMaxSocKc { get; set; }
        public bool salarySolTax { get; set; }
        public bool salarySolTaxPrev { get; set; }
        public Int32 salarySolTaxKc { get; set; }
        public bool salaryNemUcast { get; set; }
        public bool salaryNemUcastPrev { get; set; }
        public Int32 salaryNemUcastKc { get; set; }
        public bool salaryZdrUcast { get; set; }
        public bool salaryZdrUcastPrev { get; set; }
        public bool salaryZdrUcastEmp { get; set; }
        public bool salaryZdrUcastEmpPrev { get; set; }
        public Int32 salaryZdrUcastKc { get; set; }
        public bool podepTax { get; set; }
        public bool podepTaxVal { get; set; }
        public bool srazDan { get; set; }
        public bool srazDanPrev { get; set; }
        public Int32 srazDanLimit { get; set; }
        public bool taxChild { get; set; }
        public bool taxChildNorm { get; set; }
        public bool taxChildZtpp { get; set; }
        public Int32 taxChildPor1 { get; set; }
        public Int32 taxChildPor2 { get; set; }
        public Int32 taxChildPor3 { get; set; }
        public bool taxDisab { get; set; }
        public bool taxDisabBen1 { get; set; }
        public bool taxDisabBen2 { get; set; }
        public bool taxDisabBen3 { get; set; }
        public bool taxStudy { get; set; }
        public bool taxStudyBen { get; set; }
        public bool conMinZdr { get; set; }
        public bool conMinZdrBen { get; set; }

        public ExampleParam()
        {
            salaryGen = false;
            salaryGenKc = 0;
            agreemGen = false;
            agreemGenKc = 0;
            salaryMaxBon = false;

            salaryMinZdr = false;
            salaryMinZdrPrev = false;
            salaryMinZdrKc = 0;
            salaryMaxZdr = false;
            salaryMaxZdrPrev = false;
            salaryMaxZdrKc = 0;
            salaryMaxSoc = false;
            salaryMaxSocPrev = false;
            salaryMaxSocKc = 0;
            salarySolTax = false;
            salarySolTaxPrev = false;
            salarySolTaxKc = 0;
            salaryNemUcast = false;
            salaryNemUcastPrev = false;
            salaryNemUcastKc = 0;
            salaryZdrUcast = false;
            salaryZdrUcastPrev = false;
            salaryZdrUcastEmp = false;
            salaryZdrUcastEmpPrev = false;
            salaryZdrUcastKc = 0;

            srazDan = false;
            srazDanPrev = false;
            srazDanLimit = 0;

            podepTax = false;
            podepTaxVal = false;

            taxChild = false;
            taxChildNorm = false;
            taxChildZtpp = false;
            taxChildPor1 = 0;
            taxChildPor2 = 0;
            taxChildPor3 = 0;

            taxDisab = false;
            taxDisabBen1 = false;
            taxDisabBen2 = false;
            taxDisabBen3 = false;

            taxStudy = false;
            taxStudyBen = false;
            conMinZdr = false;
            conMinZdrBen = false;
        }
    }
    public class SpecGeneratorParams
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string Number { get; set; }

        public WorkContractTerms contractType { get; set; }

        public Int32 scheduleWeek { get; set; }
        public Int32 salaryBasis { get; set; }
        public Int32 agreemBasis { get; set; }
        public bool socialPayer { get; set; }
        public bool healthPayer { get; set; }
        public bool healthMinim { get; set; }
        public bool socialEmper { get; set; }
        public bool healthEmper { get; set; }
        public bool penzisPayer { get; set; }
        public bool taxingPayer { get; set; }
        public bool taxDeclarat { get; set; }
        public bool taxBenPayer { get; set; }
        public bool taxBenDis01 { get; set; }
        public bool taxBenDis02 { get; set; }
        public bool taxBenDis03 { get; set; }
        public bool taxBenStudy { get; set; }

        public SpecGeneratorParams()    
        {
            contractType = WorkContractTerms.WORKTERM_EMPLOYMENT_1;
            scheduleWeek = 0;
            salaryBasis = 0;
            agreemBasis = 0;
            socialPayer = false;
            healthPayer = false;
            healthMinim = false;
            socialEmper = false;
            healthEmper = false;
            penzisPayer = false;
            taxingPayer = false;
            taxDeclarat = false;
            taxBenPayer = false;
            taxBenDis01 = false;
            taxBenDis02 = false;
            taxBenDis03 = false;
            taxBenStudy = false;
        }
    }
    public class SpecGeneratorItem
    {
        public string[] Description { get; set; }

        public WorkContractTerms contractType { get; set; }

        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> scheduleWeek { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> salaryBasis { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> agreemBasis { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> socialPayer { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> healthPayer { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> healthMinim { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> penzisPayer { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> socialEmper { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> healthEmper { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxingPayer { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxDeclarat { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenPayer { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis01 { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis02 { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis03 { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBebStudy { get; set; }
        public Func<IPeriod, IBundleProps, IBundleProps, ExampleParam, SpecGeneratorParams, ChildSpec[]> taxChildren { get; set; }

        public SpecGeneratorItem()    
        {
            contractType = WorkContractTerms.WORKTERM_EMPLOYMENT_1;
            Description = new string[0];
        }

        public ExampleSpec CreateExample(IPeriod period, IBundleProps ruleset, IBundleProps prevset, Int32 id, string name, string number, Int32 schedWeek, Int32 nonAtten, ExampleParam ex)
        { 
            SpecGeneratorParams param = new SpecGeneratorParams();
            param.Id = id;
            param.Name = name;
            param.Number = number;
            param.Description = this.Description.ToArray();

            param.contractType = this.contractType;
            param.scheduleWeek = this.scheduleWeek(period, ruleset, prevset, ex, param);
            param.salaryBasis = this.salaryBasis(period, ruleset, prevset, ex, param);
            param.agreemBasis = this.agreemBasis(period, ruleset, prevset, ex, param);
            param.socialPayer = this.socialPayer(period, ruleset, prevset, ex, param);
            param.healthPayer = this.healthPayer(period, ruleset, prevset, ex, param);
            param.healthMinim = this.healthMinim(period, ruleset, prevset, ex, param);
            param.socialEmper = this.socialEmper(period, ruleset, prevset, ex, param);
            param.healthEmper = this.healthEmper(period, ruleset, prevset, ex, param);
            param.penzisPayer = this.penzisPayer(period, ruleset, prevset, ex, param);
            param.taxingPayer = this.taxingPayer(period, ruleset, prevset, ex, param);
            param.taxDeclarat = this.taxDeclarat(period, ruleset, prevset, ex, param);
            param.taxBenPayer = this.taxBenPayer(period, ruleset, prevset, ex, param);
            param.taxBenDis01 = this.taxBenDis01(period, ruleset, prevset, ex, param);
            param.taxBenDis02 = this.taxBenDis02(period, ruleset, prevset, ex, param);
            param.taxBenDis03 = this.taxBenDis03(period, ruleset, prevset, ex, param);
            param.taxBenStudy = this.taxBebStudy(period, ruleset, prevset, ex, param);

            ExampleSpec spec = new ExampleSpec();
            spec.Id = param.Id;
            spec.Name = param.Name;
            spec.Number = param.Number;
            spec.Description = this.Description.ToArray();
            spec.Contracts = ContractSpec.One(1, "",
                param.scheduleWeek,
                nonAtten,
                param.salaryBasis,
                param.agreemBasis,
                param.healthPayer,
                param.healthMinim,
                param.socialPayer,
                param.healthEmper,
                param.socialEmper);
            spec.TaxPayer = param.taxingPayer;
            spec.TaxDeclaration = param.taxDeclarat;
            spec.TaxBenefitPayer = param.taxBenPayer;
            spec.TaxBenefitDisab1 = param.taxBenDis01;
            spec.TaxBenefitDisab2 = param.taxBenDis02;
            spec.TaxBenefitDisab3 = param.taxBenDis03;
            spec.TaxBenefitStudy = param.taxBenStudy;
            spec.TaxChildren = this.taxChildren(period, ruleset, prevset, ex, param);
            spec.InsPenzisPayer = param.penzisPayer;

            return spec;
        }
        public static Int32 DefScheduleWeek(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return 40; 
        }
        public static Int32 DefSalaryBasis(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (ex.agreemGen)
            {
                return 0;
            }
            if (ex.srazDan)
            {
                return ruleset.TaxingProps.MarginIncomeOfWithhold + ex.srazDanLimit;
            }
            if (ex.srazDanPrev)
            {
                return prevset.TaxingProps.MarginIncomeOfWithhold + ex.srazDanLimit;
            }
            else if (ex.salaryGen)
            {
                return ex.salaryGenKc;
            }
            else if (ex.salaryMaxBon)
            {
                return ruleset.SalaryProps.MinMonthlyWage + 2000;
            }
            else if (ex.salaryMinZdr && ruleset.HealthProps.MinMonthlyBasis > 0)
            {
                return ruleset.HealthProps.MinMonthlyBasis + ex.salaryMinZdrKc;
            }
            else if (ex.salaryMinZdr)
            {
                return prevset.HealthProps.MinMonthlyBasis + ex.salaryMinZdrKc;
            }
            else if (ex.salaryMinZdrPrev && prevset.HealthProps.MinMonthlyBasis > 0)
            {
                return prevset.HealthProps.MinMonthlyBasis + ex.salaryMinZdrKc;
            }
            else if (ex.salaryMinZdrPrev)
            {
                return ruleset.HealthProps.MinMonthlyBasis + ex.salaryMinZdrKc;
            }
            else if (ex.salaryMaxZdr && ruleset.HealthProps.MaxAnnualsBasis > 0)
            {
                return ruleset.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxZdr)
            {
                return prevset.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxZdrPrev && prevset.HealthProps.MaxAnnualsBasis > 0)
            {
                return prevset.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxZdrPrev)
            {
                return ruleset.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxSoc && ruleset.SocialProps.MaxAnnualsBasis > 0)
            {
                return ruleset.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salaryMaxSoc)
            {
                return prevset.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salaryMaxSocPrev && prevset.SocialProps.MaxAnnualsBasis > 0)
            {
                return prevset.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salaryMaxSocPrev)
            {
                return ruleset.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salarySolTax && ruleset.TaxingProps.MarginIncomeOfSolitary > 0)
            {
                return ruleset.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
            }
            else if (ex.salarySolTax)
            {
                return prevset.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
            }
            else if (ex.salarySolTaxPrev && prevset.TaxingProps.MarginIncomeOfSolitary > 0)
            {
                return prevset.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
            }
            else if (ex.salarySolTaxPrev)
            {
                return ruleset.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
            }
            else if (ex.salaryNemUcast)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                }
            }
            else if (ex.salaryNemUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                }
            }
            else if (ex.salaryZdrUcast)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                }
            }
            else if (ex.salaryZdrUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                }
            }
            else if (ex.salaryZdrUcastEmp)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                }
            }
            else if (ex.salaryZdrUcastEmpPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                }
            }
            return 15000; 
        }
        public static Int32 DefAgreemBasis(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (ex.salaryGen)
            {
                return 0;
            }
            else if (ex.agreemGen)
            {
                return ex.agreemGenKc;
            }
            else if (ex.salaryNemUcast)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.SocialProps.MarginIncomeAgr + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            else if (ex.salaryNemUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.SocialProps.MarginIncomeAgr + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            else if (ex.salaryZdrUcast)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            else if (ex.salaryZdrUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            else if (ex.salaryZdrUcastEmp)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            else if (ex.salaryZdrUcastEmpPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.SocialProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            return 0; 
        }
        public static bool DefSocialPayer(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefHealthPayer(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefHealthMinim(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (ex.conMinZdr)
            {
                return ex.conMinZdrBen;
            }
            return true; 
        }
        public static bool DefSocialEmper(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefHealthEmper(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefPenzisPayer(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return false; 
        }
        public static bool DefTaxingPayer(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefTaxDeclarat(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxingPayer==false)
            {
                return false;
            }
            if (ex.srazDan)
            {
                return false;
            }
            if (ex.srazDanPrev)
            {
                return false;
            }
            if (ex.podepTax)
            {
                return ex.podepTaxVal;
            }
            return true; 
        }
        public static bool DefTaxBenPayer(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxDeclarat == false)
            {
                return false;
            }
            return true; 
        }
        public static bool DefTaxBenDis01(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxBenPayer == false)
            {
                return false;
            }
            if (ex.taxDisab)
            {
                if (ex.taxDisabBen1)
                {
                    return true;
                }
            }

            return false; 
        }
        public static bool DefTaxBenDis02(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxBenPayer == false)
            {
                return false;
            }
            if (ex.taxDisab)
            {
                if (ex.taxDisabBen2)
                {
                    return true;
                }
            }
            return false; 
        }
        public static bool DefTaxBenDis03(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxBenPayer == false)
            {
                return false;
            }
            if (ex.taxDisab)
            {
                if (ex.taxDisabBen3)
                {
                    return true;
                }
            }
            return false; 
        }
        public static bool DefTaxBebStudy(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxBenPayer == false)
            {
                return false;
            }
            if (ex.taxStudy)
            {
                if (ex.taxStudyBen)
                {
                    return true;
                }
            }
            return false; 
        }
        public static ChildSpec[] DefTaxChildren(IPeriod period, IBundleProps ruleset, IBundleProps prevset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxBenPayer == false)
            {
                return new ChildSpec[0];
            }

            if (ex.taxChild)
            {
                ChildSpec[] childs = new ChildSpec[0];
                for (int por1 = 0; por1 < ex.taxChildPor1; por1++)
                {
                    childs = childs.Append(new ChildSpec {
                        Id = ((Int16)(por1+1+10)),
                        Name = $"Poradi1{por1+1} Dite",
                        TaxBenefitChild = ex.taxChildNorm,
                        TaxBenefitDisab = ex.taxChildZtpp,
                        TaxBenefitOrder = 1,
                    }).ToArray();
                }
                for (int por2 = 0; por2 < ex.taxChildPor2; por2++)
                {
                    childs = childs.Append(new ChildSpec {
                        Id = ((Int16)(por2+1+20)),
                        Name = $"Poradi2{por2+1} Dite",
                        TaxBenefitChild = ex.taxChildNorm,
                        TaxBenefitDisab = ex.taxChildZtpp,
                        TaxBenefitOrder = 2,
                    }).ToArray();
                }
                for (int por3 = 0; por3 < ex.taxChildPor3; por3++)
                {
                    childs = childs.Append(new ChildSpec {
                        Id = ((Int16)(por3+1+30)),
                        Name = $"Poradi3{por3+1} Dite",
                        TaxBenefitChild = ex.taxChildNorm,
                        TaxBenefitDisab = ex.taxChildZtpp,
                        TaxBenefitOrder = 3,
                    }).ToArray();
                }
                return childs;
            }
            return new ChildSpec[0]; 
        }

    }
    public class ContractSpec
    {
        public ContractSpec()
        {
            Id = 0;
            Name = "";
            Type = WorkContractTerms.WORKTERM_EMPLOYMENT_1;
            Schedule = 0;
            NonAttendance = 0;
            Salary = 0;
            Agreem = 0;
            InsHealthPayer = false;
            InsHealthMinim = false;
            InsHealthZahran = false;
            InsHealthZahEhp = false;
            InsHealthEmpler = false;
            InsSocialPayer = false;
            InsSocialMalRoz = false;
            InsSocialZahran = false;
            InsSocialZahEhp = false;
            InsSocialEmpler = false;
        }

        public string NemPojCin()
        {
            string imp = "0";
            switch (this.Type)
            {
                case WorkContractTerms.WORKTERM_EMPLOYMENT_1:imp = "1";
                    break;
                case WorkContractTerms.WORKTERM_CONTRACTER_A:imp = "10";
                    break;
                case WorkContractTerms.WORKTERM_CONTRACTER_T:imp = "30";
                    break;
                case WorkContractTerms.WORKTERM_PARTNER_STAT:imp = "26";
                    break;
                case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:imp = "40";
                    break;
            }
            return imp;
        }
        public string NemPojImp()
        {
            string imp = "0";
            if (InsSocialPayer)
            {
                if (InsSocialMalRoz)
                {
                    //const int ZAMESTNANI09_ZAMESTPP = 0;
                    //const int ZAMESTNANI09_MALEROZS = 1;
                    //const int ZAMESTNANI09_KRATKE01 = 2;
                    //const int ZAMESTNANI09_KRATKE00 = 3;
                    //const int ZAMESTNANI09_KRATKE02 = 4;
                    if (InsSocialZahran)
                    {
                        imp = "12";
                    }
                    else if (InsSocialZahEhp)
                    {
                        imp = "19";
                    }
                    else
                    {
                        imp = "11";
                    }
                }
                else
                {
                    if (InsSocialZahran)
                    {
                        imp = "2";
                    }
                    else if (InsSocialZahEhp)
                    {
                        imp = "9";
                    }
                    else
                    {
                        imp = "1";
                    }
                }
            }
            return imp;
        }
        public string ZdrPojImp()
        {
            string imp = "0";
            if (InsHealthPayer)
            {
                if (InsHealthZahran)
                {
                    imp = "2";
                }
                else
                if (InsHealthZahEhp)
                {
                    imp = "9";
                }
                else
                {
                    imp = "1";
                }
            }
            return imp;
        }
        public string ZdrPojMin()
        {
            string imp = "0";
            if (InsHealthPayer)
            {
                if (InsHealthMinim)
                {
                    imp = "1";
                }
            }
            return imp;
        }
        public static ContractSpec[] One(Int16 id, string name, Int32 sched, Int32 nonAtt, Int32 sal, Int32 agr, bool health, bool minum, bool social, bool heaemp, bool socemp)
        {
            return new ContractSpec[] {
                new ContractSpec() {
                    Id = id,
                    Name = name,
                    Schedule = sched,
                    NonAttendance = nonAtt,
                    Salary = sal,
                    Agreem = agr,
                    InsHealthPayer = health,
                    InsHealthMinim = minum,
                    InsSocialPayer = social,
                    InsHealthEmpler = heaemp,
                    InsSocialEmpler = socemp,
                },
            };
        }
        public Int16 Id { get; set; }
        public string Name { get; set; }
        public WorkContractTerms Type { get; set; }
        public Int32 Schedule { get; set; }
        public Int32 NonAttendance { get; set; }
        public decimal Salary { get; set; }
        public decimal Agreem { get; set; }
        public bool InsHealthPayer { get; set; }
        public bool InsHealthMinim { get; set; }
        public bool InsHealthZahran { get; set; }
        public bool InsHealthZahEhp { get; set; }
        public bool InsHealthEmpler { get; set; }
        public bool InsSocialPayer { get; set; }
        public bool InsSocialMalRoz { get; set; }
        public bool InsSocialZahran { get; set; }
        public bool InsSocialZahEhp { get; set; }
        public bool InsSocialEmpler { get; set; }
    }
    public class ChildSpec
    {
        public ChildSpec()
        {
            Id = 0;
            Name = "";
            TaxBenefitChild = false;
            TaxBenefitDisab = false;
            TaxBenefitOrder = 0;
        }

        public Int16 Id { get; set; }
        public string Name { get; set; }
        public bool TaxBenefitChild { get; set; }
        public bool TaxBenefitDisab { get; set; }
        public Int16 TaxBenefitOrder { get; set; }
    }
    public class ExampleSpec
    {
        static readonly bool yes = true;
        static readonly bool no = false;
        public static IEnumerable<ExampleSpec> GetExamples()
        {
            return new List<ExampleSpec>()
            {
                ExampleSpec.ExampleForStarterEmployee(1),
                ExampleSpec.ExampleForJuniorProgrammer(2),
                ExampleSpec.ExampleForSeniorProgrammer(3),
                ExampleSpec.ExampleForMarketing(4),
                ExampleSpec.ExampleForMaintenance(5),
                ExampleSpec.ExampleForManagement(6),
                ExampleSpec.ExampleForDesigner(7),
                ExampleSpec.ExampleForSalesman(8),
                ExampleSpec.ExampleForVisionary(10),
                ExampleSpec.ExampleForContracter(11),
                ExampleSpec.ExampleForMaxHealth(12),
                ExampleSpec.ExampleForMaxSocial(13),
                ExampleSpec.ExampleForMaxBonus(14),
                ExampleSpec.ExampleForMinBonus(15)
            };
        }
        public static IEnumerable<ExampleSpec> GetExamples2013(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            //Employment with Tax Advance, Withholding tax, no Minimum Health, Absence hours
            SpecGeneratorItem pomGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_EMPLOYMENT_1,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
                socialEmper = SpecGeneratorItem.DefSocialEmper,
                healthEmper = SpecGeneratorItem.DefHealthEmper,
                penzisPayer = SpecGeneratorItem.DefPenzisPayer,
                taxingPayer = SpecGeneratorItem.DefTaxingPayer,
                taxDeclarat = SpecGeneratorItem.DefTaxDeclarat,
                taxBenPayer = SpecGeneratorItem.DefTaxBenPayer,
                taxBenDis01 = SpecGeneratorItem.DefTaxBenDis01,
                taxBenDis02 = SpecGeneratorItem.DefTaxBenDis02,
                taxBenDis03 = SpecGeneratorItem.DefTaxBenDis03,
                taxBebStudy = SpecGeneratorItem.DefTaxBebStudy,
                taxChildren = SpecGeneratorItem.DefTaxChildren,
            };
            //Employment - short-term contract with agreement to perform work
            SpecGeneratorItem dpcGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_CONTRACTER_A,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
                socialEmper = SpecGeneratorItem.DefSocialEmper,
                healthEmper = SpecGeneratorItem.DefHealthEmper,
                penzisPayer = SpecGeneratorItem.DefPenzisPayer,
                taxingPayer = SpecGeneratorItem.DefTaxingPayer,
                taxDeclarat = SpecGeneratorItem.DefTaxDeclarat,
                taxBenPayer = SpecGeneratorItem.DefTaxBenPayer,
                taxBenDis01 = SpecGeneratorItem.DefTaxBenDis01,
                taxBenDis02 = SpecGeneratorItem.DefTaxBenDis02,
                taxBenDis03 = SpecGeneratorItem.DefTaxBenDis03,
                taxBebStudy = SpecGeneratorItem.DefTaxBebStudy,
                taxChildren = SpecGeneratorItem.DefTaxChildren,
            };
            //Employment - short-term contract with agreement to complete a job
            SpecGeneratorItem dppGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_CONTRACTER_T,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
                socialEmper = SpecGeneratorItem.DefSocialEmper,
                healthEmper = SpecGeneratorItem.DefHealthEmper,
                penzisPayer = SpecGeneratorItem.DefPenzisPayer,
                taxingPayer = SpecGeneratorItem.DefTaxingPayer,
                taxDeclarat = SpecGeneratorItem.DefTaxDeclarat,
                taxBenPayer = SpecGeneratorItem.DefTaxBenPayer,
                taxBenDis01 = SpecGeneratorItem.DefTaxBenDis01,
                taxBenDis02 = SpecGeneratorItem.DefTaxBenDis02,
                taxBenDis03 = SpecGeneratorItem.DefTaxBenDis03,
                taxBebStudy = SpecGeneratorItem.DefTaxBebStudy,
                taxChildren = SpecGeneratorItem.DefTaxChildren,
            };

            ExampleParam exDefaults = new ExampleParam();
            ExampleParam exSrazNep0 = new ExampleParam() {
                srazDan = true,
                srazDanLimit = 0,
            };
            ExampleParam exSrazNep1 = new ExampleParam()
            {
                srazDan = true,
                srazDanLimit = 1,
            };
            ExampleParam exSrazNepPrev0 = new ExampleParam() {
                srazDanPrev = true,
                srazDanLimit = 0,
            };
            ExampleParam exSrazNepPrev1 = new ExampleParam()
            {
                srazDanPrev = true,
                srazDanLimit = 1,
            };
            ExampleParam exSalary(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryGen = true,
                    salaryGenKc = kc,
                };
            }
            ExampleParam exAgreem(Int32 kc)
            {
                return new ExampleParam()
                {
                    agreemGen = true,
                    agreemGenKc = kc,
                };
            }
            ExampleParam exNoMinSalary(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryGen = true,
                    salaryGenKc = kc,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exNoMinAgreem(Int32 kc)
            {
                return new ExampleParam()
                {
                    agreemGen = true,
                    agreemGenKc = kc,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryDite(Int32 kc, Int32 ditePoc1, Int32 ditePoc2, Int32 ditePoc3)
            {
                return new ExampleParam()
                {
                    salaryGen = true,
                    salaryGenKc = kc,
                    taxChild = true,
                    taxChildPor1 = ditePoc1,
                    taxChildPor2 = ditePoc2,
                    taxChildPor3 = ditePoc3,
                    taxChildNorm = true,
                };
            }
            ExampleParam exDite(Int32 ditePoc1, Int32 ditePoc2, Int32 ditePoc3)
            {
                return new ExampleParam()
                {
                    taxChild = true,
                    taxChildPor1 = ditePoc1,
                    taxChildPor2 = ditePoc2,
                    taxChildPor3 = ditePoc3,
                    taxChildNorm = true,
                };
            }
            ExampleParam exDiteZtp(Int32 ditePoc1, Int32 ditePoc2, Int32 ditePoc3)
            {
                return new ExampleParam()
                {
                    taxChild = true,
                    taxChildPor1 = ditePoc1,
                    taxChildPor2 = ditePoc2,
                    taxChildPor3 = ditePoc3,
                    taxChildZtpp = true,
                };
            }
            ExampleParam exSalaryDiteZtp(Int32 kc, Int32 ditePoc1, Int32 ditePoc2, Int32 ditePoc3)
            {
                return new ExampleParam()
                {
                    salaryGen = true,
                    salaryGenKc = kc,
                    taxChild = true,
                    taxChildPor1 = ditePoc1,
                    taxChildPor2 = ditePoc2,
                    taxChildPor3 = ditePoc3,
                    taxChildZtpp = true,
                };
            }
            ExampleParam exDiteMaxBonus = new ExampleParam()
            {
                salaryMaxBon = true,
                taxChild = true,
                taxChildPor1 = 1,
                taxChildPor2 = 1,
                taxChildPor3 = 5,
                taxChildZtpp = true,
            };
            ExampleParam exSalaryMinZdr(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMinZdr = true,
                    salaryMinZdrKc = kc,
                };
            }
            ExampleParam exSalaryMinZdrPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMinZdrPrev = true,
                    salaryMinZdrKc = kc,
                };
            }
            ExampleParam exSalaryMaxZdr(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMaxZdr = true,
                    salaryMaxZdrKc = kc,
                };
            }
            ExampleParam exSalaryMaxZdrPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMaxZdrPrev = true,
                    salaryMaxZdrKc = kc,
                };
            }
            ExampleParam exSalaryMaxSoc(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMaxSoc = true,
                    salaryMaxSocKc = kc,
                };
            }
            ExampleParam exSalaryMaxSocPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryMaxSocPrev = true,
                    salaryMaxSocKc = kc,
                };
            }
            ExampleParam exSalarySolTax(Int32 kc)
            {
                return new ExampleParam()
                {
                    salarySolTax = true,
                    salarySolTaxKc = kc,
                };
            }
            ExampleParam exSalarySolTaxPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salarySolTaxPrev = true,
                    salarySolTaxKc = kc,
                };
            }
            ExampleParam exSalaryInv(Int32 kc, bool inv1, bool inv2, bool inv3)
            {
                return new ExampleParam()
                {
                    salaryGen = true,
                    salaryGenKc = kc,
                    taxDisab = true,
                    taxDisabBen1 = inv1,
                    taxDisabBen2 = inv2,
                    taxDisabBen3 = inv3,
                };
            }
            ExampleParam exTaxInval(bool inv1, bool inv2, bool inv3)
            {
                return new ExampleParam()
                {
                    taxDisab = true,
                    taxDisabBen1 = inv1,
                    taxDisabBen2 = inv2,
                    taxDisabBen3 = inv3,
                };
            }
            ExampleParam exTaxStudy = new ExampleParam()
            {
                taxStudy = true,
                taxStudyBen = true,
            };
            ExampleParam exSalaryUcastNem(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryNemUcast = true,
                    salaryNemUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryUcastNemPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryNemUcastPrev = true,
                    salaryNemUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryUcastZdr(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcast = true,
                    salaryZdrUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryUcastZdrPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcastPrev = true,
                    salaryZdrUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryUcastZdrEmp(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcastEmp = true,
                    salaryZdrUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }
            ExampleParam exSalaryUcastZdrEmpPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcastEmpPrev = true,
                    salaryZdrUcastKc = kc,
                    podepTax = true,
                    podepTaxVal = false,
                    conMinZdr = true,
                    conMinZdrBen = false,
                };
            }

            return new List<ExampleSpec>()
            {
                pomGenItem.CreateExample(period, ruleset, prevset, 101, "PP-Mzda_DanPoj-SlevyZaklad",      "101", 40, 0, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 102, "PP-Mzda_DanPoj-SlevyDite1",       "102", 40, 0, exSalaryDiteZtp(15600, 1, 0, 0)), //, CZK 15600    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 103, "PP-Mzda_DanPoj-BonusDite1",       "103", 40, 0, exDiteZtp(1,0,0)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 104, "PP-Mzda_DanPoj-BonusDite2",       "104", 40, 0, exDiteZtp(1,1,0)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 2,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 105, "PP-Mzda_DanPoj-MaxBonus",         "105", 40, 0, exDiteMaxBonus), //, CZK 10000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 7,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 106, "PP-Mzda_DanPoj-MinZdravPrev",     "106", 40, 0, exSalaryMinZdrPrev(-200)), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 107, "PP-Mzda_DanPoj-MinZdravCurr",     "107", 40, 0, exSalaryMinZdr(-200)), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 108, "PP-Mzda_DanPoj-MaxZdravPrev",     "108", 40, 0, exSalaryMaxZdrPrev(100)), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 109, "PP-Mzda_DanPoj-MaxZdravCurr",     "109", 40, 0, exSalaryMaxZdr(100)), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 110, "PP-Mzda_DanPoj-MaxSocialPrev",    "110", 40, 0, exSalaryMaxSocPrev(100)), //, CZK 1206676  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 111, "PP-Mzda_DanPoj-MaxSocialCurr",    "111", 40, 0, exSalaryMaxSoc(100)), //, CZK 1242532  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 112, "PP-Mzda_DanPoj-SolidarDanPrev",   "112", 40, 0, exSalarySolTaxPrev(1000)), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 113, "PP-Mzda_DanPoj-SolidarDanCurr",   "113", 40, 0, exSalarySolTax(1000)), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 114, "PP-Mzda_DanPoj-DuchSpor",         "114", 40, 0, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 115, "PP-Mzda_DanPoj-SlevyInv1",        "115", 40, 0, exSalaryInv(20000, yes, no, no)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  YES, NO, NO              ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 116, "PP-Mzda_DanPoj-SlevyInv2",        "116", 40, 0, exTaxInval(no, yes, no)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 117, "PP-Mzda_DanPoj-SlevyInv3",        "117", 40, 0, exTaxInval(no, no, yes)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 118, "PP-Mzda_DanPoj-SlevyStud",        "118", 40, 0, exTaxStudy), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  YES                  ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 119, "PP-Mzda_DanPoj-SlevyZakl015",     "119", 40, 0, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 120, "PP-Mzda_DanPoj-SlevyZakl020",     "120", 40, 0, exSalary(20000 )), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 121, "PP-Mzda_DanPoj-SlevyZakl025",     "121", 40, 0, exSalary(25000 )), //, CZK 25000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 122, "PP-Mzda_DanPoj-SlevyZakl030",     "122", 40, 0, exSalary(30000 )), //, CZK 30000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 123, "PP-Mzda_DanPoj-SlevyZakl035",     "123", 40, 0, exSalary(35000 )), //, CZK 35000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 124, "PP-Mzda_DanPoj-SlevyZakl040",     "124", 40, 0, exSalary(40000 )), //, CZK 40000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 125, "PP-Mzda_DanPoj-SlevyZakl045",     "125", 40, 0, exSalary(45000 )), //, CZK 45000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 126, "PP-Mzda_DanPoj-SlevyZakl050",     "126", 40, 0, exSalary(50000 )), //, CZK 50000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 127, "PP-Mzda_DanPoj-SlevyZakl055",     "127", 40, 0, exSalary(55000 )), //, CZK 55000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 128, "PP-Mzda_DanPoj-SlevyZakl060",     "128", 40, 0, exSalary(60000 )), //, CZK 60000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 129, "PP-Mzda_DanPoj-SlevyZakl065",     "129", 40, 0, exSalary(65000 )), //, CZK 65000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 130, "PP-Mzda_DanPoj-SlevyZakl070",     "130", 40, 0, exSalary(70000 )), //, CZK 70000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 131, "PP-Mzda_DanPoj-SlevyZakl075",     "131", 40, 0, exSalary(75000 )), //, CZK 75000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 132, "PP-Mzda_DanPoj-SlevyZakl080",     "132", 40, 0, exSalary(80000 )), //, CZK 80000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 133, "PP-Mzda_DanPoj-SlevyZakl085",     "133", 40, 0, exSalary(85000 )), //, CZK 85000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 134, "PP-Mzda_DanPoj-SlevyZakl090",     "134", 40, 0, exSalary(90000 )), //, CZK 90000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 135, "PP-Mzda_DanPoj-SlevyZakl095",     "135", 40, 0, exSalary(95000 )), //, CZK 95000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 136, "PP-Mzda_DanPoj-SlevyZakl100",     "136", 40, 0, exSalary(100000)), //, CZK 100000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 137, "PP-Mzda_DanPoj-SlevyZakl105",     "137", 40, 0, exSalary(105000)), //, CZK 105000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 138, "PP-Mzda_DanPoj-SlevyZakl110",     "138", 40, 0, exSalary(110000)), //, CZK 110000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                pomGenItem.CreateExample(period, ruleset, prevset, 201, "PP-Mzda_NepodPoj-PrevLo",         "201", 40, 0, exSrazNepPrev0), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 202, "PP-Mzda_NepodPoj-PrevHi",         "202", 40, 0, exSrazNepPrev1), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 203, "PP-Mzda_NepodPoj-CurrLo",         "203", 40, 0, exSrazNep0), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 204, "PP-Mzda_NepodPoj-CurrHi",         "204", 40, 0, exSrazNep1), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                pomGenItem.CreateExample(period, ruleset, prevset, 301, "PP-Mzda_DanPoj-Dan099",           "301", 40, 0, exNoMinAgreem(74)), //, CZK 74       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 302, "PP-Mzda_DanPoj-Dan100",           "302", 40, 0, exNoMinSalary(75)), //, CZK 75       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 303, "PP-Mzda_DanPoj-Dan101",           "303", 40, 0, exNoMinSalary(100)), //, CZK 100      ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                pomGenItem.CreateExample(period, ruleset, prevset, 401, "PP-Mzda_DanPoj-Neodpr064",        "401", 40,  46, exSalary(20000)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                pomGenItem.CreateExample(period, ruleset, prevset, 402, "PP-Mzda_DanPoj-Neodpr184",        "402", 40, 184, exNoMinSalary(20000)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                dpcGenItem.CreateExample(period, ruleset, prevset, 501, "DPC-Mzda_NeUcastZdrav-Prev",      "501", 40, 0, exSalaryUcastZdrPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 502, "DPC-Mzda_UcastZdrav-Prev",        "502", 40, 0, exSalaryUcastZdrPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 503, "DPC-Mzda_NeUcastNemoc-Prev",      "503", 40, 0, exSalaryUcastNemPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 504, "DPC-Mzda_UcastNemoc-Prev",        "504", 40, 0, exSalaryUcastNemPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 505, "DPP-Mzda_NeUcastZdrav-Prev",      "505", 40, 0, exSalaryUcastZdrEmpPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 506, "DPP-Mzda_UcastZdrav-Prev",        "506", 40, 0, exSalaryUcastZdrEmpPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 507, "DPC-Mzda_NeUcastZdrav-Curr",      "507", 40, 0, exSalaryUcastZdr(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 508, "DPC-Mzda_UcastZdrav-Curr",        "508", 40, 0, exSalaryUcastZdr(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 509, "DPC-Mzda_NeUcastNemoc-Curr",      "509", 40, 0, exSalaryUcastNem(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dpcGenItem.CreateExample(period, ruleset, prevset, 510, "DPC-Mzda_UcastNemoc-Curr",        "510", 40, 0, exSalaryUcastNem(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 511, "DPP-Mzda_NeUcastZdrav-Curr",      "511", 40, 0, exSalaryUcastZdrEmp(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 512, "DPP-Mzda_UcastZdrav-Curr",        "512", 40, 0, exSalaryUcastZdrEmp(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                dppGenItem.CreateExample(period, ruleset, prevset, 601, "DPP-Mzda_NeUcastNemoc-Prev",      "601", 40, 0, exSalaryUcastNemPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 602, "DPP-Mzda_UcastNemoc-Prev",        "602", 40, 0, exSalaryUcastNemPrev(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 603, "DPP-Mzda_NeUcastNemoc-Curr",      "603", 40, 0, exSalaryUcastNem(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                dppGenItem.CreateExample(period, ruleset, prevset, 604, "DPP-Mzda_UcastNemoc-Curr",        "604", 40, 0, exSalaryUcastNem(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            };
        }
        public ExampleSpec()
        {
            Id = 0;
            Name = "";
            Description = Array.Empty<string>();
            Number = "";
            Contracts = Array.Empty<ContractSpec>();
            TaxPayer = false;
            TaxDeclaration = false;
            TaxBenefitPayer = false;
            TaxBenefitDisab1 = false;
            TaxBenefitDisab2 = false;
            TaxBenefitDisab3 = false;
            TaxBenefitStudy = false;
            TaxChildren = Array.Empty<ChildSpec>();
            InsPenzisPayer = false;
        }

        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string Number { get; set; }

        public ContractSpec[] Contracts { get; set; }
        public bool TaxPayer { get; set; }
        public bool TaxDeclaration { get; set; }
        public bool TaxBenefitPayer { get; set; }
        public bool TaxBenefitDisab1 { get; set; }
        public bool TaxBenefitDisab2 { get; set; }
        public bool TaxBenefitDisab3 { get; set; }
        public bool TaxBenefitStudy { get; set; }
        public ChildSpec[] TaxChildren { get; set; }
        public bool InsPenzisPayer { get; set; }

        public static ExampleSpec ExampleForStarterEmployee(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Starter Employee.",
                Number = "10000",
                Description = new string[] {
                  "Working schedule: 40 hours/Weekly",
                  "Salary: 15 000 CZK",
                  "Tax, Social and Health Insurance Payer",
                  "Claim payer tax benefit",
                  "No child"
                  },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                        Schedule = 40,
                        NonAttendance = 0,
                        Salary = 15000m,
                        InsSocialPayer = yes,
                        InsHealthPayer = yes,
                        InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForJuniorProgrammer(Int32 id)
        {
            return new ExampleSpec
            {
                Id = 2,
                Name = "Junior Programmer.",
                Number = "10001",
                Description = new string[] {
                  "Working schedule: 40 hours/Weekly",
                  "Salary: 25 000 CZK",
                  "Tax, Social and Health Insurance Payer",
                  "Claim payer tax benefit",
                  "Claim tax benfit for 1 child"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 25000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForSeniorProgrammer(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Senior Programmer.",
                Number = "00010",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 75 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 2 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                        Schedule = 40,
                        NonAttendance = 0,
                        Salary = 75000m,
                        InsSocialPayer = yes,
                        InsHealthPayer = yes,
                        InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForMarketing(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Marketing.",
                Number = "00200",
                Description = new string[] {
                      "Working schedule: 20 hours/Weekly",
                      "Salary: 85 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 3 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 85000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForManagement(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Management.",
                Number = "00001",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 125 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 4 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 125000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForMaintenance(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Maintenance.",
                Number = "00300",
                Description = new string[] {
                      "Working schedule: 10 hours/Weekly",
                      "Salary: 5 000 CZK",
                      "Tax Payer",
                      "No Social and Health Insurance",
                      "No tax declaration and benefits"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                        Schedule = 10,
                        NonAttendance = 0,
                        Salary = 5000m,
                        InsSocialPayer = no,
                        InsHealthPayer = no,
                        InsHealthMinim = no,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = no,
                TaxBenefitPayer = no,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForDesigner(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Designer.",
                Number = "05000",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 105 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "No child"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 105000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForSalesman(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Salesman.",
                Number = "06000",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 65 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 2 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 105000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForVisionary(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Visionary.",
                Number = "00011",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 336 667 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 2 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 336667m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForContracter(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Contracter.",
                Number = "07011",
                Description = new string[] {
                      "Working schedule: 24 hours/Weekly",
                      "Salary: 5 000 CZK",
                      "Tax Payer",
                      "Social and Health Insurance",
                      "No tax declaration and benefits"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 24,
                      NonAttendance = 0,
                      Salary = 5000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = no,
                TaxBenefitPayer = no,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForMaxSocial(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Max Social insurance base.",
                Number = "08011",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 1 242 532 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim disability 3 benefit",
                      "Claim studying benefit"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 24,
                      NonAttendance = 0,
                      Salary = 1242532m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = yes,
                TaxBenefitStudy = yes,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForMaxHealth(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Max Health insurance base.",
                Number = "08012",
                Description = new string[] {
                  "Working schedule: 40 hours/Weekly",
                  "Salary: 1 809 964 CZK",
                  "Tax, Social and Health Insurance Payer",
                  "Claim payer tax benefit",
                  "Claim disability 3 benefit",
                  "Claim studying benefit"
                },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 1809964m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = yes,
                TaxBenefitStudy = yes,
                TaxChildren = Array.Empty<ChildSpec>(),
            };
        }
        public static ExampleSpec ExampleForMaxBonus(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "Max Child's Tax Bonus.",
                Number = "08013",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 10 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 5 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 40,
                      NonAttendance = 0,
                      Salary = 10000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 2,
                    },
                },
            };
        }
        public static ExampleSpec ExampleForMinBonus(Int32 id)
        {
            return new ExampleSpec
            {
                Id = id,
                Name = "2 Child's Tax Bonus.",
                Number = "08014",
                Description = new string[] {
                      "Working schedule: 40 hours/Weekly",
                      "Salary: 15 000 CZK",
                      "Tax, Social and Health Insurance Payer",
                      "Claim payer tax benefit",
                      "Claim tax benfit for 2 children"
                    },
                Contracts = new ContractSpec[] {
                    new ContractSpec() {
                      Schedule = 24,
                      NonAttendance = 0,
                      Salary = 15000m,
                      InsSocialPayer = yes,
                      InsHealthPayer = yes,
                      InsHealthMinim = yes,
                    },
                },
                TaxPayer = yes,
                TaxDeclaration = yes,
                TaxBenefitPayer = yes,
                TaxBenefitDisab1 = no,
                TaxBenefitDisab2 = no,
                TaxBenefitDisab3 = no,
                TaxBenefitStudy = no,
                TaxChildren = new ChildSpec[]
                {
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 0,
                    },
                    new ChildSpec()
                    {
                      TaxBenefitChild = yes,
                      TaxBenefitDisab = no,
                      TaxBenefitOrder = 1,
                    },
                },
            };
        }
        public string exampleString()
        {
            ContractSpec con = Contracts.FirstOrDefault();
            var detiNorm = TaxChildren.Aggregate(0, (agr, x) => (agr + (x.TaxBenefitChild ? 1 : 0)));
            var detiZtpp = TaxChildren.Aggregate(0, (agr, x) => (agr + (x.TaxBenefitDisab ? 1 : 0)));
            var detiCis1 = TaxChildren.Aggregate(0, (agr, x) => (agr + (x.TaxBenefitOrder == 1 ? 1 : 0)));
            var detiCis2 = TaxChildren.Aggregate(0, (agr, x) => (agr + (x.TaxBenefitOrder == 2 ? 1 : 0)));
            var detiCis3 = TaxChildren.Aggregate(0, (agr, x) => (agr + (x.TaxBenefitOrder == 3 ? 1 : 0)));
            StringBuilder builder = new StringBuilder($"{this.Number};");
            builder.Append($"{this.Name};");
            builder.Append($"{con.Schedule};");
            builder.Append($"{con.NonAttendance};");
            builder.Append($"CZK {con.Salary};");
            builder.Append($"CZK {con.Agreem};");
            builder.Append($"{boolToYES_NO(this.TaxPayer)};");//1;
            builder.Append($"{boolToYES_NO(this.TaxDeclaration)};");//1;
            builder.Append($"{boolToYES_NO(con.InsHealthPayer)};");//1;
            builder.Append($"{boolToYES_NO(con.InsHealthMinim)};");//1;
            builder.Append($"{boolToYES_NO(con.InsSocialPayer)};");//1;
            builder.Append($"{boolToYES_NO(this.InsPenzisPayer)};");//0;
            builder.Append($"{boolToYES_NO(this.TaxBenefitPayer)};");//1;
            builder.Append($"{detiNorm};");//0;
            builder.Append($"{detiZtpp};");//0;
            builder.Append($"{boolToYES_NO(this.TaxBenefitDisab1)};");//0;
            builder.Append($"{boolToYES_NO(this.TaxBenefitDisab2)};");//0;
            builder.Append($"{boolToYES_NO(this.TaxBenefitDisab3)};");//0;
            builder.Append($"{boolToYES_NO(this.TaxBenefitStudy)};");//0;
            builder.Append($"{boolToYES_NO(con.InsHealthEmpler)};");//0;
            builder.Append($"{boolToYES_NO(con.InsSocialEmpler)};");//0;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;
            builder.Append(";");//;

            return builder.ToString();
        }
        public string[] importString(IPeriod period)
        {
            string[] importResult = Array.Empty<string>();

            string[] names = this.Name.Split('_');

            ImportData01 imp01 = new ImportData01()
            {
                IMP_OSC = this.Number,
                IMP01_PRIJ = $"X{this.Number}{names[1]}",
                IMP01_JMENO = $"{names[0]}",
                IMP01_RODPRIJ = $"{names[1]}{this.Number}",
                IMP01_RODCIS = $"7707077{this.Number}",
                IMP_ADRESA_OBEC = "Praha",
                IMP_ADRESA_ULICE = "U Remízku",
                IMP_ADRESA_OCIS = "123/12",
                IMP_ADRESA_PSC = "11505",
                IMP01_MISTONAR = "Praha",
            };
            ImportData02 imp02 = new ImportData02()
            {
                IMP_OSC = this.Number,
                IMP02_ZPUSOB = "0",
            };
            ImportData05 imp05 = new ImportData05()
            {
                IMP_OSC = this.Number,
                IMP05_KODZDRAVPOJ = "111",
            };
            ImportData08 imp08 = new ImportData08()
            {
                IMP_OSC = this.Number,
                IMP08_PODEPSAL = this.TaxPodImp(), 
                IMP08_INVALIDITA1 = boolToImp(this.TaxBenefitDisab1),
                IMP08_INVALIDITA2 = boolToImp(this.TaxBenefitDisab2),
                IMP08_INVALIDITA3 = boolToImp(this.TaxBenefitDisab3),
            };

            importResult = importResult.Concat(new string[] { imp01.Export(), imp02.Export(), imp05.Export(), imp08.Export() }).ToArray();
            foreach (var con in Contracts)
            {
                ImportData17 imp17 = new ImportData17()
                {
                    IMP_OSC = this.Number,
                    IMP_POM = $"{this.Number}-{con.Id}",
                    IMP17_CINNOSTSPOJ = con.NemPojCin(),
                    IMP17_DATUMZAC = $"1.1.{period.Year}",
                    IMP17_DATUMKON = "",
                    IMP17_PLATCEDANPR = boolToImp(TaxPayer),
                    IMP17_PLATCESPOJ = con.NemPojImp(),
                    IMP17_PLATCEZPOJ = con.ZdrPojImp(),
                    IMP17_MIN_ZP = con.ZdrPojMin(),
                };
                ImportData18 imp18 = new ImportData18()
                {
                    IMP_OSC = this.Number,
                    IMP_POM = $"{this.Number}-{con.Id}",
                    IMP18_ZPODMEN = "0",
                    IMP18_DRUHUVAZ = "0",
                    IMP18_PLNUVAZ = "2400",
                    IMP18_SKUTUVAZ = "2400",
                };
                ImportData19 imp19 = null;
                if (con.Salary != 0m)
                {
                    imp19 = new ImportData19()
                    {
                        IMP_OSC = this.Number,
                        IMP_POM = $"{this.Number}-{con.Id}",
                        IMP19_KODMZDA = "1000",
                        IMP19_SAZBAKC = $"{ con.Salary.ToString()}00",
                        IMP19_TRVALE = "A-1",
                    };
                }
                if (con.Agreem != 0m)
                {
                    imp19 = new ImportData19()
                    {
                        IMP_OSC = this.Number,
                        IMP_POM = $"{this.Number}-{con.Id}",
                        IMP19_KODMZDA = "1809",
                        IMP19_SAZBAKC = $"{ con.Agreem.ToString()}00",
                        IMP19_TRVALE = "A-1",
                    };
                }
                importResult = importResult.Concat(new string[] { imp17.Export(), imp18.Export() }).ToArray();
                if (imp19 != null)
                {
                    importResult = importResult.Concat(new string[] { imp19.Export() }).ToArray();
                }
            }
            foreach (var child in TaxChildren)
            {
                string[] cnames = child.Name.Split(' ');
                ImportData09 imp09 = new ImportData09()
                {
                    IMP_OSC = this.Number,
                    IMP_ROK = period.Year.ToString(),
                    IMP09_JMENO = cnames[1],
                    IMP09_PRIJ = cnames[0],
                    IMP09_DATUMNAR = "9.9.2009",
                    IMP09_RODCIS = $"09090990{child.Id}",
                    IMP09_AKTUALNIOBD = boolToImp(child.TaxBenefitChild || child.TaxBenefitDisab),
                    IMP09_PLATNOSTOBD = "#",
                    IMP09_AKTUALNIPOR = child.TaxBenefitOrder.ToString(),
                    IMP09_PLATNOSTPOR = "#",
                    IMP09_ZTPP = boolToImp(child.TaxBenefitDisab),
                };
                importResult = importResult.Concat(new string[] { imp09.Export() }).ToArray();
            }
            return importResult;
        }

        private string TaxPodImp()
        {
            string imp = "0";
            // (boolToYesNo(this.TaxBenefitPayer, 2, 0) + boolToYesNo(this.TaxDeclaration, 1, 0)).ToString(),           if (InsSocialPayer)
            {
                if (TaxDeclaration)
                {
                    //const int ZAMESTNANI09_ZAMESTPP = 0;
                    //const int ZAMESTNANI09_MALEROZS = 1;
                    //const int ZAMESTNANI09_KRATKE01 = 2;
                    //const int ZAMESTNANI09_KRATKE00 = 3;
                    //const int ZAMESTNANI09_KRATKE02 = 4;
                    if (TaxBenefitPayer)
                    {
                        imp = "3";
                    }
                    else
                    {
                        imp = "1";
                    }
                }
                else
                {
                    imp = "0";
                }
            }
            return imp;
        }

        public Int32 boolToYesNo(bool val, Int32 yes, Int32 no)
        {
            if (val)
            {
                return yes;
            }
            return no;
        }
        public Int32 boolToNumber(bool val)
        {
            if (val)
            {
                return 1;
            }
            return 0;
        }
        public string boolToYES_NO(bool val)
        {
            if (val)
            {
                return "YES";
            }
            return "NO";
        }
        public string boolToImp(bool val)
        {
            if (val)
            {
                return "1";
            }
            return "0";
        }
    }
}
