﻿using GOOS_Sample.Helper;
using GOOS_Sample.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOOS_Sample.UnitTests
{
    [TestFixture]
    public class BudgetHelperTests
    {
        private List<Budget> _budgetList;

        [Test]
        public void Query_Whole_Month()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));
            AmountShouldBe(600, "2018-04-01", "2018-04-30");
        }

        [Test]
        public void no_overlap_after()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));
            AmountShouldBe(0, "2018-05-01", "2018-05-30");
        }

        [Test]
        public void no_overlap_before()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));
            AmountShouldBe(0, "2018-03-01", "2018-03-30");
        }

        [Test]
        public void different_year()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));
            AmountShouldBe(0, "2017-04-01", "2017-04-30");
        }

        [Test]
        public void three_years()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));
            AmountShouldBe(600, "2017-04-01", "2019-04-30");
        }

        private void AmountShouldBe(int expected, string start, string end)
        {
            Assert.AreEqual(expected, Calculate(start, end));
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month()
        {
            MakeBudgetList(MakeBudget("2018-04", 600), MakeBudget("2018-05", 620));

            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-04-15"),
                End = Convert.ToDateTime("2018-05-15")
            };

            var budgetList = new List<Budget>
            {
                new Budget()
                {
                    YearMonth = "2018-04",
                    Amount = 600
                },
                new Budget()
                {
                    YearMonth = "2018-05",
                    Amount = 620
                }
            };
            var expected = 620;

            var total = BudgetHelper.CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_When_Decimal_Data()
        {
            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-02-01"),
                End = Convert.ToDateTime("2018-06-30")
            };

            var budgetList = new List<Budget>
            {
                new Budget()
                {
                    YearMonth = "2018-02",
                    Amount = 990
                },
                new Budget()
                {
                    YearMonth = "2018-03",
                    Amount = 990
                },
                new Budget()
                {
                    YearMonth = "2018-04",
                    Amount = 990
                },
                new Budget()
                {
                    YearMonth = "2018-05",
                    Amount = 990
                },
                new Budget()
                {
                    YearMonth = "2018-06",
                    Amount = 990
                },
            };
            var expected = 4950;

            var total = BudgetHelper.CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_With_Empty_MonthAndData()
        {
            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-04-15"),
                End = Convert.ToDateTime("2018-06-30")
            };

            var budgetList = new List<Budget>
            {
                new Budget()
                {
                    YearMonth = "2018-04",
                    Amount = 600
                },
                new Budget()
                {
                    YearMonth = "2018-05",
                    Amount = 620
                }
            };
            var expected = 940;

            var total = BudgetHelper.CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Day()
        {
            MakeBudgetList(MakeBudget("2018-04", 600));

            Assert.AreEqual(20, Calculate("2018-04-01", "2018-04-01"));
        }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Month_With_Partial_Month()
        {
            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-04-15"),
                End = Convert.ToDateTime("2018-04-30")
            };

            var budgetList = new List<Budget>
            {
                new Budget()
                {
                    YearMonth = "2018-04",
                    Amount = 600
                }
            };
            var expected = 320;

            var total = BudgetHelper.CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        private decimal Calculate(string start, string end)
        {
            return BudgetHelper.CalculateTotalBudget(
                MakeDateRange(start, end),
                _budgetList);
        }

        private Budget MakeBudget(string month, int amount)
        {
            return new Budget()
            {
                YearMonth = month,
                Amount = amount
            };
        }

        private void MakeBudgetList(params Budget[] budgets)
        {
            _budgetList = budgets.ToList();
        }

        private DateRange MakeDateRange(string start, string end)
        {
            return new DateRange
            {
                Start = Convert.ToDateTime(start),
                End = Convert.ToDateTime(end)
            };
        }
    }
}