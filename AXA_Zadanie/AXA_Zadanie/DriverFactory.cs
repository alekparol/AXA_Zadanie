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
    public class DriverFactory
    {
        public IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                }
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public DriverFactory(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                    }
                    break;
            }
        }

        public void LoadApplication(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
        }

        public void CloseAllDrivers()
        {
            driver.Quit();
        }

    }
}
