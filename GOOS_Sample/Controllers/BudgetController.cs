using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;
using GOOS_Sample.Services;
using GOOS_Sample.ViewModel;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        public IGOOSRepo GOOSRepo { get; set; }

        public BudgetService BudgetService { get; set; }

        public ActionResult Index()
        {
            var result = GOOSRepo.GetAllBudgets();
            return View(result);
        }

        // GET: Budgets
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Budget budget)
        {
            GOOSRepo.AddBudget(budget);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Budget budget)
        {
            GOOSRepo.UpdateBudget(budget);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Get(DateRange dateRange)
        {
            var budgetList = GOOSRepo.GetTotalBudgetByTimeRange(dateRange);
            BudgetService.CalculateTotalBudget(dateRange, budgetList);
            return null;
        }
    }

    public class DateRange
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}