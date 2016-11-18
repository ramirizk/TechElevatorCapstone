using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.UITests.StepDefinitions
{
    public class ParksListPage
    {
        private IWebDriver driver;
        public const string Url = "http://localhost:55601/Parks/ParksList";

        [FindsBy(How=How.Name, Using ="MRNP")]
        public IWebElement Image { get; set; }

        public ParksListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public DetailPage DetailView()
        {
            Image.Click();

            return new DetailPage(driver);
        }

    }
}