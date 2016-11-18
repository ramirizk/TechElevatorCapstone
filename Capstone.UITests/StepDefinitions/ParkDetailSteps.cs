using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class ParkDetailSteps
    {
        private static IWebDriver driver;
        private const string CurrentPage = "CurrentPage";
        [BeforeFeature]
        public static void InitFeature()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void FeatureClenaup()
        {
            driver.Close();
            driver.Quit();
        }

        [Given(@"I am on the ParkLists page")]
        public void GivenIAmOnTheParkListsPage()
        {
            ParksListPage parksPage = new ParksListPage(driver);
            parksPage.Navigate();
            ScenarioContext.Current.Set(parksPage,CurrentPage);
        }
        
        [When(@"I click on an image")]
        public void WhenIClickOnAnImage()
        {
            ParksListPage parksPage = ScenarioContext.Current.Get<ParksListPage>(CurrentPage);
            DetailPage detailMRNP = parksPage.DetailView();            
            ScenarioContext.Current.Set(detailMRNP,CurrentPage);
        }
        
        [Then(@"the result should be the detail page of that park")]
        public void ThenTheResultShouldBeTheDetailPageOfThatPark()
        {            
            DetailPage detailMRNP = ScenarioContext.Current.Get<DetailPage>(CurrentPage);
            detailMRNP.Navigate();
            Assert.AreEqual("http://localhost:55601/Parks/Detail?parkCode=MRNP", driver.Url);
        }
    }
}
