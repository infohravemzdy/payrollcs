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
        public static Result<T, ITermResultError> GetTypedTarget<T>(ITermTarget target, IPeriod period)
            where T : class, ITermTarget
        {
            T targetType = target as T;
            if (targetType == null)
            {
                var error = InvalidTargetError.CreateError(period, target, typeof(T).Name);
                return Result.Fail<T, ITermResultError>(error);
            }
            return Result.Ok<T, ITermResultError>(targetType);
        }
        public static Result<T, ITermResultError> GetTypedResult<T>(ITermResult result, ITermTarget target, IPeriod period)
            where T : class, ITermResult
        {
            T resultType = result as T;
            if (resultType == null)
            {
                var error = InvalidResultError.CreateError(period, target, typeof(T).Name);
                return Result.Fail<T, ITermResultError>(error);
            }
            return Result.Ok<T, ITermResultError>(resultType);
        }
        public static Result<T, ITermResultError> GetContractResult<T>(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results, ContractCode contract, ArticleCode article)
            where T : class, ITermResult
        {
            var resultRest = results.Where((x) => (x.IsSuccess 
                && x.Value.Contract.Equals(contract) 
                && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(Result.Fail<ITermResult, ITermResultError>(
                    ExtractResultError.CreateError(period, target, target, null, 
                    $"Result for {ServiceArticleEnumUtils.GetSymbol(article.Value)}, contract={contract.Value} Not Found")))
                .First();

            if (resultRest.IsFailure)
            {
                var error = ExtractResultError.CreateError(period, target, target, resultRest.Error, "Failure found");
                return Result.Fail<T, ITermResultError>(error);
            }
            if (resultRest.Value == null)
            {
                var error = ExtractResultError.CreateError(period, target, target, null, "Result found but Instance is Null");
                return Result.Fail<T, ITermResultError>(error);
            }
            var resultType = GetTypedResult<T>(resultRest.Value, target, period);
            if (resultType.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultType.Error);
            }
            return Result.Ok<T, ITermResultError>(resultType.Value);
        }
        public static Result<T, ITermResultError> GetPositionResult<T>(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results, ContractCode contract, PositionCode position, ArticleCode article)
                where T : class, ITermResult
        {
            var resultRest = results.Where((x) => (x.IsSuccess 
                && x.Value.Contract.Equals(contract) 
                && x.Value.Position.Equals(position) 
                && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(Result.Fail<ITermResult, ITermResultError>(
                    ExtractResultError.CreateError(period, target, target, null,
                    $"Result for {ServiceArticleEnumUtils.GetSymbol(article.Value)}, contract={contract.Value}, position={position.Value} Not Found")))
                .First();

            if (resultRest.IsFailure)
            {
                var error = ExtractResultError.CreateError(period, target, target, resultRest.Error, "Failure found");
                return Result.Fail<T, ITermResultError>(error);
            }
            if (resultRest.Value == null)
            {
                var error = ExtractResultError.CreateError(period, target, target, null, "Result found but Instance is Null");
                return Result.Fail<T, ITermResultError>(error);
            }
            var resultType = GetTypedResult<T>(resultRest.Value, target, period);
            if (resultType.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultType.Error);
            }
            return Result.Ok<T, ITermResultError>(resultType.Value);
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
