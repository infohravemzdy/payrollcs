using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class TermResult : TermSymbol, ITermResult
    {
        public ITermTarget Target { get; protected set; }
        public IArticleSpec Spec { get; protected set; }
        public ConceptCode Concept { get; private set; }
        public string ResultDescr { get; private set; }
        public Int32 ResultBasis { get; private set; }
        public Int32 ResultValue { get; private set; }

        public TermResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base()
        {
            Target = target;
            Spec = spec;

            Concept = ConceptCode.Zero;

            if (target != null)
            {
                Concept = Target.Concept;
                Contract = Target.Contract;
                Position = Target.Position;
                MonthCode = Target.MonthCode;
                Article = Target.Article;
                Variant = Target.Variant;
            }

            ResultValue = value;
            ResultBasis = basis;
            ResultDescr = descr;
        }
        public TermResult(ITermTarget target, ContractCode con, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base()
        {
            Target = target;
            Spec = spec;

            Concept = ConceptCode.Zero;

            if (target != null)
            {
                Concept = Target.Concept;
                Contract = Target.Contract;
                Position = Target.Position;
                MonthCode = Target.MonthCode;
                Article = Target.Article;
                Variant = Target.Variant;
            }

            Contract = con;
            ResultValue = value;
            ResultBasis = basis;
            ResultDescr = descr;
        }
        public virtual string ConceptDescr()
        {
            return Target?.ConceptDescr() ?? string.Format("ConceptCode for {0}", Concept.Value);
        }
        public virtual string ResultMessage()
        {
            return ResultDescr;
        }
        public Int32 AddResultBasis(Int32 basis) { 
            ResultBasis += basis;
            return ResultBasis;
        }
        public Int32 SetResultBasis(Int32 basis) { 
            ResultBasis = basis;
            return ResultBasis;
        }
        public Int32 AddResultValue(Int32 value) { 
            ResultValue += value;
            return ResultValue;
        }
        public Int32 SetResultValue(Int32 value) { 
            ResultValue = value;
            return ResultValue;
        }
    }
}
