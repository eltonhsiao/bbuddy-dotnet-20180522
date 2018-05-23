using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;

namespace GOOS_Sample.Services
{
    public class BudgetService : IBudgetService
    {
        public IGOOSRepo GOOSRepo { get; set; }
    }
}