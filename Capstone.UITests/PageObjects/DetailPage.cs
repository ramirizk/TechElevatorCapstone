using Capstone.UITests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.UITests.StepDefinitions
{
    public class DetailPage
    {
        private IWebDriver driver;
        private const string Url = "http://localhost:55601/Parks/Detail?parkCode=MRNP";

        [FindsBy(How=How.Name, Using = "forecast")]
        public IWebElement Forecast { get; set; }

        public DetailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public WeatherPage WeatherView()
        {
            Forecast.Click();

            return new WeatherPage(driver);
        }

    }
}