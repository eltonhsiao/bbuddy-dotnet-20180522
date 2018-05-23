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
        public decimal CalculateTotalBudget(DateRange dateRange, List<Budget> budgetList)
        {
            decimal totalBudget = 0;

            foreach (var b in budgetList)
            {
                totalBudget += b.AverageBudget * GetTotalDay(dateRange, b);
            }

            return totalBudget;
        }

        private int GetTotalDay(DateRange dateRange, Budget b)
        {
            int totalDay;
            if (dateRange.Start.Month == dateRange.End.Month)
            {
                totalDay = dateRange.End.Day - dateRange.Start.Day + 1;
            }
            else if (dateRange.Start.Month == Convert.ToInt32(b.Month))
            {
                totalDay = b.DaysInMonth - dateRange.Start.Day + 1;
            }
            else if (dateRange.End.Month == Convert.ToInt32(b.Month))
            {
                totalDay = dateRange.End.Day;
            }
            else
            {
                totalDay = b.DaysInMonth;
            }

            return totalDay;
        }
    }
}