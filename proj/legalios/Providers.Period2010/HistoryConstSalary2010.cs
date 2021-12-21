using System;

namespace HraveMzdy.Legalios.Providers.Period2010
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2010
    {
        public const Int16 VERSION_CODE = 2010;

        public const Int32 WORKING_SHIFT_WEEK = 5;
        public const Int32 WORKING_SHIFT_TIME = 8;
        public const Int32 MIN_MONTHLY_WAGE = 8000;
        public const Int32 MIN_HOURLY_WAGE = 4810;
    }
}
