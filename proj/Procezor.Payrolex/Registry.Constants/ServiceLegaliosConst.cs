﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Procezor.Payrolex.Registry.Constants
{
    public enum WorkContractTerms : UInt16
    {
        WORKTERM_EMPLOYMENT_1 = 0,
        WORKTERM_CONTRACTER_A = 1,
        WORKTERM_CONTRACTER_T = 2,
        WORKTERM_PARTNER_STAT = 3,
        WORKTERM_UNKNOWN_TYPE = 9,
    };
    public enum WorkTaxingTerms : UInt16
    {
        TAXING_TERM_BY_CONTRACT = 0,
        TAXING_TERM_EMPLOYMENTS = 1,
        TAXING_TERM_AGREEM_TASK = 2,
        TAXING_TERM_STATUT_PART = 3,
    };
    public enum TaxDeclSignOption : UInt16
    {
        DECL_TAX_NO_SIGNED = 0,
        DECL_TAX_DO_SIGNED = 1,
    };
    public enum TaxNoneSignOption : UInt16
    {
        NOSIGN_TAX_WITHHOLD = 0,
        NOSIGN_TAX_ADVANCES = 1,
    };
    public enum WorkHealthTerms : UInt16
    {
        HEALTH_TERM_BY_CONTRACT = 0,
        HEALTH_TERM_EMPLOYMENTS = 1,
        HEALTH_TERM_AGREEM_WORK = 2,
        HEALTH_TERM_AGREEM_TASK = 3,
        HEALTH_TERM_NONE_EMPLOY = 4,
    };
    public enum WorkSocialTerms : UInt16
    {
        SOCIAL_TERM_BY_CONTRACT = 0,
        SOCIAL_TERM_EMPLOYMENTS = 1,
        SOCIAL_TERM_SMALLS_EMPL = 2,
        SOCIAL_TERM_SHORTS_MEET = 3,
        SOCIAL_TERM_SHORTS_DENY = 4,
    };
    public enum WorkScheduleType : UInt16
    {
        SCHEDULE_NORMALY_WEEK = 0,
        SCHEDULE_SPECIAL_WEEK = 1,
        SCHEDULE_SPECIAL_TURN = 2,
        SCHEDULE_NONEDAY_WORK = 9,
    };
}
