using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models;

namespace GOOS_Sample.Interface
{
    public interface IGOOSRepo
    {
        int SaveBudget(Budgets budget);
    }
}