using Capstone.UITests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class Detail2WeatherSteps
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
        [Given(@"I am on a park's detail page")]
        public void GivenIAmOnAParkSDetailPage()
        {
            DetailPage detailPage = new DetailPage(driver);
            detailPage.Navigate();
            ScenarioContext.Current.Set(detailPage, CurrentPage);
        }
        
        [When(@"I click the forecasts link")]
        public void WhenIClickTheForecastsLink()
        {
            DetailPage detailPage = ScenarioContext.Current.Get<DetailPage>(CurrentPage);
            WeatherPage weatherMRNP = detailPage.WeatherView();
            ScenarioContext.Current.Set(weatherMRNP, CurrentPage);
        }
        
        [Then(@"I should be taken to that park's weather forecast page\.")]
        public void ThenIShouldBeTakenToThatParkSWeatherForecastPage_()
        {
            WeatherPage weatherMRNP = ScenarioContext.Current.Get<WeatherPage>(CurrentPage);
            weatherMRNP.Navigate();
            Assert.AreEqual("http://localhost:55601/Weather/Forecast", driver.Url);
        }
    }
}
