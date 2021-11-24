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
        public Int32 salaryZdrUcastKc { get; set; }
        public bool podepTax { get; set; }
        public bool podepTaxVal { get; set; }
        public bool srazDan { get; set; }
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

        public ExampleParam()
        {
            salaryGen = false;
            salaryGenKc = 0;
            agreemGen = false;
            agreemGenKc = 0;
            salaryMaxBon = false;

            salaryMinZdr = false;
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
            salaryZdrUcastKc = 0;

            srazDan = false;
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

        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> scheduleWeek { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> salaryBasis { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, Int32> agreemBasis { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> socialPayer { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> healthPayer { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> healthMinim { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> penzisPayer { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxingPayer { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxDeclarat { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenPayer { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis01 { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis02 { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBenDis03 { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, bool> taxBebStudy { get; set; }
        public Func<IPeriod, IServiceLegalios, IBundleProps, ExampleParam, SpecGeneratorParams, ChildSpec[]> taxChildren { get; set; }

        public SpecGeneratorItem()    
        {
            contractType = WorkContractTerms.WORKTERM_EMPLOYMENT_1;
            Description = new string[0];
        }

        public ExampleSpec CreateExample(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, Int32 id, string name, string number, Int32 nonAtten, ExampleParam ex)
        { 
            SpecGeneratorParams param = new SpecGeneratorParams();
            param.Id = id;
            param.Name = name;
            param.Number = number;
            param.Description = this.Description.ToArray();

            param.contractType = this.contractType;
            param.scheduleWeek = this.scheduleWeek(period, legSvc, ruleset, ex, param);
            param.salaryBasis = this.salaryBasis(period, legSvc, ruleset, ex, param);
            param.agreemBasis = this.agreemBasis(period, legSvc, ruleset, ex, param);
            param.socialPayer = this.socialPayer(period, legSvc, ruleset, ex, param);
            param.healthPayer = this.healthPayer(period, legSvc, ruleset, ex, param);
            param.healthMinim = this.healthMinim(period, legSvc, ruleset, ex, param);
            param.penzisPayer = this.penzisPayer(period, legSvc, ruleset, ex, param);
            param.taxingPayer = this.taxingPayer(period, legSvc, ruleset, ex, param);
            param.taxDeclarat = this.taxDeclarat(period, legSvc, ruleset, ex, param);
            param.taxBenPayer = this.taxBenPayer(period, legSvc, ruleset, ex, param);
            param.taxBenDis01 = this.taxBenDis01(period, legSvc, ruleset, ex, param);
            param.taxBenDis02 = this.taxBenDis02(period, legSvc, ruleset, ex, param);
            param.taxBenDis03 = this.taxBenDis03(period, legSvc, ruleset, ex, param);
            param.taxBenStudy = this.taxBebStudy(period, legSvc, ruleset, ex, param);

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
                param.socialPayer,
                param.healthPayer,
                param.healthMinim);
            spec.TaxPayer = param.taxingPayer;
            spec.TaxDeclaration = param.taxDeclarat;
            spec.TaxBenefitPayer = param.taxingPayer;
            spec.TaxBenefitDisab1 = param.taxBenDis01;
            spec.TaxBenefitDisab2 = param.taxBenDis02;
            spec.TaxBenefitDisab3 = param.taxBenDis03;
            spec.TaxBenefitStudy = param.taxBenStudy;
            spec.TaxChildren = this.taxChildren(period, legSvc, ruleset, ex, param);
            spec.InsPenzisPayer = param.penzisPayer;

            return spec;
        }
        public static IPeriod LastYear(IPeriod period)
        {
            return new Period(period.Year - 1, period.Month);
        }
        public static IBundleProps LastYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(LastYear(period));
            return legResult.Value;
        }
        public static Int32 DefScheduleWeek(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return 40; 
        }
        public static Int32 DefSalaryBasis(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            IBundleProps ruleMin = LastYearBundle(legSvc, period);

            if (ex.agreemGen)
            {
                return 0;
            }
            if (ex.srazDan)
            {
                return ruleset.TaxingProps.MarginIncomeOfWithhold + ex.srazDanLimit;
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
            else if (ex.salaryMaxZdr && ruleset.HealthProps.MaxAnnualsBasis > 0)
            {
                return ruleset.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxZdrPrev && ruleMin.HealthProps.MaxAnnualsBasis > 0)
            {
                return ruleMin.HealthProps.MaxAnnualsBasis + ex.salaryMaxZdrKc;
            }
            else if (ex.salaryMaxSoc && ruleset.SocialProps.MaxAnnualsBasis > 0)
            {
                return ruleset.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salaryMaxSocPrev && ruleMin.SocialProps.MaxAnnualsBasis > 0)
            {
                return ruleMin.SocialProps.MaxAnnualsBasis + ex.salaryMaxSocKc;
            }
            else if (ex.salarySolTax && ruleset.TaxingProps.MarginIncomeOfSolitary > 0)
            {
                return ruleset.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
            }
            else if (ex.salarySolTaxPrev && ruleMin.TaxingProps.MarginIncomeOfSolitary > 0)
            {
                return ruleMin.TaxingProps.MarginIncomeOfSolitary + ex.salarySolTaxKc;
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
            else if (ex.salaryNemUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleMin.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleMin.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleMin.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                }
            }
            else if (ex.salaryZdrUcastPrev)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleMin.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return 0;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleMin.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleMin.HealthProps.MarginIncomeEmp + ex.salaryZdrUcastKc;
                }
            }
            return 15000; 
        }
        public static Int32 DefAgreemBasis(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            IBundleProps ruleMin = LastYearBundle(legSvc, period);

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
            else if (ex.salaryZdrUcast)
            {
                switch (param.contractType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return 0;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
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
                        return ruleMin.SocialProps.MarginIncomeEmp + ex.salaryNemUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleMin.SocialProps.MarginIncomeAgr + ex.salaryNemUcastKc;
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
                        return ruleMin.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleMin.HealthProps.MarginIncomeAgr + ex.salaryZdrUcastKc;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return 0;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return 0;
                }
            }
            return 0; 
        }
        public static bool DefSocialPayer(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefHealthPayer(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefHealthMinim(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return true; 
        }
        public static bool DefPenzisPayer(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            return false; 
        }
        public static bool DefTaxingPayer(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (ex.srazDan)
            {
                return false;
            }
            return true; 
        }
        public static bool DefTaxDeclarat(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxingPayer==false)
            {
                return false;
            }
            if (ex.srazDan)
            {
                return false;
            }
            return true; 
        }
        public static bool DefTaxBenPayer(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
        {
            if (param.taxDeclarat == false)
            {
                return false;
            }
            return true; 
        }
        public static bool DefTaxBenDis01(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
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
        public static bool DefTaxBenDis02(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
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
        public static bool DefTaxBenDis03(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
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
        public static bool DefTaxBebStudy(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
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
        public static ChildSpec[] DefTaxChildren(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset, ExampleParam ex, SpecGeneratorParams param) 
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
                        Id = 1,
                        Name = "Poradi1 Dite",
                        TaxBenefitChild = ex.taxChildNorm,
                        TaxBenefitDisab = ex.taxChildZtpp,
                        TaxBenefitOrder = 1,
                    }).ToArray();
                }
                for (int por2 = 0; por2 < ex.taxChildPor2; por2++)
                {
                    childs = childs.Append(new ChildSpec {
                        Id = 1,
                        Name = "Poradi2 Dite",
                        TaxBenefitChild = ex.taxChildNorm,
                        TaxBenefitDisab = ex.taxChildZtpp,
                        TaxBenefitOrder = 2,
                    }).ToArray();
                }
                for (int por3 = 0; por3 < ex.taxChildPor3; por3++)
                {
                    childs = childs.Append(new ChildSpec {
                        Id = 1,
                        Name = "Poradi3 Dite",
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
            Schedule = 0;
            NonAttendance = 0;
            Salary = 0;
            Agreem = 0;
            InsSocialPayer = false;
            InsHealthPayer = false;
            InsHealthMinim = false;
        }

        public static ContractSpec[] One(Int16 id, string name, Int32 sched, Int32 nonAtt, Int32 sal, Int32 agr, bool social, bool health, bool minum)
        {
            return new ContractSpec[] {
                new ContractSpec() {
                    Id = id,
                    Name = name,
                    Schedule = sched,
                    NonAttendance = nonAtt,
                    Salary = sal,
                    Agreem = agr,
                    InsSocialPayer = social,
                    InsHealthPayer = health,
                    InsHealthMinim = minum,
                },
            };
        }
        public Int16 Id { get; set; }
        public string Name { get; set; }
        public Int32 Schedule { get; set; }
        public Int32 NonAttendance { get; set; }
        public decimal Salary { get; set; }
        public decimal Agreem { get; set; }
        public bool InsSocialPayer { get; set; }
        public bool InsHealthPayer { get; set; }
        public bool InsHealthMinim { get; set; }
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
        public static IEnumerable<ExampleSpec> GetExamples2013(IPeriod period, IServiceLegalios legSvc, IBundleProps ruleset)
        {
            SpecGeneratorItem pomGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_EMPLOYMENT_1,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
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
            SpecGeneratorItem dpcGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_CONTRACTER_A,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
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
            SpecGeneratorItem dppGenItem = new SpecGeneratorItem()
            {
                contractType = WorkContractTerms.WORKTERM_CONTRACTER_T,
                scheduleWeek = SpecGeneratorItem.DefScheduleWeek,
                salaryBasis = SpecGeneratorItem.DefSalaryBasis,
                agreemBasis = SpecGeneratorItem.DefAgreemBasis,
                socialPayer = SpecGeneratorItem.DefSocialPayer,
                healthPayer = SpecGeneratorItem.DefHealthPayer,
                healthMinim = SpecGeneratorItem.DefHealthMinim,
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
                taxChildPor2 = 2,
                taxChildPor3 = 4,
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
                };
            }
            ExampleParam exSalaryUcastZdr(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcast = true,
                    salaryZdrUcastKc = kc,
                };
            }
            ExampleParam exSalaryUcastNemPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryNemUcastPrev = true,
                    salaryNemUcastKc = kc,
                };
            }
            ExampleParam exSalaryUcastZdrPrev(Int32 kc)
            {
                return new ExampleParam()
                {
                    salaryZdrUcastPrev = true,
                    salaryZdrUcastKc = kc,
                };
            }

            return new List<ExampleSpec>()
            {
                pomGenItem.CreateExample(period, legSvc, ruleset, 1,  "01-PP-Mzda-DanPoj-SlevyZaklad", "01", 0, exDefaults), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 2,  "02-PP-Mzda-DanPoj-SlevyDite1", "02", 0, exSalaryDiteZtp(15600, 1, 0, 0)), //,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] { new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0 }, }, InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 3,  "03-PP-Mzda-DanPoj-SlevyDite1-Bonus", "03", 0, exDiteZtp(1,0,0)), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0}, },  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 4,  "04-PP-Mzda-DanPoj-SlevyDite2-Bonus", "04", 0, exDiteZtp(2,0,0)), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0}, },  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 5,  "05-PP-Mzda-DanPoj-MaxBonus", "05", 0, exDiteMaxBonus), //, 10000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  new ChildSpec() { TaxBenefitChild = yes, TaxBenefitDisab = yes, TaxBenefitOrder = 0,},  },  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 6,  "06-PP-Mzda-DanPoj-MinZdrav", "06", 0, exSalaryMinZdr(-200)), //, 7800,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 7,  "07-PP-Mzda-DanPoj-MaxZdrav12", "07", 0, exSalaryMaxZdrPrev(100)), //, 1809964,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 8,  "08-PP-Mzda-DanPoj-MaxSocial12", "08", 0, exSalaryMaxSocPrev(100)), //, 1206676,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 9,  "09-PP-Mzda-DanPoj-MaxSocial13", "09", 0, exSalaryMaxSoc(100)), //, 1242532,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 10, "10-PP-Mzda-DanPoj-Neodpr064", "10", 46, exSalary(20000)), //, 20000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 11, "11-PP-Mzda-DanPoj-Neodpr184", "11", 184, exSalary(20000)), //, 20000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 12, "12-PP-Mzda-NepodPoj-5000", "12", 0, exSrazNep0), //, 5000,   TaxPayer = no,  TaxDeclaration = no,    TaxBenefitPayer = no,   TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 13, "13-PP-Mzda-NepodPoj-5001", "13", 0, exSrazNep1), //, 5001,   TaxPayer = no,  TaxDeclaration = no,    TaxBenefitPayer = no,   TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 14, "22-PP-Mzda-DanPoj-SolidarDan", "22", 0, exSalarySolTax(1000)), //, 104536,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 15, "23-PP-Mzda-DanPoj-DuchSpor", "23", 0, exDefaults), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 16, "24-PP-Mzda-DanPoj-Dan099", "24", 0, exAgreem(74)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 17, "25-PP-Mzda-DanPoj-Dan100", "25", 0, exSalary(75)), //, 75,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 18, "26-PP-Mzda-DanPoj-Dan101", "26", 0, exSalary(100)), //, 100,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 19, "27-PP-Mzda-DanPoj-SlevyInv1", "27", 0, exSalaryInv(20000, yes, no, no)), //, 20000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = yes, TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 20, "28-PP-Mzda-DanPoj-SlevyInv2", "28", 0, exTaxInval(no, yes, no)), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = yes, TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 21, "29-PP-Mzda-DanPoj-SlevyInv3", "29", 0, exTaxInval(no, no, yes)), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = yes, TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 22, "30-PP-Mzda-DanPoj-SlevyStud", "30", 0, exTaxStudy), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 23, "31-PP-Mzda-DanPoj-SlevyZaklad15", "31", 0, exDefaults), //, 15000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 24, "32-PP-Mzda-DanPoj-SlevyZaklad20", "32", 0, exSalary(20000)), //, 20000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 25, "33-PP-Mzda-DanPoj-SlevyZaklad25", "33", 0, exSalary(25000)), //, 25000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 26, "34-PP-Mzda-DanPoj-SlevyZaklad30", "34", 0, exSalary(30000)), //, 30000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 27, "35-PP-Mzda-DanPoj-SlevyZaklad35", "35", 0, exSalary(35000)), //, 35000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 28, "36-PP-Mzda-DanPoj-SlevyZaklad40", "36", 0, exSalary(40000)), //, 40000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 29, "37-PP-Mzda-DanPoj-SlevyZaklad45", "37", 0, exSalary(45000)), //, 45000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 30, "38-PP-Mzda-DanPoj-SlevyZaklad50", "38", 0, exSalary(50000)), //, 50000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 31, "39-PP-Mzda-DanPoj-SlevyZaklad55", "39", 0, exSalary(55000)), //, 55000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 32, "40-PP-Mzda-DanPoj-SlevyZaklad60", "40", 0, exSalary(60000)), //, 60000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 33, "41-PP-Mzda-DanPoj-SlevyZaklad65", "41", 0, exSalary(65000)), //, 65000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 34, "42-PP-Mzda-DanPoj-SlevyZaklad70", "42", 0, exSalary(70000)), //, 70000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 35, "43-PP-Mzda-DanPoj-SlevyZaklad75", "43", 0, exSalary(75000)), //, 75000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 36, "44-PP-Mzda-DanPoj-SlevyZaklad80", "44", 0, exSalary(80000)), //, 80000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 37, "45-PP-Mzda-DanPoj-SlevyZaklad85", "45", 0, exSalary(85000)), //, 85000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 38, "46-PP-Mzda-DanPoj-SlevyZaklad90", "46", 0, exSalary(90000)), //, 90000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 39, "47-PP-Mzda-DanPoj-SlevyZaklad95", "47", 0, exSalary(95000)), //, 95000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 40, "48-PP-Mzda-DanPoj-SlevyZaklad100", "48", 0, exSalary(100000)), //, 100000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 41, "49-PP-Mzda-DanPoj-SlevyZaklad105", "49", 0, exSalary(105000)), //, 105000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                pomGenItem.CreateExample(period, legSvc, ruleset, 42, "50-PP-Mzda-DanPoj-SlevyZaklad110", "50", 0, exSalary(110000)), //, 110000,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dpcGenItem.CreateExample(period, legSvc, ruleset, 43, "14-DPC-Mzda-2499-NeUcastZdrav", "14", 0, exSalaryUcastZdr(-1)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dpcGenItem.CreateExample(period, legSvc, ruleset, 44, "15-DPC-Mzda-2500-UcastZdrav", "15", 0, exSalaryUcastZdr(0)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dpcGenItem.CreateExample(period, legSvc, ruleset, 45, "16-DPC-Mzda-2499-NeUcastNemoc", "16", 0, exSalaryUcastNem(-1)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dpcGenItem.CreateExample(period, legSvc, ruleset, 46, "17-DPC-Mzda-2500-UcastNemoc", "17", 0, exSalaryUcastNem(0)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dppGenItem.CreateExample(period, legSvc, ruleset, 47, "18-DPP-Mzda-2499-NeUcastZdrav", "18", 0, exSalaryUcastZdr(-1)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dppGenItem.CreateExample(period, legSvc, ruleset, 48, "19-DPP-Mzda-2500-UcastZdrav", "19", 0, exSalaryUcastZdr(0)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dppGenItem.CreateExample(period, legSvc, ruleset, 49, "20-DPP-Mzda-10000-NeUcastNemoc", "20", 0, exSalaryUcastNem(-1)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
                dppGenItem.CreateExample(period, legSvc, ruleset, 50, "21-DPP-Mzda-10001-UcastNemoc", "21", 0, exSalaryUcastNem(0)), //, 0,      TaxBenefitPayer = yes,  TaxBenefitDisab1 = no,  TaxBenefitDisab2 = no,  TaxBenefitDisab3 = no,  TaxBenefitStudy = no,   TaxChildren = new ChildSpec[] {},  InsPenzisPayer = no, },
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
           StringBuilder builder = new StringBuilder($"{this.Name};");
            builder.Append($"{con.Schedule};");
            builder.Append($"{con.NonAttendance};");
            builder.Append($"{con.Salary};");
            builder.Append($"{con.Agreem};");
            builder.Append($"{boolToNumber(this.TaxPayer)};");//1;
            builder.Append($"{boolToNumber(this.TaxDeclaration)};");//1;
            builder.Append($"{boolToNumber(this.TaxBenefitPayer)};");//1;
            builder.Append($"{boolToNumber(this.TaxBenefitDisab1)};");//0;
            builder.Append($"{boolToNumber(this.TaxBenefitDisab2)};");//0;
            builder.Append($"{boolToNumber(this.TaxBenefitDisab3)};");//0;
            builder.Append($"{boolToNumber(this.TaxBenefitStudy)};");//0;
            builder.Append($"{detiNorm};");//0;
            builder.Append($"{detiZtpp};");//0;
            builder.Append($"{boolToNumber(this.InsPenzisPayer)};");//0;
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
        public Int32 boolToNumber(bool val)
        {
            if (val)
            {
                return 1;
            }
            return 0;
        }
    }
}
