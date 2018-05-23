using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;

namespace GOOS_Sample.Interface
{
    public interface IGOOSRepo
    {
        int AddBudget(Budget budget);

        List<Budget> GetAllBudgets();

        void UpdateBudget(Budget budget);

        List<Budget> GetTotalBudgetByTimeRange(DateRange dateRange);
    }
}