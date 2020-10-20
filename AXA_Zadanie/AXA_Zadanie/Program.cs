using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            AgreementsPopUp ag = new AgreementsPopUp(driver);
            ag.ClickAgree();
            
            SearchBox ne = new SearchBox(driver);
            
            ne.ClickDriectionButton();

            SearchDirections sd = new SearchDirections(driver);
            sd.SearchRouteForWalk("Chłodna 51", "Plac Defilad 1");

            RoutesList rl = new RoutesList(driver);
            Console.WriteLine(rl.ReturnRouteDistance());
            Console.WriteLine(rl.ReturnRouteDuration());

            sd = new SearchDirections(driver);
            sd.ChoseModeByBike();

            rl = new RoutesList(driver);
            Console.WriteLine(rl.ReturnRouteDistance());
            Console.WriteLine(rl.ReturnRouteDuration());

            Thread.Sleep(20000);
            driver.Quit();

        }
	}
}
