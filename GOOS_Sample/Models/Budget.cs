using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        public int Month
        {
            get { return Convert.ToInt32(YearMonth.Substring(YearMonth.Length - 2)); }
        }

        public decimal AverageBudget
        {
            get { return (decimal)Amount / DaysInMonth; }
        }

        public int DaysInMonth
        {
            get
            {
                var year = Convert.ToInt32(YearMonth.Substring(0, 4));
                return DateTime.DaysInMonth(year, Month);
            }
        }

        public DateRange DateRange => new DateRange
        {
            Start = StartOfBudget(),
            End = EndOfBudget()
        };

        public DateTime StartOfBudget()
        {
            return DateTime.ParseExact(YearMonth + "-01", "yyyy-MM-dd", null);
        }

        public DateTime EndOfBudget()
        {
            return DateTime.ParseExact(YearMonth + "-" + DaysInMonth, "yyyy-MM-dd", null);
        }

        public decimal DailyAmount()
        {
            return (decimal) Amount / DaysInMonth;
        }
    }
}