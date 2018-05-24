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
                total += budget.DailyAmount() * dateRange.OverlappingDays(budget.DateRange);
            }

            return total;
        }
    }
}