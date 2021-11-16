using HraveMzdy.Legalios.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Operations
{
    class OperationsPeriod
    {
        public const Byte TERM_BEG_FINISHED = 32;

        public const Byte TERM_END_FINISHED = 0;

        public const int WEEKSUN_SUNDAY = 0;

        public const int WEEKMON_SUNDAY = 7;

        public const Int32 TIME_MULTIPLY_SIXTY = 60;

        public const Int16 WEEKDAYS_COUNT = 7;

        public static Byte DateFromInPeriod(IPeriod period, DateTime? dateFrom)
        {
            Byte dayTermFrom = TERM_BEG_FINISHED;

            DateTime periodDateBeg = new DateTime(period.Year, period.Month, 1);

            if (dateFrom != null)
            {
                dayTermFrom = (Byte)dateFrom.Value.Day;
            }

            if (dateFrom == null || dateFrom < periodDateBeg)
            {
                dayTermFrom = (Byte)1;
            }
            return dayTermFrom;
        }

        public static Byte DateStopInPeriod(IPeriod period, DateTime? dateEnds)
        {
            Byte dayTermEnd = TERM_END_FINISHED;
            Int16 daysPeriod = (Int16)DateTime.DaysInMonth(period.Year, period.Month);

            DateTime periodDateEnd = new DateTime(period.Year, period.Month, (int)daysPeriod);

            if (dateEnds != null)
            {
                dayTermEnd = (Byte)dateEnds.Value.Day;
            }

            if (dateEnds == null || dateEnds > periodDateEnd)
            {
                dayTermEnd = (Byte)daysPeriod;
            }
            return dayTermEnd;
        }
    }
}
