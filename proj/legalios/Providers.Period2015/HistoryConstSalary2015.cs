using System;
using HraveMzdy.Legalios.Providers.Period2014;

namespace HraveMzdy.Legalios.Providers.Period2015
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2015
    {
        public const Int16 VERSION_CODE = 2015;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2014.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2014.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = 9200; // 8000
        public const Int32 MIN_HOURLY_WAGE = 5500; // 4810
    }
}
