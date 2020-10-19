using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AXA_Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.pl/maps/preview");

            Thread.Sleep(20000);

            SearchBox ne = new SearchBox(driver);
            ne.ClickDriectionButton();

            Thread.Sleep(2000);
            driver.Quit();

        }
	}
}
