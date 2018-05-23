using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        public int Year
        {
            get
            {
                return Convert.ToInt32(YearMonth.Substring(0, 4));
            }
        }

        public int Month
        {
            get { return Convert.ToInt32(YearMonth.Substring(YearMonth.Length - 2)); }
        }

        public int DaysInMonth
        {
            get
            {
                return DateTime.DaysInMonth(Year, Month);
            }
        }

        public decimal AverageBudget
        {
            get { return (decimal)Amount / DaysInMonth; }
        }
    }
}