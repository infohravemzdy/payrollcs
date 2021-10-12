using System;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class TermTarget : TermSymbol, ITermTarget
    {
        public TermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 basis, string descr) :
            base(monthCode, contract, position, variant, article)
        {
            Concept = concept;
            TargetBasis = basis;
            TargetDescr = descr;
        }
        public TermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article)
        {
            Concept = concept;
            TargetBasis = 0;
            TargetDescr = "";
        }

        public ConceptCode Concept { get; private set; }
        public Int32 TargetBasis { get; private set; }
        public string TargetDescr { get; private set; }
        public string ArticleEnumDescr<EA>() where EA : struct, Enum
        {
            return EnumConstUtils<EA>.GetSymbol(Article.Value);
        }
        public string ConceptEnumDescr<EC>() where EC : struct, Enum
        {
            return EnumConstUtils<EC>.GetSymbol(Concept.Value);
        }
        public IArticleDefine Defs()
        {
            return new ArticleDefine(Article.Value, Concept.Value);
        }
        public virtual string ArticleDescr()
        {
            return "";
        }
        public virtual string ConceptDescr()
        {
            return "";
        }
    }
}
