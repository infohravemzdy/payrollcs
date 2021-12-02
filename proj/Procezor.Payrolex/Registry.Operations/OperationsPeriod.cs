using HraveMzdy.Legalios.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Procezor.Payrolex.Registry.Operations
{
    public static class OperationsPeriod
    {
        public const Byte TERM_BEG_FINISHED = 32;

        public const Byte TERM_END_FINISHED = 0;

        public const int WEEKSUN_SUNDAY = 0;

        public const int WEEKMON_SUNDAY = 7;

        public const Int32 TIME_MULTIPLY_SIXTY = 60;

        public const Int16 WEEKDAYS_COUNT = 7;

        public static Int32[] EmptyMonthSchedule()
        {
            return new Int32[31] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public static Int32 TotalWeeksHours(Int32[] template)
        {
            Int32 result = template.Take(7).Aggregate(0, (agr, x) => (agr + x));

            return result;
        }
        public static Int32 TotalMonthHours(Int32[] template)
        {
            Int32 result = template.Take(31).Aggregate(0, (agr, x) => (agr + x));

            return result;
        }
        public static Int16 DaysInMonth(IPeriod period)
        {
            return (Int16)DateTime.DaysInMonth(period.Year, period.Month);
        }
        public static DateTime DateOfMonth(IPeriod period, Int16 dayOrdinal)
        {
            Int16 periodDay = Math.Min(Math.Max((Int16)1, dayOrdinal), DaysInMonth(period));

            return new DateTime(period.Year, period.Month, periodDay);
        }
        public static int DayOfWeekMonToSun(int periodDateCwd)
        {
            // DayOfWeek Sunday = 0,
            // Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, 
            if (periodDateCwd == WEEKSUN_SUNDAY)
            {
                return WEEKMON_SUNDAY;
            }
            else
            {
                return periodDateCwd;
            }
        }
        private static int DayOfWeekFromOrdinal(int dayOrdinal, int periodBeginCwd)
        {
            // dayOrdinal 1..31
            // periodBeginCwd 1..7
            // dayOfWeek 1..7

            int dayOfWeek = (((dayOrdinal - 1) + (periodBeginCwd - 1)) % 7) + 1;

            return dayOfWeek;
        }

        public static int WeekDayOfMonth(IPeriod period, Int16 dayOrdinal)
        {
            DateTime periodDate = DateOfMonth(period, dayOrdinal);

            int periodDateCwd = (int)periodDate.DayOfWeek;

            return DayOfWeekMonToSun(periodDateCwd);
        }
        public static Byte DateFromInPeriod(IPeriod period, DateTime? dateFrom)
        {
            Byte dayTermFrom = TERM_BEG_FINISHED;

            DateTime periodDateBeg = new(period.Year, period.Month, 1);

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
            Int16 daysPeriod = DaysInMonth(period);

            DateTime periodDateEnd = new(period.Year, period.Month, (int)daysPeriod);

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
        public static Int32[] TimesheetWeekSchedule(IPeriod period, Int32 secondsWeekly, Byte workdaysWeekly)
        {
            Int32 secondsDaily = (secondsWeekly / Math.Min(workdaysWeekly, WEEKDAYS_COUNT));

            Int32 secRemainder = secondsWeekly - (secondsDaily * workdaysWeekly);

            Int32[] weekSchedule = Enumerable.Range(1, 7).
                Select((x) => (WeekDaySeconds(x, workdaysWeekly, secondsDaily, secRemainder))).ToArray();

            return weekSchedule;
        }
        private static Int32 WeekDaySeconds(int dayOrdinal, int daysOfWork, Int32 secondsDaily, Int32 secRemainder)
        {
            if (dayOrdinal < daysOfWork)
            {
                return secondsDaily;
            }
            else if (dayOrdinal == daysOfWork)
            {
                return secondsDaily + secRemainder;
            }
            return (0);
        }
        public static Int32[] TimesheetFullSchedule(IPeriod period, Int32[] weekSchedule)
        {
            int periodDaysCount = DaysInMonth(period);

            int periodBeginCwd = WeekDayOfMonth(period, 1);

            Int32[] monthSchedule = Enumerable.Range(1, periodDaysCount).
                Select((x) => (SecondsFromWeekSchedule(weekSchedule, x, periodBeginCwd))).ToArray();

            return monthSchedule;
        }
        public static Int32[] TimesheetWorkSchedule(Int32[] monthSchedule, Byte dayTermFrom, Byte dayTermStop)
        {
            Int32[] timeSheet = monthSchedule.Select((x, i) => (HoursFromCalendar(dayTermFrom, dayTermStop, (Byte)i, x))).ToArray();

            return timeSheet;
        }
        public static Int32[] TimesheetWorkContract(Int32[] monthContract, Int32[] monthPosition, Byte dayTermFrom, Byte dayTermStop)
        {
            int idxFrom = (dayTermFrom - 1);
            int idxStop = (dayTermStop - 1);
            var zipedMonth = monthContract.Zip(monthPosition);
            Int32[] result = zipedMonth.Select((z, idx) =>
            {
                int res = 0;
                if (idx >= idxFrom && idx <= idxStop)
                {
                    res = (z.First + z.Second);
                }
                return res;
            }).ToArray();
            return result;
        }
        private static Int32 SecondsFromPeriodWeekSchedule(IPeriod period, Int32[] weekSchedule, int dayOrdinal)
        {
            int periodBeginCwd = WeekDayOfMonth(period, 1);

            return SecondsFromWeekSchedule(weekSchedule, dayOrdinal, periodBeginCwd);
        }
        private static Int32 SecondsFromWeekSchedule(Int32[] weekSchedule, int dayOrdinal, int periodBeginCwd)
        {
            int dayOfWeek = DayOfWeekFromOrdinal(dayOrdinal, periodBeginCwd);

            int indexWeek = (dayOfWeek - 1);

            if (indexWeek < 0 || indexWeek >= weekSchedule.Length)
            {
                return 0;
            }
            return weekSchedule[indexWeek];
        }

        private static Int32 SecondsFromScheduleSeq(Int32[] timeTable, int dayOrdinal, uint dayFromOrd, uint dayEndsOrd)
        {
            if (dayOrdinal < dayFromOrd || dayOrdinal > dayEndsOrd)
            {
                return 0;
            }

            int indexTable = (dayOrdinal - (Int32)dayFromOrd);

            if (indexTable < 0 || indexTable >= timeTable.Length)
            {
                return 0;
            }

            return timeTable[indexTable];
        }
        public static Int32[] ScheduleBaseSubtract(Int32[] template, Int32[] subtract, Byte dayFrom, Byte dayStop)
        {
            int idxFrom = (dayFrom - 1);
            int idxStop = (dayStop - 1);
            var zipedWorkAbsc = template.Zip(subtract);
            Int32[] result = zipedWorkAbsc.Select((z, idx) =>
            {
                int res = 0;
                if (idx >= idxFrom && idx <= idxStop)
                {
                    res = Math.Max(0, z.First - z.Second);
                }
                return res;
            }).ToArray();
            return result;
        }
        private static Int32 PLusHoursFromCalendar(Byte dayTermFrom, Byte dayTermStop, Byte dayIndex, Int32 partSeconds, Int32 workSeconds)
        {
            Byte dayOrdinal = (Byte)(dayIndex + 1);

            Int32 plusSeconds = workSeconds;

            if (dayTermFrom > dayOrdinal)
            {
                plusSeconds = 0;
            }
            if (dayTermStop < dayOrdinal)
            {
                plusSeconds = 0;
            }
            return plusSeconds + partSeconds;
        }
        private static Int32 HoursFromCalendar(Byte dayTermFrom, Byte dayTermStop, Byte dayIndex, Int32 workSeconds)
        {
            Byte dayOrdinal = (Byte)(dayIndex + 1);

            Int32 workingDay = workSeconds;

            if (dayTermFrom > dayOrdinal)
            {
                workingDay = 0;
            }
            if (dayTermStop < dayOrdinal)
            {
                workingDay = 0;
            }
            return workingDay;
        }
        public static Decimal SalaryAmountScheduleWork(Decimal amountMonthly,
            Int32 fullWeekHour, Int32 workWeekHours,
            Int32 fulltimeHour, Int32 workingsHours)
        {
            decimal coeffSalary = OperationsDec.Divide(workWeekHours, fullWeekHour); // 1.0m;

            decimal salaryValue = MonthlyAmountWithWorkingHours(amountMonthly, coeffSalary, fulltimeHour, workingsHours);

            return salaryValue;
        }
        public static Decimal SalaryAmountFixedValue(Decimal amountFixed)
        {
            decimal paymentValue = RoundingPay.PaymentFromFixedAmount(amountFixed);

            return RoundingDec.RoundUp(paymentValue);
        }
        public static decimal FactorizeAmount(decimal amount, decimal factor)
        {
            decimal result = OperationsDec.Multiply(amount, factor);

            return result;
        }
        public static decimal MonthlyAmountWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, int scheduledHours, int workingsHours)
        {
            decimal amountFactor = FactorizeAmount(amountMonthly, scheduleFactor);

            decimal paymentValue = RoundingPay.PaymentFromAmount(amountFactor, scheduledHours, workingsHours);

            return RoundingDec.RoundUp(paymentValue);
        }
    }
}
