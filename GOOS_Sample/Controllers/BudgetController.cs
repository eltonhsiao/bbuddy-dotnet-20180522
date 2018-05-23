using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;
using GOOS_Sample.ViewModel;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        public IGOOSRepo GOOSRepo { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Budgets
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Budgets budget)
        {
            GOOSRepo.SaveBudget(budget);
            return RedirectToAction("Index");
        }
    }
}