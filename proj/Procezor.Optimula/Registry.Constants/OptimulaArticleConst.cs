using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Constants
{
    public enum OptimulaArticleConst : Int32
    {
        ARTICLE_CONTRACT_TIME_PLAN,     // Full Timesheet Hours
        ARTICLE_CONTRACT_TIME_WORK,     // Work Timesheet Hours
        ARTICLE_PAYMENT_MSALARY,        // Base Salary
        ARTICLE_PAYMENT_MPERSON,        // Personal Allowance
        ARTICLE_PAYMENT_PREMIUM,        // Premium Bonus
        ARTICLE_PAYMENT_AGRWORK,        // Agreement Percent Limit
        ARTICLE_ALLOWCE_HOFFICE,        // HomeOffice Tariff
        ARTICLE_ALLOWCE_CLOTHES,        // Clothing Tarrif
        //ARTICLE_SETTLEMENT_ALLOWANCE,   // Settlement from allowance
        //ARTICLE_OVER_TIME,              // OverTimesheet Hours
        //ARTICLE_ABSENCE_TIME,           // Absence Timesheet Hours
        //ARTICLE_AVERAGE_PAY,            // Average Pay
        //ARTICLE_AGRWORK_TARIFF,         // Agreement Work Tariff
        //ARTICLE_OVER_WORKTIME,          // Overtime hours
        //ARTICLE_WEEKEND_WORKTIME,       // Weekend hours
        //ARTICLE_NIGHT_WORKTIME,         // Night hours
        //ARTICLE_FEAST_WORKTIME,         // Feast hours
        //ARTICLE_HOLIDAY_ABSENCE,        // Holiday absence hours
        //ARTICLE_BANKDAY_ABSENCE,        // Bank holiday absence hours
        //ARTICLE_EEOBSTRUCT_ABSENCE,     // Employee obstruction absence hours
        //ARTICLE_EROBSTRUCT_ABSENCE,     // Employer obstruction absence hours
        //ARTICLE_OVER_ALLOWANCE,         // Overtime allowance
        //ARTICLE_WEEKEND_ALLOWANCE,      // Weekend allowance
        //ARTICLE_NIGHT_ALLOWANCE,        // Night allowance
        //ARTICLE_FEAST_ALLOWANCE,        // Feast allowance
        //ARTICLE_HOLIDAY_COMPENS,        // Holiday absence compensation
        //ARTICLE_BANKDAY_COMPENS,        // Bank holiday absence compensation
        //ARTICLE_EEOBSTRUCT_COMPENS,     // Employee obstruction absence compensation
        //ARTICLE_EROBSTRUCT_COMPENS,     // Employer obstruction absence compensation
        //ARTICLE_SETTLEMENT_COMPENS,     // Settlement from compensation
    }
    public static class ServiceArticleExtensions
    {
        public static string GetSymbol(this OptimulaArticleConst article)
        {
            return article.ToString();
        }
    }
    class ServiceArticleEnumUtils : EnumConstUtils<OptimulaArticleConst>
    {
    }
}
