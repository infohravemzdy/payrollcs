using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace Procezor.OptimulaTest.Examples
{
    public class OptimulaGenerator
    {
        public OptimulaGenerator(int id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;
            AgrWorkHoursFunc = DefaultAgrWorkHours;
            AgrWorkProcsFunc = DefaultAgrWorkProcs;
            AgrWorkMaxHrFunc = DefaultAgrWorkMaxHr;
            AgrWorkMaxKcFunc = DefaultAgrWorkMaxKc;
            HomeOffHoursFunc = DefaultHomeOffHours;
            HomeOffTarifFunc = DefaultHomeOffTarif;
            ClothesTarifFunc = DefaultClothesTarif;
        }

        private Int32 DefaultAgrWorkHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultAgrWorkProcs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultAgrWorkMaxHr(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultAgrWorkMaxKc(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHomeOffHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHomeOffTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultClothesTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }

        public int Id { get; }
        public string Name { get; }
        public string Number { get; }

        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkHoursFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkProcsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkMaxHrFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkMaxKcFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffHoursFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffTarifFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> ClothesTarifFunc { get; private set; }

        public static OptimulaGenerator Spec(Int32 id, string name, string number)
        {
            return new OptimulaGenerator(id, name, number);
        }
        public OptimulaGenerator WithAgrWorkHours(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkHoursFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrWorkProcs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkProcsFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrWorkMaxHr(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkMaxHrFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrWorkMaxKc(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkMaxKcFunc = func;
            return this;
        }
        public OptimulaGenerator WithHomeOffHours(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HomeOffHoursFunc = func;
            return this;
        }
        public OptimulaGenerator WithHomeOffTarif(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HomeOffTarifFunc = func;
            return this;
        }
        public OptimulaGenerator WithClothesTarif(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            ClothesTarifFunc = func;
            return this;
        }

        public IEnumerable<ITermTarget> BuildSpecTargets(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            var targets = Array.Empty<ITermTarget>();

            var montCode = MonthCode.Get(period.Code);

            Int16 CONTRACT_NULL = 0;
            Int16 POSITION_NULL = 0;

            var contractEmp = ContractCode.Get(CONTRACT_NULL);
            var positionEmp = PositionCode.Get(POSITION_NULL);
            var variant1Emp = VariantCode.Get(1);

            Int32 AgrWorkHoursVal = AgrWorkHoursFunc(this, period, ruleset, prevset);
            Int32 AgrWorkProcsVal = AgrWorkProcsFunc(this, period, ruleset, prevset);
            Int32 AgrWorkMaxHrVal = AgrWorkMaxHrFunc(this, period, ruleset, prevset);
            Int32 AgrWorkMaxKcVal = AgrWorkMaxKcFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 ClothesTarifVal = ClothesTarifFunc(this, period, ruleset, prevset);


            // ContractTimePlan	CONTRACT_TIME_PLAN
            var contractTimePlan = new ContractTimePlanTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_PLAN),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_PLAN), 0);
            // ContractTimeWork	CONTRACT_TIME_WORK
            var contractTimeWork = new ContractTimeWorkTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_WORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_WORK), 0);
            // PaymentBasis		PAYMENT_BASIS
            var paymentMSalary = new PaymentBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MSALARY),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS), 0);
            // OptimusBasis		OPTIMUS_BASIS
            var paymentMPerson = new OptimusBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MPERSON),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS), 0);
            // OptimusFixed		OPTIMUS_FIXED
            var paymentPremium = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_PREMIUM),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 0);
            // AgrworkHours		AGRWORK_HOURS
            var agrworkHours = new AgrworkHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_AGRWORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS), 0);
            // AllowceHours		ALLOWCE_HOURS
            var allowceHOffice = new AllowceHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS), 0);
            // AllowceHours		ALLOWCE_HOURS
            var allowceClothes = new AllowceHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS), 0);

            //targets = targets.Concat(new ITermTarget[] { targetSgn }).ToArray();

            return targets;
        }
    }
}
