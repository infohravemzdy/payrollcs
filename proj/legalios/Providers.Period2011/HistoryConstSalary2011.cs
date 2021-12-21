﻿using HraveMzdy.Legalios.Providers.Period2010;
using System;

namespace HraveMzdy.Legalios.Providers.Period2011
{
    // WORKING_SHIFT_WEEK      Počet pracovních dnů v týdnu
    //
    // WORKING_SHIFT_TIME      Počet pracovních hodin denně
    //
    // MIN_MONTHLY_WAGE        Minimální mzda měsíční
    //
    // MIN_HOURLY_WAGE         Minimální mzda hodinová (100*Kč)
    class HistoryConstSalary2011
    {
        public const Int16 VERSION_CODE = 2011;

        public const Int32 WORKING_SHIFT_WEEK = HistoryConstSalary2010.WORKING_SHIFT_WEEK;
        public const Int32 WORKING_SHIFT_TIME = HistoryConstSalary2010.WORKING_SHIFT_TIME;
        public const Int32 MIN_MONTHLY_WAGE = HistoryConstSalary2010.MIN_MONTHLY_WAGE;
        public const Int32 MIN_HOURLY_WAGE = HistoryConstSalary2010.MIN_HOURLY_WAGE;
    }
}
