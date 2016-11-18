using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.UITests.StepDefinitions
{
    public class LandingPage
    {
        private IWebDriver driver;
        public const string Url = "http://localhost:55601/";

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.Name, Using ="parkslist")]
        public IWebElement ParkLink { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }
       public ParksListPage GoToParksList()
        {
            ParkLink.Click();
            return new ParksListPage(driver);
        }
    }
}