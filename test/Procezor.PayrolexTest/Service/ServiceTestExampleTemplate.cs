using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using HraveMzdy.Legalios.Service;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;
using HraveMzdy.Procezor.Payrolex.Service;
using Procezor.PayrolexTest.Examples;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Providers;
using System.IO;

namespace Procezor.PayrolexTest.Service
{
    public class ServiceTestExampleTemplate
    {
#if __MACOS__
        public const string PROTOKOL_TEST_FOLDER = "../../../test_import";
#else
        public const string PROTOKOL_TEST_FOLDER = "..\\..\\..\\test_import";
#endif
        public const string PROTOKOL_FOLDER_NAME = "test_import";
        public const string PARENT_PROTOKOL_FOLDER_NAME = "Procezor.PayrolexTest";

        protected const string TestFolder = PROTOKOL_TEST_FOLDER;

        public ServiceTestExampleTemplate(ITestOutputHelper output)
        {
            this.output = output;

            this._sut = new ServicePayrolex();
            this._leg = new ServiceLegalios();
        }
        public static IPeriod PrevYear(IPeriod period)
        {
            return new Period(period.Year - 1, period.Month);
        }
        public static IBundleProps CurrYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(period);
            return legResult.Value;
        }
        public static IBundleProps PrevYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(PrevYear(period));
            return legResult.Value;
        }

        protected static StreamWriter CreateProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Create();
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static StreamWriter OpenProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Open(FileMode.Append, FileAccess.Write);
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static void ExportPropsStart(StreamWriter protokol)
        {
        }

        protected static void ExportPropsEnd(StreamWriter protokol)
        {
        }

        protected readonly ITestOutputHelper output;

        protected readonly IServiceProcezor _sut;
        protected readonly IServiceLegalios _leg;

        protected ITermResult GetResultArticle<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode)
            where T : class, ITermResult
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault() as T;
            return resultValue;
        }
        protected string GetResultValue(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode)
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault();
            if (resultValue == null)
            {
                return "";
            }
            return resultValue.ResultValue.ToString();
        }
        protected string GetResultSelect<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault() as T;
            if (resultValue == null)
            {
                return "";
            }
            return selVal(resultValue).ToString();
        }
        protected string GetResultSelectSum<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            Int32 resultInit = default;
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.Select((c) => (c as T))
                .Aggregate(resultInit, (agr, x) => (agr + selVal(x)));
            return resultValue.ToString();
        }
        protected string GetResultSelect<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode, string prepText, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            Int32 resultSumValue = default;
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault() as T;
            if (resultValue != null)
            {
                resultSumValue += selVal(resultValue);
            }
            if (string.IsNullOrEmpty(prepText)==false)
            {
                return prepText + resultSumValue.ToString();
            }
            return resultSumValue.ToString();
        }
        protected string GetResultSelect<T1, T2>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode1, PayrolexArticleConst artCode2, Func<T1, Int32> selVal1, Func<T2, Int32> selVal2)
            where T1 : class, ITermResult
            where T2 : class, ITermResult
        {
            Int32 resultSumValue = default;
            var result1 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode1)).Select((x) => (x.Value)).ToList();
            var resultValue1 = result1.FirstOrDefault() as T1;
            if (resultValue1 != null)
            {
                resultSumValue += selVal1(resultValue1);
            }
            var result2 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode2)).Select((x) => (x.Value)).ToList();
            var resultValue2 = result2.FirstOrDefault() as T2;
            if (resultValue2 != null)
            {
                resultSumValue += selVal2(resultValue2);
            }
            return resultSumValue.ToString();
        }

        protected Int32 GetIntResultValue(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode)
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault();
            if (resultValue == null)
            {
                return 0;
            }
            return resultValue.ResultValue;
        }
        protected Int32 GetIntResultSelect<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault() as T;
            if (resultValue == null)
            {
                return 0;
            }
            return selVal(resultValue);
        }
        protected Int32 GetIntResultSelectSum<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            Int32 resultInit = default;
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.Select((c) => (c as T))
                .Aggregate(resultInit, (agr, x) => (agr + selVal(x)));
            return resultValue;
        }
        protected Int32 GetIntResultSelect<T1, T2>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, PayrolexArticleConst artCode1, PayrolexArticleConst artCode2, Func<T1, Int32> selVal1, Func<T2, Int32> selVal2)
            where T1 : class, ITermResult
            where T2 : class, ITermResult
        {
            Int32 resultSumValue = default;
            var result1 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode1)).Select((x) => (x.Value)).ToList();
            var resultValue1 = result1.FirstOrDefault() as T1;
            if (resultValue1 != null)
            {
                resultSumValue += selVal1(resultValue1);
            }
            var result2 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode2)).Select((x) => (x.Value)).ToList();
            var resultValue2 = result2.FirstOrDefault() as T2;
            if (resultValue2 != null)
            {
                resultSumValue += selVal2(resultValue2);
            }
            return resultSumValue;
        }

        protected Int32 GetIntResultContractValue(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, Int32 contract, PayrolexArticleConst artCode)
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault((x) => (x.Contract.Value == contract));
            if (resultValue == null)
            {
                return 0;
            }
            return resultValue.ResultValue;
        }
        protected Int32 GetIntResultContractSelect<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, Int32 contract, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.FirstOrDefault((x) => (x.Contract.Value == contract)) as T;
            if (resultValue == null)
            {
                return 0;
            }
            return selVal(resultValue);
        }
        protected Int32 GetIntResultContractSelectSum<T>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, Int32 contract, PayrolexArticleConst artCode, Func<T, Int32> selVal)
            where T : class, ITermResult
        {
            Int32 resultInit = default;
            var result = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode)).Select((x) => (x.Value)).ToList();
            var resultValue = result.Where((x) => (x.Contract.Value == contract))
                .Select((c) => (c as T))
                .Aggregate(resultInit, (agr, x) => (agr + selVal(x)));
            return resultValue;
        }
        protected Int32 GetIntResultContractSelect<T1, T2>(IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> res, Int32 contract, PayrolexArticleConst artCode1, PayrolexArticleConst artCode2, Func<T1, Int32> selVal1, Func<T2, Int32> selVal2)
            where T1 : class, ITermResult
            where T2 : class, ITermResult
        {
            Int32 resultSumValue = default;
            var result1 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode1)).Select((x) => (x.Value)).ToList();
            var resultValue1 = result1.FirstOrDefault((x) => (x.Contract.Value == contract)) as T1;
            if (resultValue1 != null)
            {
                resultSumValue += selVal1(resultValue1);
            }
            var result2 = res.Where((e) => (e.IsSuccess && e.Value.Article.Value == (Int32)artCode2)).Select((x) => (x.Value)).ToList();
            var resultValue2 = result2.FirstOrDefault((x) => (x.Contract.Value == contract)) as T2;
            if (resultValue2 != null)
            {
                resultSumValue += selVal2(resultValue2);
            }
            return resultSumValue;
        }
#region __GENERATOR_FUNC__
        protected string GetExamplePracResultsLine(ExampleGenerator example, IPeriod period, IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> results)
        {
            Int32 TAXING_INCOME_SUBJECT = GetIntResultSelect<TaxingIncomeSubjectResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT, (x) => (x.ResultValue));//TAXING_INCOME_SUBJECT,	15000
            Int32 TAXING_INCOME_HEALTH_RAW = GetIntResultSelect<TaxingIncomeHealthResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH, (x) => (x.ResultBasis));//TAXING_INCOME_HEALTH_RAW,	X
            Int32 TAXING_INCOME_HEALTH_FIX = GetIntResultSelect<TaxingIncomeHealthResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH, (x) => (x.ResultValue));//TAXING_INCOME_HEALTH_FIX,	X
            Int32 TAXING_INCOME_SOCIAL_RAW = GetIntResultSelect<TaxingIncomeSocialResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL, (x) => (x.ResultBasis));//TAXING_INCOME_SOCIAL_RAW,	X
            Int32 TAXING_INCOME_SOCIAL_FIX = GetIntResultSelect<TaxingIncomeSocialResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL, (x) => (x.ResultValue));//TAXING_INCOME_SOCIAL_FIX,	X
            Int32 TAXING_DECLARE_SIGNING = GetIntResultSelect<TaxingSigningResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_SIGNING, (x) => (x.DeclSignValue()));// TAXING_SIGNING,	1
            Int32 TAXING_DECLARE_NONSIGN = GetIntResultSelect<TaxingSigningResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_SIGNING, (x) => (x.NoneSignValue()));// TAXING_SIGNING_NONE,	0
            Int32 TAXING_ADVANCES_INCOME = GetIntResultSelect<TaxingAdvancesIncomeResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_INCOME, (x) => (x.ResultValue));// TAXING_ADVANCES_INCOME,	15000
            Int32 TAXING_ADVANCES_HEALTH = GetIntResultSelect<TaxingAdvancesHealthResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_HEALTH, (x) => (x.ResultValue));// TAXING_ADVANCES_HEALTH,	X
            Int32 TAXING_ADVANCES_SOCIAL = GetIntResultSelect<TaxingAdvancesSocialResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_SOCIAL, (x) => (x.ResultValue));// TAXING_ADVANCES_SOCIAL,	X
            Int32 TAXING_ADVANCES_BASIS_RAW = GetIntResultSelect<TaxingAdvancesBasisResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS, (x) => (x.ResultBasis));// TAXING_ADVANCES_BASIS_RAW,	21100
            Int32 TAXING_ADVANCES_BASIS_RND = GetIntResultSelect<TaxingAdvancesBasisResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS, (x) => (x.ResultValue));// TAXING_ADVANCES_BASIS_RND,	21100
            Int32 TAXING_SOLIDARY_BASIS = GetIntResultSelect<TaxingSolidaryBasisResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY_BASIS, (x) => (x.ResultValue));// TAXING_SOLIDARY_BASIS,	0
            Int32 TAXING_ADVANCES = GetIntResultSelect<TaxingAdvancesResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES, (x) => (x.ResultValue));// TAXING_ADVANCES,	X
            Int32 TAXING_SOLIDARY = GetIntResultSelect<TaxingSolidaryResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY, (x) => (x.ResultValue));// TAXING_SOLIDARY,	0
            Int32 TAXING_ADVANCES_TOTAL = GetIntResultSelect<TaxingAdvancesTotalResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL, (x) => (x.ResultValue));// TAXING_ADVANCES_TOTAL,	X
            Int32 TAXING_ALLOWANCE_PAYER = GetIntResultSelect<TaxingAllowancePayerResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_PAYER, (x) => (x.BenefitApplyResult()));// TAXING_ALLOWANCE_PAYER,	1, 2710
            Int32 TAXING_ALLOWANCE_PAYER_SUM = GetIntResultSelectSum<TaxingAllowancePayerResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_PAYER, (x) => (x.ResultValue));// TAXING_ALLOWANCE_PAYER_SUM,	1, 2710
            Int32 TAXING_ALLOWANCE_CHILD_ORD1 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyOrder1()));// TAXING_ALLOWANCE_CHILD_ORD1,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_ORD2 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyOrder2()));// TAXING_ALLOWANCE_CHILD_ORD2,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_ORD3 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyOrder3()));// TAXING_ALLOWANCE_CHILD_ORD3,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_DIS1 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyDisab1()));// TAXING_ALLOWANCE_CHILD_DIS1,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_DIS2 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyDisab2()));// TAXING_ALLOWANCE_CHILD_DIS2,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_DIS3 = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.BenefitApplyDisab3()));// TAXING_ALLOWANCE_CHILD_DIS3,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_CHILD_SUM = GetIntResultSelectSum<TaxingAllowanceChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD, (x) => (x.ResultValue));// TAXING_ALLOWANCE_CHILD_SUM,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
            Int32 TAXING_ALLOWANCE_DISAB_DIS1 = GetIntResultSelectSum<TaxingAllowanceDisabResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB, (x) => (x.BenefitApplyDisab1()));// TAXING_ALLOWANCE_DISAB_DIS1,	1, 0, 0, x
            Int32 TAXING_ALLOWANCE_DISAB_DIS2 = GetIntResultSelectSum<TaxingAllowanceDisabResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB, (x) => (x.BenefitApplyDisab2()));// TAXING_ALLOWANCE_DISAB_DIS2,	1, 0, 0, x
            Int32 TAXING_ALLOWANCE_DISAB_DIS3 = GetIntResultSelectSum<TaxingAllowanceDisabResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB, (x) => (x.BenefitApplyDisab3()));// TAXING_ALLOWANCE_DISAB_DIS3,	1, 0, 0, x
            Int32 TAXING_ALLOWANCE_DISAB_SUM = GetIntResultSelectSum<TaxingAllowanceDisabResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB, (x) => (x.ResultValue));// TAXING_ALLOWANCE_DISAB_SUM,	1, 0, 0, x
            Int32 TAXING_ALLOWANCE_STUDY = GetIntResultSelectSum<TaxingAllowanceStudyResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_STUDY, (x) => (x.BenefitApplyResult()));// TAXING_ALLOWANCE_STUDY,	1, x
            Int32 TAXING_ALLOWANCE_STUDY_SUM = GetIntResultSelect<TaxingAllowanceStudyResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_STUDY, (x) => (x.ResultValue));// TAXING_ALLOWANCE_STUDY_SUM, 1, x
            Int32 TAXING_REBATE_PAYER = GetIntResultSelectSum<TaxingRebatePayerResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER, (x) => (x.ResultValue));// TAXING_REBATE_PAYER,	X
            Int32 TAXING_REBATE_CHILD = GetIntResultSelectSum<TaxingRebateChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD, (x) => (x.ResultValue));// TAXING_REBATE_CHILD,	X
            Int32 TAXING_BONUS_CHILD_CAL = GetIntResultSelectSum<TaxingBonusChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_BONUS_CHILD, (x) => (x.ResultBasis));// TAXING_BONUS_CHILD_CAL,	X
            Int32 TAXING_BONUS_CHILD_PAY = GetIntResultSelectSum<TaxingBonusChildResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_BONUS_CHILD, (x) => (x.ResultValue));// TAXING_BONUS_CHILD_PAY,	X
            Int32 TAXING_WITHHOLD_INCOME = GetIntResultSelectSum<TaxingWithholdIncomeResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_INCOME, (x) => (x.ResultValue));// TAXING_WITHHOLD_INCOME,	0
            Int32 TAXING_WITHHOLD_HEALTH = GetIntResultSelectSum<TaxingWithholdHealthResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_HEALTH, (x) => (x.ResultValue));// TAXING_WITHHOLD_HEALTH,	0
            Int32 TAXING_WITHHOLD_SOCIAL = GetIntResultSelectSum<TaxingWithholdSocialResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_SOCIAL, (x) => (x.ResultValue));// TAXING_WITHHOLD_SOCIAL,	0
            Int32 TAXING_WITHHOLD_BASIS_RAW = GetIntResultSelectSum<TaxingWithholdBasisResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_BASIS, (x) => (x.ResultValue));// TAXING_WITHHOLD_BASIS_RAW,	0
            Int32 TAXING_WITHHOLD_BASIS_RND = GetIntResultSelectSum<TaxingWithholdBasisResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_BASIS, (x) => (x.ResultValue));// TAXING_WITHHOLD_BASIS_RND,	0
            Int32 TAXING_WITHHOLD_TOTAL = GetIntResultSelectSum<TaxingWithholdTotalResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_TOTAL, (x) => (x.ResultValue));// TAXING_WITHHOLD_TOTAL,	0
            Int32 TAXING_PAYM_ADVANCES = GetIntResultSelectSum<TaxingPaymAdvancesResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_PAYM_ADVANCES, (x) => (x.ResultValue));// TAXING_PAYM_ADVANCES,	X
            Int32 TAXING_PAYM_WITHHOLD = GetIntResultSelectSum<TaxingPaymWithholdResult>(results,
                    PayrolexArticleConst.ARTICLE_TAXING_PAYM_WITHHOLD, (x) => (x.ResultValue));// TAXING_PAYM_WITHHOLD,	X
            Int32 INCOME_GROSS = GetIntResultValue(results, PayrolexArticleConst.ARTICLE_INCOME_GROSS);// INCOME_GROSS,	X
            Int32 INCOME_NETTO = GetIntResultValue(results, PayrolexArticleConst.ARTICLE_INCOME_NETTO);// INCOME_NETTO,	X
            Int32 ELOYER_COSTS = GetIntResultValue(results, PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS);// ELOYER_COSTS,	X

            string[] resultLine = new string[]
            {
                example.Number,
                period.Code.ToString(),
                TAXING_INCOME_SUBJECT.ToString(),//TAXING_INCOME_SUBJECT,	15000
                TAXING_INCOME_HEALTH_RAW.ToString(),//TAXING_INCOME_HEALTH_RAW,	X
                TAXING_INCOME_HEALTH_FIX.ToString(),//TAXING_INCOME_HEALTH_FIX,	X
                TAXING_INCOME_SOCIAL_RAW.ToString(),//TAXING_INCOME_SOCIAL_RAW,	X
                TAXING_INCOME_SOCIAL_FIX.ToString(),//TAXING_INCOME_SOCIAL_FIX,	X
                TAXING_DECLARE_SIGNING.ToString(),// TAXING_SIGNING,	1
                TAXING_DECLARE_NONSIGN.ToString(),// TAXING_SIGNING_NONE,	0
                TAXING_ADVANCES_INCOME.ToString(),// TAXING_ADVANCES_INCOME,	15000
                TAXING_ADVANCES_HEALTH.ToString(),// TAXING_ADVANCES_HEALTH,	X
                TAXING_ADVANCES_SOCIAL.ToString(),// TAXING_ADVANCES_SOCIAL,	X
                TAXING_ADVANCES_BASIS_RAW.ToString(),// TAXING_ADVANCES_BASIS_RAW,	21100
                TAXING_ADVANCES_BASIS_RND.ToString(),// TAXING_ADVANCES_BASIS_RND,	21100
                TAXING_SOLIDARY_BASIS.ToString(),// TAXING_SOLIDARY_BASIS,	0
                TAXING_ADVANCES.ToString(),// TAXING_ADVANCES,	X
                TAXING_SOLIDARY.ToString(),// TAXING_SOLIDARY,	0
                TAXING_ADVANCES_TOTAL.ToString(),// TAXING_ADVANCES_TOTAL,	X
                TAXING_ALLOWANCE_PAYER.ToString(),// TAXING_ALLOWANCE_PAYER,	1, 2710
                TAXING_ALLOWANCE_PAYER_SUM.ToString(),// TAXING_ALLOWANCE_PAYER_SUM,	1, 2710
                TAXING_ALLOWANCE_CHILD_ORD1.ToString(),// TAXING_ALLOWANCE_CHILD_ORD1,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_ORD2.ToString(),// TAXING_ALLOWANCE_CHILD_ORD2,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_ORD3.ToString(),// TAXING_ALLOWANCE_CHILD_ORD3,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_DIS1.ToString(),// TAXING_ALLOWANCE_CHILD_DIS1,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_DIS2.ToString(),// TAXING_ALLOWANCE_CHILD_DIS2,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_DIS3.ToString(),// TAXING_ALLOWANCE_CHILD_DIS3,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_CHILD_SUM.ToString(),// TAXING_ALLOWANCE_CHILD_SUM,	Počet 1, 2, 3, Počet ZTP 1, 2, 3, x
                TAXING_ALLOWANCE_DISAB_DIS1.ToString(),// TAXING_ALLOWANCE_DISAB_DIS1,	1, 0, 0, x
                TAXING_ALLOWANCE_DISAB_DIS2.ToString(),// TAXING_ALLOWANCE_DISAB_DIS2,	1, 0, 0, x
                TAXING_ALLOWANCE_DISAB_DIS3.ToString(),// TAXING_ALLOWANCE_DISAB_DIS3,	1, 0, 0, x
                TAXING_ALLOWANCE_DISAB_SUM.ToString(),// TAXING_ALLOWANCE_DISAB_SUM,	1, 0, 0, x
                TAXING_ALLOWANCE_STUDY.ToString(),// TAXING_ALLOWANCE_STUDY,	1, x
                TAXING_ALLOWANCE_STUDY_SUM.ToString(),// TAXING_ALLOWANCE_STUDY_SUM, 1, x
                TAXING_REBATE_PAYER.ToString(),// TAXING_REBATE_PAYER,	X
                TAXING_REBATE_CHILD.ToString(),// TAXING_REBATE_CHILD,	X
                TAXING_BONUS_CHILD_CAL.ToString(),// TAXING_BONUS_CHILD_CAL,	X
                TAXING_BONUS_CHILD_PAY.ToString(),// TAXING_BONUS_CHILD_PAY,	X
                TAXING_WITHHOLD_INCOME.ToString(),// TAXING_WITHHOLD_INCOME,	0
                TAXING_WITHHOLD_HEALTH.ToString(),// TAXING_WITHHOLD_HEALTH,	0
                TAXING_WITHHOLD_SOCIAL.ToString(),// TAXING_WITHHOLD_SOCIAL,	0
                TAXING_WITHHOLD_BASIS_RAW.ToString(),// TAXING_WITHHOLD_BASIS_RAW,	0
                TAXING_WITHHOLD_BASIS_RND.ToString(),// TAXING_WITHHOLD_BASIS_RND,	0
                TAXING_WITHHOLD_TOTAL.ToString(),// TAXING_WITHHOLD_TOTAL,	0
                TAXING_PAYM_ADVANCES.ToString(),// TAXING_PAYM_ADVANCES,	X
                TAXING_PAYM_WITHHOLD.ToString(),// TAXING_PAYM_WITHHOLD,	X
                INCOME_GROSS.ToString(),// INCOME_GROSS,	X
                INCOME_NETTO.ToString(),// INCOME_NETTO,	X
                ELOYER_COSTS.ToString(),// ELOYER_COSTS,	X
            };

            string resultOutput = string.Join(";", resultLine);

            return resultOutput;
        }

        protected string[] GetExamplePPomResultsLine(ExampleGenerator example, IPeriod period, IEnumerable<ResultMonad.Result<ITermResult, HraveMzdy.Procezor.Service.Errors.ITermResultError>> results)
        {
           List<string> resultOutput = new List<string>();

            foreach (var con in example.ContractList)
            {              
                Int32 POSITION_WORK_PLAN = GetIntResultContractSelect<PositionWorkPlanResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN, (x) => (x.TotalRealWeeks())); //POSITION_WORK_PLAN,	40
                Int32 CONTRACT_TIME_PLAN = GetIntResultContractSelect<ContractTimePlanResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_CONTRACT_TIME_PLAN, (x) => (x.TotalTimeMonth()));//CONTRACT_TIME_PLAN,	184
                Int32 CONTRACT_TIME_WORK = GetIntResultContractSelect<ContractTimeWorkResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_CONTRACT_TIME_WORK, (x) => (x.TotalTimeMonth()));//CONTRACT_TIME_WORK,	184
                Int32 CONTRACT_TIME_ABSC = GetIntResultContractSelect<ContractTimeAbscResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_CONTRACT_TIME_ABSC, (x) => (x.TotalTimeMonth()));//CONTRACT_TIME_ABSC,	0
                Int32 PAYMENT_SALARY = GetIntResultContractSelect<PaymentBasisResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_PAYMENT_SALARY, (x) => (x.ResultBasis));//PAYMENT_SALARY,	15000
                Int32 PAYMENT_WORKED = GetIntResultContractSelect<PaymentFixedResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_PAYMENT_WORKED, (x) => (x.ResultBasis));//PAYMENT_WORKED,	0
                Int32 HEALTH_DECLARE_SUB = GetIntResultContractSelect<HealthDeclareResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_DECLARE, (x) => (x.InterestCode));//HEALTH_DECLARE_SUB,	subject
                Int32 HEALTH_DECLARE_MIN = GetIntResultContractSelect<HealthDeclareResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_DECLARE, (x) => (x.MandatorBase));//HEALTH_DECLARE_MIN,	minimum
                Int32 HEALTH_DECLARE_FOR = 0;//HEALTH_DECLARE_FOR,	zahraniční
                Int32 HEALTH_DECLARE_EHS = 0;//HEALTH_DECLARE_EHS,	eu
                Int32 HEALTH_DECLARE_PAR = GetIntResultContractSelect<HealthIncomeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_INCOME, (x) => (x.ParticeCode));//HEALTH_DECLARE_PAR,	účast
                Int32 HEALTH_INCOME = GetIntResultContractSelect<HealthIncomeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_INCOME, (x) => (x.ResultValue));//HEALTH_INCOME,	15000
                Int32 HEALTH_BASE = GetIntResultContractSelect<HealthPaymEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE, (x) => (x.TotalBasic()));//HEALTH_BASE,	15000
                Int32 HEALTH_BASE_ANNUALLY = 0;//,	extra
                Int32 HEALTH_BASE_EMPLOYEE = GetIntResultContractSelect<HealthBaseEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE, (x) => (x.ResultValue));//HEALTH_BASE_EMPLOYEE,	extra
                Int32 HEALTH_BASE_EMPLOYER = GetIntResultContractSelect<HealthBaseEmployerResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER, (x) => (x.ResultValue));//HEALTH_BASE_EMPLOYER,	extra
                Int32 HEALTH_BASE_MANDATE = GetIntResultContractSelect<HealthBaseMandateResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE, (x) => (x.ResultValue));//HEALTH_BASE_MANDATE,	0
                Int32 HEALTH_BASE_OVERCAP = GetIntResultContractSelect<HealthBaseOvercapResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP, (x) => (x.ResultValue));//HEALTH_BASE_OVERCAP,	0
                Int32 HEALTH_PAYM_EMPLOYEE = GetIntResultContractSelect<HealthPaymEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE, (x) => (x.ResultValue));//HEALTH_PAYM_EMPLOYEE,	X
                Int32 HEALTH_PAYM_EMPLOYER = GetIntResultContractSelect<HealthPaymEmployerResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYER, (x) => (x.ResultValue));//HEALTH_PAYM_EMPLOYER,	X
                Int32 SOCIAL_DECLARE_SUB = GetIntResultContractSelect<SocialDeclareResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE, (x) => (x.InterestCode));//SOCIAL_DECLARE_SUB,	1
                Int32 SOCIAL_DECLARE_ZMR = 0;//SOCIAL_DECLARE_ZMR,	Malý rozsah
                Int32 SOCIAL_DECLARE_KRZ = 0;//SOCIAL_DECLARE_KRZ,	Krátkodobé
                Int32 SOCIAL_DECLARE_FOR = 0;//SOCIAL_DECLARE_FOR,	zahraniční
                Int32 SOCIAL_DECLARE_EHS = 0;//SOCIAL_DECLARE_EHS,	eu
                Int32 SOCIAL_DECLARE_PAR = GetIntResultContractSelect<SocialIncomeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_INCOME, (x) => (x.ParticeCode));//SOCIAL_DECLARE_PAR,	účast
                Int32 SOCIAL_INCOME = GetIntResultContractSelect<SocialIncomeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_INCOME, (x) => (x.ResultValue));//SOCIAL_INCOME,	15000
                Int32 SOCIAL_BASE  = GetIntResultContractSelect<SocialPaymEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYEE, (x) => (x.TotalBasic()));//SOCIAL_BASE,	15000
                Int32 SOCIAL_BASE_ANNUALLY = 0;//SOCIAL_BASE_ANNUALLY,	extra
                Int32 SOCIAL_BASE_EMPLOYEE = GetIntResultContractSelect<SocialBaseEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE, (x) => (x.ResultValue));//SOCIAL_BASE_EMPLOYEE,	extra
                Int32 SOCIAL_BASE_EMPLOYER = GetIntResultContractSelect<SocialBaseEmployerResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYER, (x) => (x.ResultValue));//SOCIAL_BASE_EMPLOYER,	extra
                Int32 SOCIAL_BASE_OVERCAP = GetIntResultContractSelect<SocialBaseOvercapResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP, (x) => (x.ResultValue));//SOCIAL_BASE_OVERCAP,	0
                Int32 SOCIAL_PAYM_EMPLOYEE = GetIntResultContractSelect<SocialPaymEmployeeResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYEE, (x) => (x.ResultValue));//SOCIAL_PAYM_EMPLOYEE,	X
                Int32 SOCIAL_PAYM_EMPLOYER = GetIntResultContractSelect<SocialPaymEmployerResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYER, (x) => (x.ResultValue));//SOCIAL_PAYM_EMPLOYER,	X
                Int32 TAXING_DECLARE_SUB = GetIntResultContractSelect<TaxingDeclareResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_TAXING_DECLARE, (x) => (x.InterestCode));//TAXING_DECLARE_SUB,	1
                Int32 TAXING_INCOME_SUBJECT = GetIntResultContractSelect<TaxingIncomeSubjectResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT, (x) => (x.ResultValue));//TAXING_INCOME_SUBJECT,	15000
                Int32 TAXING_INCOME_HEALTH_RAW = GetIntResultContractSelect<TaxingIncomeHealthResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH, (x) => (x.ResultBasis));//TAXING_INCOME_HEALTH_RAW,	X
                Int32 TAXING_INCOME_SOCIAL_RAW = GetIntResultContractSelect<TaxingIncomeSocialResult>(results, con.Id,
                    PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL, (x) => (x.ResultBasis));//TAXING_INCOME_SOCIAL_RAW,	X

                string[] resultLine = new string[]
                {
                    example.Number,
                    con.Number(example.Number),
                    period.Code.ToString(),
                    con.TermChar(),
                    POSITION_WORK_PLAN.ToString(),//POSITION_WORK_PLAN,	40
                    CONTRACT_TIME_PLAN.ToString(),//CONTRACT_TIME_PLAN,	184
                    CONTRACT_TIME_WORK.ToString(),//CONTRACT_TIME_WORK,	184
                    CONTRACT_TIME_ABSC.ToString(),//CONTRACT_TIME_ABSC,	0
                    PAYMENT_SALARY.ToString(),//PAYMENT_SALARY,	15000
                    PAYMENT_WORKED.ToString(),//PAYMENT_AGRFIX,	0
                    HEALTH_DECLARE_SUB.ToString(),//HEALTH_DECLARE_SUB,	subject
                    HEALTH_DECLARE_MIN.ToString(),//HEALTH_DECLARE_MIN,	minimum
                    HEALTH_DECLARE_FOR.ToString(),//HEALTH_DECLARE_FOR,	zahraniční
                    HEALTH_DECLARE_EHS.ToString(),//HEALTH_DECLARE_EHS,	eu
                    HEALTH_DECLARE_PAR.ToString(),//HEALTH_DECLARE_PAR,	účast
                    HEALTH_INCOME.ToString(),//HEALTH_INCOME,	15000
                    HEALTH_BASE.ToString(),//HEALTH_BASE,	15000
                    HEALTH_BASE_ANNUALLY.ToString(),//,	extra
                    HEALTH_BASE_EMPLOYEE.ToString(),//HEALTH_BASE_EMPLOYEE,	extra
                    HEALTH_BASE_EMPLOYER.ToString(),//HEALTH_BASE_EMPLOYER,	extra
                    HEALTH_BASE_MANDATE.ToString(),//HEALTH_BASE_MANDATE,	0
                    HEALTH_BASE_OVERCAP.ToString(),//HEALTH_BASE_OVERCAP,	0
                    HEALTH_PAYM_EMPLOYEE.ToString(),//HEALTH_PAYM_EMPLOYEE,	X
                    HEALTH_PAYM_EMPLOYER.ToString(),//HEALTH_PAYM_EMPLOYER,	X
                    SOCIAL_DECLARE_SUB.ToString(),//SOCIAL_DECLARE_SUB,	1
                    SOCIAL_DECLARE_ZMR.ToString(),//SOCIAL_DECLARE_ZMR,	Malý rozsah
                    SOCIAL_DECLARE_KRZ.ToString(),//SOCIAL_DECLARE_KRZ,	Krátkodobé
                    SOCIAL_DECLARE_FOR.ToString(),//SOCIAL_DECLARE_FOR,	zahraniční
                    SOCIAL_DECLARE_EHS.ToString(),//SOCIAL_DECLARE_EHS,	eu
                    SOCIAL_DECLARE_PAR.ToString(),//SOCIAL_DECLARE_PAR,	účast
                    SOCIAL_INCOME.ToString(),//SOCIAL_INCOME,	15000
                    SOCIAL_BASE.ToString(),//SOCIAL_BASE,	15000
                    SOCIAL_BASE_ANNUALLY.ToString(),//SOCIAL_BASE_ANNUALLY,	extra
                    SOCIAL_BASE_EMPLOYEE.ToString(),//SOCIAL_BASE_EMPLOYEE,	extra
                    SOCIAL_BASE_EMPLOYER.ToString(),//SOCIAL_BASE_EMPLOYER,	extra
                    SOCIAL_BASE_OVERCAP.ToString(),//SOCIAL_BASE_OVERCAP,	0
                    SOCIAL_PAYM_EMPLOYEE.ToString(),//SOCIAL_PAYM_EMPLOYEE,	X
                    SOCIAL_PAYM_EMPLOYER.ToString(),//SOCIAL_PAYM_EMPLOYER,	X
                    TAXING_DECLARE_SUB.ToString(),//TAXING_DECLARE_SUB,	1
                    TAXING_INCOME_SUBJECT.ToString(),//TAXING_INCOME_SUBJECT,	15000
                    TAXING_INCOME_HEALTH_RAW.ToString(),//TAXING_INCOME_HEALTH_RAW,	X
                    TAXING_INCOME_SOCIAL_RAW.ToString(),//TAXING_INCOME_SOCIAL_RAW,	X
                };

                resultOutput.Add(string.Join(";", resultLine));
            }
            return resultOutput.ToArray();
        }

        protected static Func<ExampleGenerator, IPeriod, IBundleProps, IBundleProps, Int32> GenValue(Int32 val)
        {
            return (ExampleGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => (val);
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> ConValue(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => (val);
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MaxBonus()
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                return ruleset.SalaryProps.MinMonthlyWage + 2000;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MinZdrPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                return prevset.HealthProps.MinMonthlyBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MinZdr(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                return ruleset.HealthProps.MinMonthlyBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MaxZdrPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (prevset.HealthProps.MaxAnnualsBasis > 0)
                {
                    return prevset.HealthProps.MaxAnnualsBasis + val;
                }
                return ruleset.HealthProps.MaxAnnualsBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MaxZdr(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (ruleset.HealthProps.MaxAnnualsBasis > 0)
                {
                    return ruleset.HealthProps.MaxAnnualsBasis + val;
                }
                return prevset.HealthProps.MaxAnnualsBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MaxSocPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (prevset.SocialProps.MaxAnnualsBasis > 0)
                {
                    return prevset.SocialProps.MaxAnnualsBasis + val;
                }
                return ruleset.SocialProps.MaxAnnualsBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MaxSoc(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (ruleset.SocialProps.MaxAnnualsBasis > 0)
                {
                    return ruleset.SocialProps.MaxAnnualsBasis + val;
                }
                return prevset.SocialProps.MaxAnnualsBasis + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> SolTaxPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (prevset.TaxingProps.MarginIncomeOfSolidary > 0)
                {
                    return prevset.TaxingProps.MarginIncomeOfSolidary + val;
                }
                return ruleset.TaxingProps.MarginIncomeOfSolidary + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> SolTax(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                if (ruleset.TaxingProps.MarginIncomeOfSolidary > 0)
                {
                    return ruleset.TaxingProps.MarginIncomeOfSolidary + val;
                }
                return prevset.TaxingProps.MarginIncomeOfSolidary + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> SrazNepPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                return prevset.TaxingProps.MarginIncomeOfWithhold + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> SrazNep(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                return ruleset.TaxingProps.MarginIncomeOfWithhold + val;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastZdrPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.HealthProps.MarginIncomeAgr + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.HealthProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastZdr(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.HealthProps.MarginIncomeAgr + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.HealthProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.HealthProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastNemPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.SocialProps.MarginIncomeAgr + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastNem(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.SocialProps.MarginIncomeAgr + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastZdrEmpPrev(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return prevset.SocialProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
        protected static Func<ContractGenerator, IPeriod, IBundleProps, IBundleProps, Int32> UcastZdrEmp(Int32 val)
        {
            return (ContractGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => {
                switch (gen.Term)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        return ruleset.SocialProps.MarginIncomeEmp + val;
                }
                return 0;
            };
        }
#endregion
    }
}
