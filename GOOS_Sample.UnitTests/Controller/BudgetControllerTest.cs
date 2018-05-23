using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;
using GOOS_Sample.UnitTests.Helper;
using NSubstitute;
using NUnit.Framework;

namespace GOOS_Sample.UnitTests.Controller
{
    [TestFixture]
    public class BudgetControllerTest : ControllerBaseTest<BudgetController>
    {
        private BudgetController _controller;

        [Test]
        public void User_Add_Budget_Will_Redirect_To_Main_Page()
        {
            _controller = new BudgetController();
            _controller.GOOSRepo = Substitute.For<IGOOSRepo>();

            _controller.GOOSRepo.AddBudget(Arg.Any<Budget>()).Returns(new int());

            //var actionResult = _controller.InvokeOnActionExecuting(() => _controller.Index()) as RedirectToRouteResult;

            //Assert.IsNotNull(actionResult);
        }
    }
}