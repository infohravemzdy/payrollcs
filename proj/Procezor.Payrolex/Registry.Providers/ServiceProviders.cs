using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;
using ResultMonad;

namespace Procezor.Payrolex.Registry.Providers
{
    class PayrolexConceptSpec : ConceptSpec
    {
        public const Int32 VALUE_ZERO = 0;
        public const Int32 BASIS_ZERO = 0;
        public const string DESCRIPTION_EMPTY = "result from input value";

        public static readonly UInt16 TERM_BEG_FINISHED = 32;
        public static readonly UInt16 TERM_END_FINISHED = 0;
        public PayrolexConceptSpec(Int32 code) : base(code)
        {
        }
        public static Result<T, ITermResultError> GetContractResult<T>(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results, ContractCode contract, ArticleCode article)
            where T : class, ITermResult
        {
            var resultRest = results.Where((x) => (x.IsSuccess && x.Value.Contract.Equals(contract) && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(Result.Fail<ITermResult, ITermResultError>(ExtractResultError.CreateError(period, target, target, null, "Result Instance Not Found")))
                .First();

            if (resultRest.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultRest.Error);
            }
            if (resultRest.Value == null)
            {
                var error = ExtractResultError.CreateError(period, target, target, null, "Result Instance Found Null");
                return Result.Fail<T, ITermResultError>(error);
            }
            T resultType = resultRest.Value as T;
            if (resultType == null)
            {
                var error = ExtractResultError.CreateError(period, target, target, null, "Result Instance Bad Type");
                return Result.Fail<T, ITermResultError>(error);
            }
            return Result.Ok<T, ITermResultError>(resultType);
        }
    }

    public class PayrolexTermTarget : TermTarget
    {
        public const Int32 BASIS_ZERO = 0;
        public const string DESCRIPTION_EMPTY = "result from input value";
        public PayrolexTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 basis, string descr) :
            base(monthCode, contract, position, variant, article, concept, basis, descr)
        {
        }
        public PayrolexTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept)
        {
        }
        public override string ArticleDescr()
        {
            return ServiceArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ServiceConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }

    public class PayrolexTermResult : TermResult
    {
        public const Int32 VALUE_ZERO = 0;
        public const Int32 BASIS_ZERO = 0;
        public const string DESCRIPTION_EMPTY = "result from input value";

        public static readonly UInt16 TERM_BEG_FINISHED = 32;
        public static readonly UInt16 TERM_END_FINISHED = 0;
        public PayrolexTermResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public override string ArticleDescr()
        {
            return ServiceArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ServiceConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }
}
