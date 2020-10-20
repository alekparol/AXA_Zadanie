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
    public class AgreementsPopUp
    {

        /* Fields */

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "introAgreeButton")]
        public IWebElement Agree { get; set; }

        /* Methods */

        public void ClickAgree()
        {
            Agree.Click();
        }

        /* Constructors */


        public AgreementsPopUp(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("widget-consent-frame")));

            driver.SwitchTo().Frame(driver.FindElement(By.ClassName("widget-consent-frame")));
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

    }
}
