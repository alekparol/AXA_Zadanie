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
    public class SearchBox
    {

        /* Fields */

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "searchbox")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "searchbox-directions")]
        public IWebElement DirectionsButton { get; set; }

        /* Methods */

        public void ClickDriectionButton()
        {
            DirectionsButton.Click();
        }
        /* Constructors */


        public SearchBox(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("//div[@role=\"region\"]")));
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

    }
}
