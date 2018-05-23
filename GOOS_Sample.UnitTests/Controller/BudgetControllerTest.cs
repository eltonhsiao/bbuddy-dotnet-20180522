using System;
using Autofac;
using Autofac.Integration.Mvc;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using NSubstitute;
using NUnit.Framework;

namespace GOOS_Sample.UnitTests.Controller
{
    [TestFixture]
    public class BudgetControllerTest : ControllerBaseTest<BudgetController>
    {
        private BudgetController _controller;

        [Test]
        public void User_Add_Budget_And_Save_Data()
        {
            _controller = new BudgetController();

            Budgets budget = new Budgets
            {
                Month = "2018-05",
                Amount = 1000
            };

            _controller.GOOSRepo.SaveBudget(Arg.Any<Budgets>()).Returns(new int());
        }
    }
}