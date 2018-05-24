﻿using System;

namespace GOOS_Sample.Models
{
    public class Budget
    {
        public string YearMonth { get; set; }

        public long Amount { get; set; }

        private DateRange DateRange => new DateRange
        {
            Start = StartOfBudget(),
            End = StartOfBudget().AddMonths(1).AddDays(-1)
        };

        private DateTime StartOfBudget()
        {
            return DateTime.ParseExact(YearMonth + "-01", "yyyy-MM-dd", null);
        }

        private decimal DailyAmount()
        {
            return (decimal) Amount / DateRange.DayCount();
        }

        public decimal OverlappingAmount(DateRange dateRange)
        {
            return DailyAmount() * dateRange.OverlappingDays(DateRange);
        }
    }
}