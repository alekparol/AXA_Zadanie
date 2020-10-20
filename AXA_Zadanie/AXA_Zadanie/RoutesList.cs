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
    public class RoutesList
    {

        /* Fields */

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@class=\"section-directions-trip-description\"][1]")]
        public IWebElement ListOfRoutes { get; set; }

        /* Methods */

        public int ReturnRouteDuration()
        {
            string number = ListOfRoutes.FindElement(By.ClassName("section-directions-trip-duration")).Text.Replace(" min", "");
            return Int32.Parse(number);
        }

        public float ReturnRouteDistance()
        {
            string number = ListOfRoutes.FindElement(By.ClassName("section-directions-trip-distance")).Text.Replace(" km", "");
            return float.Parse(number);
        }

        /* Constructors */


        public RoutesList(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"section-directions-trip-description\"][1]")));
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

    }
}
