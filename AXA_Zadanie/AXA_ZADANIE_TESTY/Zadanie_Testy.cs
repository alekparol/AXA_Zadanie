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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AXA_Zadanie;

namespace AXA_ZADANIE_TESTY
{
    [TestClass]
    public class Zadanie_Testy
    {
        [TestMethod]
        public void Zadanie_1_A()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            /* Przejście do strony testowej */
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            /* Zgoda na przetwarzanie informacji przez Google */
            AgreementsPopUp agreementPopUp = new AgreementsPopUp(driver);
            agreementPopUp.ClickAgree();

            /* Inicjalizacja search boxa i przejście do trybu wyznaczania trasy */
            SearchBox googleSearchBox = new SearchBox(driver);
            googleSearchBox.ClickDriectionButton();

            /* Inicjalizacja podwójnego search boxa i wprowadzenie dwóch adresów pod kątem trasy pieszej */
            SearchDirections searchDirections = new SearchDirections(driver);
            searchDirections.SearchRouteForWalk("Chłodna 51", "Plac Defilad 1");

            /* Inicjalizacja listy tras i pobranie informacji o najszybszej dla trasy pieszej */
            RoutesList routeList = new RoutesList(driver);

            float fastestsRouteDistance = routeList.ReturnRouteDistance();
            int fastestsRouteDuration = routeList.ReturnRouteDuration();

            /* Sprawdzenie warunków testów dla trasy pieszej */

            Assert.IsTrue(fastestsRouteDuration < 40, "The fastests route exceeds required time limit. Expected outcome: < 40 min. Actual outcome: {0} min", fastestsRouteDuration);
            Assert.IsTrue(fastestsRouteDistance < 3, "The fastests route exceeds required distance limit. Expected outcome: < 3 km. Actual outcome: {0} km", fastestsRouteDistance);

            driver.Quit();
        }

        [TestMethod]
        public void Zadanie_1_B()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            /* Przejście do strony testowej */
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            /* Zgoda na przetwarzanie informacji przez Google */
            AgreementsPopUp agreementPopUp = new AgreementsPopUp(driver);
            agreementPopUp.ClickAgree();

            /* Inicjalizacja search boxa i przejście do trybu wyznaczania trasy */
            SearchBox googleSearchBox = new SearchBox(driver);
            googleSearchBox.ClickDriectionButton();

            /* Inicjalizacja podwójnego search boxa i wprowadzenie dwóch adresów pod kątem trasy rowerowej */
            SearchDirections searchDirections = new SearchDirections(driver);
            searchDirections.SearchRouteForBike("Chłodna 51", "Plac Defilad 1");

            /* Inicjalizacja listy tras i pobranie informacji o najszybszej dla jazdy rowerem */
            RoutesList routeList = new RoutesList(driver);

            float fastestsRouteDistance = routeList.ReturnRouteDistance();
            int  fastestsRouteDuration = routeList.ReturnRouteDuration();

            /* Sprawdzenie warunków testów dla jazdy rowerem */

            Assert.IsTrue(fastestsRouteDuration < 15, "The fastests route exceeds required time limit. Expected outcome: < 40 min. Actual outcome: {0} min", fastestsRouteDuration);
            Assert.IsTrue(fastestsRouteDistance < 3, "The fastests route exceeds required distance limit. Expected outcome: < 3 km. Actual outcome: {0} km", fastestsRouteDistance);

            driver.Quit();
        }

        [TestMethod]
        public void Zadanie_2_A()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            /* Przejście do strony testowej */
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            /* Zgoda na przetwarzanie informacji przez Google */
            AgreementsPopUp agreementPopUp = new AgreementsPopUp(driver);
            agreementPopUp.ClickAgree();

            /* Inicjalizacja search boxa i przejście do trybu wyznaczania trasy */
            SearchBox googleSearchBox = new SearchBox(driver);
            googleSearchBox.ClickDriectionButton();

            /* Inicjalizacja podwójnego search boxa i wprowadzenie dwóch adresów pod kątem trasy pieszej */
            SearchDirections searchDirections = new SearchDirections(driver);
            searchDirections.SearchRouteForWalk("Plac Defilad 1", "Chłodna 51");

            /* Inicjalizacja listy tras i pobranie informacji o najszybszej dla trasy pieszej */
            RoutesList routeList = new RoutesList(driver);

            float fastestsRouteDistance = routeList.ReturnRouteDistance();
            int fastestsRouteDuration = routeList.ReturnRouteDuration();

            /* Sprawdzenie warunków testów dla trasy pieszej */

            Assert.IsTrue(fastestsRouteDuration < 40, "The fastests route exceeds required time limit. Expected outcome: < 40 min. Actual outcome: {0} min", fastestsRouteDuration);
            Assert.IsTrue(fastestsRouteDistance < 3, "The fastests route exceeds required distance limit. Expected outcome: < 3 km. Actual outcome: {0} km", fastestsRouteDistance);

            driver.Quit();
        }

        [TestMethod]
        public void Zadanie_2_B()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            /* Przejście do strony testowej */
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            /* Zgoda na przetwarzanie informacji przez Google */
            AgreementsPopUp agreementPopUp = new AgreementsPopUp(driver);
            agreementPopUp.ClickAgree();

            /* Inicjalizacja search boxa i przejście do trybu wyznaczania trasy */
            SearchBox googleSearchBox = new SearchBox(driver);
            googleSearchBox.ClickDriectionButton();

            /* Inicjalizacja podwójnego search boxa i wprowadzenie dwóch adresów pod kątem trasy rowerowej */
            SearchDirections searchDirections = new SearchDirections(driver);
            searchDirections.SearchRouteForBike("Plac Defilad 1", "Chłodna 51");

            /* Inicjalizacja listy tras i pobranie informacji o najszybszej dla jazdy rowerem */
            RoutesList routeList = new RoutesList(driver);

            float fastestsRouteDistance = routeList.ReturnRouteDistance();
            int fastestsRouteDuration = routeList.ReturnRouteDuration();

            /* Sprawdzenie warunków testów dla jazdy rowerem */

            Assert.IsTrue(fastestsRouteDuration < 15, "The fastests route exceeds required time limit. Expected outcome: < 40 min. Actual outcome: {0} min", fastestsRouteDuration);
            Assert.IsTrue(fastestsRouteDistance < 3, "The fastests route exceeds required distance limit. Expected outcome: < 3 km. Actual outcome: {0} km", fastestsRouteDistance);

            driver.Quit();
        }
    }
}
