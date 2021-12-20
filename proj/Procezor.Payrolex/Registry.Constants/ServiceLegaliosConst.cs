using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Procezor.Payrolex.Registry.Constants
{
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
    public enum TaxDeclBenfOption : UInt16
    {
        DECL_TAX_BENEF0 = 0,
        DECL_TAX_BENEF1 = 1,
    };
    public enum TaxDeclDisabOption : UInt16
    {
        DECL_TAX_BENEF0 = 0,
        DECL_TAX_DISAB1 = 1,
        DECL_TAX_DISAB2 = 2,
        DECL_TAX_DISAB3 = 3,
    };
    public enum WorkScheduleType : UInt16
    {
        SCHEDULE_NORMALY_WEEK = 0,
        SCHEDULE_SPECIAL_WEEK = 1,
        SCHEDULE_SPECIAL_TURN = 2,
        SCHEDULE_NONEDAY_WORK = 9,
    };
}
