using System;
using HraveMzdy.Legalios.Providers.Period2015;

namespace HraveMzdy.Legalios.Providers.Period2016
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2016
    {
        public const Int16 VERSION_CODE = 2016;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2015.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2015.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = 9900; // 9300
        public const Int32 MIN_HOURLY_WAGE = 5870; // 5510
    }
}
