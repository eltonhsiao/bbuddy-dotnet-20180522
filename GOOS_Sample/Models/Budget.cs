using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        private int DaysInMonth => DateTime.DaysInMonth(DateRange.Start.Year, DateRange.Start.Month);

        private DateRange DateRange => new DateRange
        {
            Start = DateTime.ParseExact(YearMonth + "-01", "yyyy-MM-dd", null),
            End = DateTime.ParseExact(YearMonth + "-" + DaysInMonth, "yyyy-MM-dd", null)
        };

        private decimal DailyAmount()
        {
            return (decimal) Amount / DaysInMonth;
        }

        public decimal OverlappingAmount(DateRange dateRange)
        {
            return DailyAmount() * dateRange.OverlappingDays(DateRange);
        }
    }
}