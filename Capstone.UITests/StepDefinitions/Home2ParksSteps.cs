using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class Home2ParksSteps
    {
        private static IWebDriver driver;
        private const string CurrentPage = "CurrentPage";

        [BeforeFeature]
        public static void InitFeature()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void FeatureCleanup()
        {
            driver.Close();
            driver.Quit();
        }

        [Given(@"I am on the landing page")]
        public void GivenIAmOnTheLandingPage()
        {
            LandingPage landingPage = new LandingPage(driver);
            landingPage.Navigate();
           
            ScenarioContext.Current.Set(landingPage, CurrentPage);
        }
        
        [When(@"I click Parks link")]
        public void WhenIClickParksLink()
        {
            LandingPage landingPage = ScenarioContext.Current.Get<LandingPage>(CurrentPage);
            ParksListPage parksPage=landingPage.GoToParksList();            
            
            ScenarioContext.Current.Set(parksPage,CurrentPage);
        }
        
        [Then(@"I should be taken to parks list page")]
        public void ThenIShouldBeTakenToParksListPage()
        {
            ParksListPage parksPage = ScenarioContext.Current.Get<ParksListPage>(CurrentPage);

            Assert.AreEqual(driver.Url, "http://localhost:55601/Parks/ParksList");
        }
    }
}
