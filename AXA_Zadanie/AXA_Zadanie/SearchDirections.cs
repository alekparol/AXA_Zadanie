using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AXA_Zadanie
{
    public class SearchDirections
    {

        /* Fields */

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@id=\"directions-searchbox-0\"]//input")]
        public IWebElement FirstEndpoint { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id=\"directions-searchbox-1\"]//input")]
        public IWebElement SecondEndpoint { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@aria-label=\"Pieszo\"]")]
        public IWebElement ModeByWalk { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@aria-label=\"Na rowerze\"]")]
        public IWebElement ModeByBike { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"directions-searchbox-1\"]//button[@aria-label=\"Szukaj\"]")]
        public IWebElement SearchButton { get; set; }

        /* Methods */

        public void ChoseModeByWalk()
        {
            ModeByWalk.Click();
        }

        public void ChoseModeByBike()
        {
            ModeByBike.Click();
        }

        public void TypeStart(string endpointAddress)
        {
            FirstEndpoint.Clear();
            FirstEndpoint.SendKeys(endpointAddress);
        }

        public void TypeEnd(string endpointAddress)
        {
            SecondEndpoint.Clear();
            SecondEndpoint.SendKeys(endpointAddress);
        }

        public void SearchButtonClick()
        {
            SearchButton.Click();
        }

        public void SearchRouteForWalk(string endpointAddress_1, string endpointAddress_2)
        {
            ChoseModeByWalk();
            TypeStart(endpointAddress_1);
            TypeEnd(endpointAddress_2);
            SearchButtonClick();
        }

        public void SearchRouteForBike(string endpointAddress_1, string endpointAddress_2)
        {
            ChoseModeByBike();
            TypeStart(endpointAddress_1);
            TypeEnd(endpointAddress_2);
            SearchButtonClick();
        }

        /* Constructors */


        public SearchDirections(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@jsnamespace=\"directions\"]")));
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

    }
}
