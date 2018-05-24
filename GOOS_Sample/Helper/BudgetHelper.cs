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

            foreach (var budget in budgetList)
            {
                var daysInMonth = budget.DaysInMonth;
                var startOfBudget = budget.StartOfBudget();
                var endOfBudget = budget.EndOfBudget();
                var averageEachDay = (decimal)budget.Amount / daysInMonth;
                int totalDay;

                if (dateRange.Start > endOfBudget || dateRange.End < startOfBudget)
                {
                    totalDay = 0;
                }
                else if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
                {
                    totalDay = (dateRange.End.Day - dateRange.Start.Day + 1);
                }
                else if (dateRange.Start.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
                {
                    totalDay = (daysInMonth - dateRange.Start.Day + 1);
                }
                else if (dateRange.End.ToString("yyyyMM") == startOfBudget.ToString("yyyyMM"))
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