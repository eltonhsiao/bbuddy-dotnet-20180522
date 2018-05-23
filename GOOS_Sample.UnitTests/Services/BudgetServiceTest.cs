using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Services;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;

namespace GOOS_Sample.UnitTests.Services
{
    [TestFixture]
    public class BudgetServiceTest
    {
        public IBudgetService BudgetService { get; set; }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Month_With_Whole_Month()
        {
            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-04-01"),
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
            var expected = 600;

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Same_Day()
        {
            var dateRange = new DateRange
            {
                Start = Convert.ToDateTime("2018-04-01"),
                End = Convert.ToDateTime("2018-04-01")
            };

            var budgetList = new List<Budget>
            {
                new Budget()
                {
                    YearMonth = "2018-04",
                    Amount = 600
                }
            };
            var expected = 20;

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
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

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month()
        {
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

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_With_Empty_Data()
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

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        [Test]
        public void StartDate_And_EndDate_Are_Diff_Month_With_Large_Data()
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

            var total = CalculateTotalBudget(dateRange, budgetList);

            Assert.AreEqual(expected, total);
        }

        private decimal CalculateTotalBudget(DateRange dateRange, List<Budget> budgetList)
        {
            decimal total = 0;

            foreach (var b in budgetList)
            {
                var month = Convert.ToInt32(b.YearMonth.Substring(b.YearMonth.Length - 2));
                var year = Convert.ToInt32(b.YearMonth.Substring(0, 4));
                var totalDay = DateTime.DaysInMonth(year, month);
                var average = (decimal)b.Amount / totalDay;

                if (dateRange.Start.Month == dateRange.End.Month)
                {
                    total += average * (dateRange.End.Day - dateRange.Start.Day + 1);
                }
                else if (dateRange.Start.Month == Convert.ToInt32(month))
                {
                    total += average * (totalDay - dateRange.Start.Day + 1);
                }
                else if (dateRange.End.Month == Convert.ToInt32(month))
                {
                    total += average * dateRange.End.Day;
                }
                else
                {
                    total += average * totalDay;
                }
            }

            return total;
        }
    }
}