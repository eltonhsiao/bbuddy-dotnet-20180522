using System.Collections.Generic;
using System.Linq;
using GOOS_Sample.Models;

namespace GOOS_Sample.Helper
{
    public class BudgetHelper
    {
        public static decimal CalculateTotalBudget(DateRange dateRange, List<Budget> budgetList)
        {
            return budgetList.Sum(budget => budget.OverlappingAmount(dateRange));
        }
    }
}