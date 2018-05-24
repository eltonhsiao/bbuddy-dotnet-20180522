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
            if (dateRange.Start > budget.EndOfBudget() || dateRange.End < budget.StartOfBudget())
            {
                return 0;
            }

            if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
            {
                return (dateRange.End.Day - dateRange.Start.Day + 1);
            }

            if (dateRange.Start.ToString("yyyyMM") == budget.StartOfBudget().ToString("yyyyMM"))
            {
                return (budget.DaysInMonth - dateRange.Start.Day + 1);
            }

            if (dateRange.End.ToString("yyyyMM") == budget.StartOfBudget().ToString("yyyyMM"))
            {
                return dateRange.End.Day;
            }

            return budget.DaysInMonth;

        }
    }
}