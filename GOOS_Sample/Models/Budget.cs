﻿using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        public int DaysInMonth
        {
            get
            {
                var year = Convert.ToInt32(YearMonth.Substring(0, 4));
                var month = Convert.ToInt32(YearMonth.Substring(YearMonth.Length - 2));
                return DateTime.DaysInMonth(year, month);
            }
        }

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