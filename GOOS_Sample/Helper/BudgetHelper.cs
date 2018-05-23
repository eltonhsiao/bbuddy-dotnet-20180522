using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;

namespace GOOS_Sample.Helper
{
    public class BudgetHelper
    {
        public static decimal CalculateTotalBudget(DateRange dateRange, List<Budget> budgetList)
        {
            decimal total = 0;

            foreach (var b in budgetList)
            {
                var month = Convert.ToInt32(b.YearMonth.Substring(b.YearMonth.Length - 2));
                var year = Convert.ToInt32(b.YearMonth.Substring(0, 4));
                var daysInMonth = DateTime.DaysInMonth(year, month);
                var averageEachDay = (decimal)b.Amount / daysInMonth;
                int totalDay;
                if (dateRange.Start.Month == dateRange.End.Month)
                {
                    totalDay = (dateRange.End.Day - dateRange.Start.Day + 1);
                }
                else if (dateRange.Start.Month == Convert.ToInt32(month))
                {
                    totalDay = (daysInMonth - dateRange.Start.Day + 1);
                }
                else if (dateRange.End.Month == Convert.ToInt32(month))
                {
                    totalDay = dateRange.End.Day;
                }
                else
                {
                    totalDay = daysInMonth;
                }

                total += averageEachDay * totalDay;
            }

            return total;
        }
    }
}