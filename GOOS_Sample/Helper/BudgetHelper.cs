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
                total += budget.DailyAmount() * OverlappingDays(dateRange, budget.DateRange);
            }

            return total;
        }

        private static int OverlappingDays(DateRange dateRange, DateRange range)
        {
            if (dateRange.Start > range.End || dateRange.End < range.Start)
            {
                return 0;
            }

            if (dateRange.Start.ToString("yyyyMM") == dateRange.End.ToString("yyyyMM"))
            {
                return (dateRange.End - dateRange.Start).Days + 1;
            }

            if (dateRange.Start.ToString("yyyyMM") == range.Start.ToString("yyyyMM"))
            {
                return (range.End - dateRange.Start).Days + 1;
            }

            if (dateRange.End.ToString("yyyyMM") == range.Start.ToString("yyyyMM"))
            {
                return (dateRange.End - range.Start).Days + 1;
            }

            return (range.End - range.Start).Days + 1;

        }
    }
}