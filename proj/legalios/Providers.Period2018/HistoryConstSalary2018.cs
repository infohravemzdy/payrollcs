using System;
using HraveMzdy.Legalios.Providers.Period2017;

namespace HraveMzdy.Legalios.Providers.Period2018
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2018
    {
        public const Int16 VERSION_CODE = 2018;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2017.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2017.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = 12200;
        public const Int32 MIN_HOURLY_WAGE = 7320;
    }

}
