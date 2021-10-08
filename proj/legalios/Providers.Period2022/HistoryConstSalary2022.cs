using System;
using HraveMzdy.Legalios.Providers.Period2021;

namespace HraveMzdy.Legalios.Providers.Period2022
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2022
    {
        public const Int16 VERSION_CODE = 2022;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2021.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2021.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = HistoryConstSalary2021.MIN_MONTHLY_WAGE;
        public const Int32 MIN_HOURLY_WAGE = HistoryConstSalary2021.MIN_HOURLY_WAGE;
    }
}
