using System;
using HraveMzdy.Legalios.Providers.Period2012;

namespace HraveMzdy.Legalios.Providers.Period2013
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2013var08
    {
        public const Int32 MIN_MONTHLY_WAGE = 8500; // 8000
        public const Int32 MIN_HOURLY_WAGE = 5060; // 4810
    }
    class HistoryConstSalary2013
    {
        public const Int16 VERSION_CODE = 2013;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2012.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2012.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = HistoryConstSalary2012.MIN_MONTHLY_WAGE;
        public const Int32 MIN_HOURLY_WAGE = HistoryConstSalary2012.MIN_HOURLY_WAGE;
    }
}
