using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Controllers;
using GOOS_Sample.Helper;
using GOOS_Sample.Models;
using NUnit.Framework;

namespace GOOS_Sample.UnitTests
{
    public class BudgetBuilder
    {
        public BudgetBuilder()
        {
            BudgetList = new List<Budget>();
        }

        public List<Budget> BudgetList;

        public string Start;

        public string End;

        public BudgetBuilder AddBudget(string month, int amount)
        {
            BudgetList.Add(new Budget()
            {
                YearMonth = month,
                Amount = amount
            });

            return this;
        }

        public BudgetBuilder MakeBudgetList(params Budget[] budgets)
        {
            BudgetList = budgets.ToList();
            return this;
        }

        public BudgetBuilder From(string start)
        {
            Start = start;
            return this;
        }

        public BudgetBuilder To(string end)
        {
            End = end;
            return this;
        }
    }

    [TestFixture]
    public class BudgetHelperTests
    {
        private BudgetBuilder _budgetBuilder;

        [SetUp]
        public void SetUp()
        {
            _budgetBuilder = new BudgetBuilder();
        }

        [Test]
        public void Query_Whole_Month()
        {
            _budgetBuilder.AddBudget("2018-04", 600)
                          .From("2018-04-01")
                          .To("2018-04-30");

            TotalBudgetShouldBe(600);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month()
        {
            _budgetBuilder.AddBudget("2018-04", 600)
                          .AddBudget("2018-05", 620)
                          .From("2018-04-15")
                          .To("2018-05-15");

            TotalBudgetShouldBe(620);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_With_Decimal_Data()
        {
            _budgetBuilder.AddBudget("2018-02", 990)
                          .AddBudget("2018-03", 990)
                          .AddBudget("2018-04", 990)
                          .AddBudget("2018-05", 990)
                          .AddBudget("2018-06", 990)
                          .From("2018-02-01")
                          .To("2018-06-30");

            TotalBudgetShouldBe(4950);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_With_Empty_MonthAndData()
        {
            _budgetBuilder.AddBudget("2018-04", 600)
                          .AddBudget("2018-05", 620)
                          .From("2018-04-15")
                          .To("2018-06-30");

            TotalBudgetShouldBe(940);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Day()
        {
            _budgetBuilder.AddBudget("2018-04", 600)
                          .From("2018-04-01")
                          .To("2018-04-01");

            TotalBudgetShouldBe(20);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Month_With_Partial_Days()
        {
            _budgetBuilder.AddBudget("2018-04", 600)
                          .From("2018-04-15")
                          .To("2018-04-30");

            TotalBudgetShouldBe(320);
        }

        private decimal Calculate(string start, string end)
        {
            return BudgetHelper.CalculateTotalBudget(
                MakeDateRange(start, end), _budgetBuilder.BudgetList);
        }

        private DateRange MakeDateRange(string start, string end)
        {
            return new DateRange
            {
                Start = Convert.ToDateTime(start),
                End = Convert.ToDateTime(end)
            };
        }

        private void TotalBudgetShouldBe(int expected)
        {
            Assert.AreEqual(expected, Calculate(_budgetBuilder.Start, _budgetBuilder.End));
        }
    }
}