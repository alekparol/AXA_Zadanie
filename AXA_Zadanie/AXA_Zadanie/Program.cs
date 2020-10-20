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

            DriverFactory.InitBrowser("Firefox");
            DriverFactory.LoadApplication("https://www.google.pl/maps/");

            DriverFactory.Driver.Manage().Window.Maximize();
            IWebDriver driver = DriverFactory.Driver;

            Thread.Sleep(3000);

            AgreementsPopUp ag = new AgreementsPopUp(driver);
            ag.ClickAgree();

            Thread.Sleep(3000);
            driver.SwitchTo().ParentFrame();


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

            DriverFactory.CloseAllDrivers();

        }
	}
}
