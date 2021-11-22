﻿using System;
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
        public static Result<T, ITermResultError> GetResult<T>(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results, ArticleCode article)
            where T : class, ITermResult
        {
            var notFoundError = NoResultFoundError<ITermResult>.CreateResultError(period, target, 
                ServiceArticleEnumUtils.GetSymbol(article.Value));
            var resultRest = results.Where((x) => (x.IsSuccess && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(notFoundError).First();

            if (resultRest.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultRest.Error);
            }
            if (resultRest.Value == null)
            {
                return NullResultFoundError<T>.CreateResultError(period, target, ServiceArticleEnumUtils.GetSymbol(article.Value));
            }
            var resultType = GetTypedResult<T>(resultRest.Value, target, period);
            if (resultType.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultType.Error);
            }
            return Result.Ok<T, ITermResultError>(resultType.Value);
        }
        public static Result<T, ITermResultError> GetContractResult<T>(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results, ContractCode contract, ArticleCode article)
            where T : class, ITermResult
        {
            var notFoundError = NoResultFoundError<ITermResult>.CreateResultError(period, target, 
                ServiceArticleEnumUtils.GetSymbol(article.Value), contract);
            var resultRest = results.Where((x) => (x.IsSuccess 
                && x.Value.Contract.Equals(contract) 
                && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(notFoundError).First();

            if (resultRest.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultRest.Error);
            }
            if (resultRest.Value == null)
            {
                return NullResultFoundError<T>.CreateResultError(period, target, ServiceArticleEnumUtils.GetSymbol(article.Value), contract);
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
            var notFoundError = NoResultFoundError<ITermResult>.CreateResultError(period, target, 
                ServiceArticleEnumUtils.GetSymbol(article.Value), contract, position);
            var resultRest = results.Where((x) => (x.IsSuccess 
                && x.Value.Contract.Equals(contract) 
                && x.Value.Position.Equals(position) 
                && x.Value.Article.Equals(article)))
                .DefaultIfEmpty(notFoundError).First();

            if (resultRest.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultRest.Error);
            }
            if (resultRest.Value == null)
            {
                return NullResultFoundError<T>.CreateResultError(period, target, ServiceArticleEnumUtils.GetSymbol(article.Value), contract, position);
            }
            var resultType = GetTypedResult<T>(resultRest.Value, target, period);
            if (resultType.IsFailure)
            {
                return Result.Fail<T, ITermResultError>(resultType.Error);
            }
            return Result.Ok<T, ITermResultError>(resultType.Value);
        }
        public static ResultWithError<ITermResultError> GetFailedOrOk(params ResultWithError<ITermResultError>[] results)
        {
            return results.FirstOrDefault((x) => x.IsFailure);
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
        public PayrolexTermResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
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

    public static class ResultErrorExtensions
    {
        public static ResultWithError<E> ErrOrOk<T, E>(this Result<T, E> self)
            where E : class, ITermResultError
            where T : class, ITermResult
        {
            if (self.IsFailure)
            {
                return ResultWithError.Fail<E>(self.Error);
            }
            return ResultWithError.Ok<E>();
        }

    }
}
