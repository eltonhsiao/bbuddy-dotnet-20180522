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
                total += budget.DailyAmount() * TotalDay(dateRange, budget);
            }

            return total;
        }

        private static int TotalDay(DateRange dateRange, Budget budget)
        {
            int totalDay;

            if (dateRange.Start > budget.EndOfBudget() || dateRange.End < budget.StartOfBudget())
            {
                totalDay = 0;
            }
            else if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
            {
                totalDay = (dateRange.End.Day - dateRange.Start.Day + 1);
            }
            else if (dateRange.Start.ToString("yyyyMM") == budget.StartOfBudget().ToString("yyyyMM"))
            {
                totalDay = (budget.DaysInMonth - dateRange.Start.Day + 1);
            }
            else if (dateRange.End.ToString("yyyyMM") == budget.StartOfBudget().ToString("yyyyMM"))
            {
                totalDay = dateRange.End.Day;
            }
            else
            {
                totalDay = budget.DaysInMonth;
            }

            return totalDay;
        }
    }
}