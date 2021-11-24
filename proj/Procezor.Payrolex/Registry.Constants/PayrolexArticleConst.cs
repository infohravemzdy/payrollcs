using HraveMzdy.Procezor.Registry.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Constants
{
    public enum PayrolexArticleConst : Int32
    {
        ARTICLE_CONTRACT_WORK_TERM,
        ARTICLE_POSITION_WORK_TERM,
        ARTICLE_POSITION_WORK_PLAN,
        ARTICLE_POSITION_TIME_PLAN,
        ARTICLE_POSITION_TIME_WORK,
        ARTICLE_POSITION_TIME_ABSC,
        ARTICLE_CONTRACT_TIME_PLAN,
        ARTICLE_CONTRACT_TIME_WORK,
        ARTICLE_CONTRACT_TIME_ABSC,
        ARTICLE_PAYMENT_SALARY,
        ARTICLE_PAYMENT_BONUS,
        ARTICLE_PAYMENT_BARTER,
        ARTICLE_ALLOWCE_HOFFICE,
        ARTICLE_HEALTH_DECLARE,
        ARTICLE_HEALTH_INCOME,
        ARTICLE_HEALTH_BASE,
        ARTICLE_HEALTH_BASE_EMPLOYEE,
        ARTICLE_HEALTH_BASE_EMPLOYER,
        ARTICLE_HEALTH_BASE_MANDATE,
        ARTICLE_HEALTH_BASE_OVERCAP,
        ARTICLE_HEALTH_PAYM_EMPLOYEE,
        ARTICLE_HEALTH_PAYM_EMPLOYER,
        ARTICLE_INCOME_GROSS,
        ARTICLE_INCOME_NETTO,
        ARTICLE_EMPLOYER_COSTS,
    }
    public static class ServiceArticleExtensions
    {
        public static string GetSymbol(this PayrolexArticleConst article)
        {
            return article.ToString();
        }
    }
    class ServiceArticleEnumUtils : EnumConstUtils<PayrolexArticleConst>
    {
    }
}
