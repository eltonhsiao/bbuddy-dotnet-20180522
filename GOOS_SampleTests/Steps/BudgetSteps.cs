using System;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class BudgetSteps : FluentTest
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [Given(@"go to adding budget page")]
        public void GivenGoToAddingBudgetPage()
        {
        }

        [Given(@"Budget table existed budgets")]
        public void GivenBudgetTableExistedBudgets(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add a buget (.*) for ""(.*)""")]
        public void WhenIAddABugetFor(int p0, string p1)
        {
            I.Open("http://localhost:58527/Budget/Add")
                .Assert.Exists("#yearmonth");
        }

        [Then(@"it should display ""(.*)""")]
        public void ThenItShouldDisplay(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}