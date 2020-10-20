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

        [DataTestMethod]
        [DataRow("Chrome","walk","Chłodna 51", "Plac Defilad 1", 40, 3)]
        [DataRow("Chrome","bike", "Chłodna 51", "Plac Defilad 1", 15, 3)]
        [DataRow("Chrome", "walk", "Plac Defilad 1", "Chłodna 51", 40, 3)]
        [DataRow("Chrome", "bike", "Plac Defilad 1", "Chłodna 51", 15, 3)]
        [TestMethod]
        public void Zadanie(string browserType, string mode, string endpoint_1, string endpoint_2, int maximalDuration, int maximalDistance)
        {
            /* Inicjalizacja testu */

            var _driver_ = new DriverFactory(browserType);
            _driver_.LoadApplication("https://www.google.pl/maps/");

            IWebDriver driver = _driver_.driver;

            /* Zgoda na przetwarzanie informacji przez Google */
            AgreementsPopUp agreementPopUp = new AgreementsPopUp(driver);
            agreementPopUp.ClickAgree();

            /* Inicjalizacja search boxa i przejście do trybu wyznaczania trasy */
            SearchBox googleSearchBox = new SearchBox(driver);
            googleSearchBox.ClickDriectionButton();

            /* Inicjalizacja podwójnego search boxa i wprowadzenie dwóch adresów pod kątem trasy (pieszej lub rowerowej) */
            SearchDirections searchDirections = new SearchDirections(driver);
            if (mode == "walk")
            {
                searchDirections.SearchRouteForWalk(endpoint_1, endpoint_2);
            }
            else if (mode == "bike")
            {
                searchDirections.SearchRouteForBike(endpoint_1, endpoint_2);
            }

            /* Inicjalizacja listy tras i pobranie informacji o najszybszej dla trasy (pieszej lub rowerowej) */
            RoutesList routeList = new RoutesList(driver);

            float fastestsRouteDistance = routeList.ReturnRouteDistance();
            int fastestsRouteDuration = routeList.ReturnRouteDuration();

            /* Sprawdzenie warunków testów dla trasy (pieszej lub rowerowej) */

            Assert.IsTrue(fastestsRouteDuration < maximalDuration, "The fastests route exceeds required time limit. Expected outcome: < {0} min. Actual outcome: {1} min", maximalDuration, fastestsRouteDuration);
            Assert.IsTrue(fastestsRouteDistance < maximalDistance, "The fastests route exceeds required distance limit. Expected outcome: < {0} km. Actual outcome: {1} km", maximalDistance, fastestsRouteDistance);

            _driver_.CloseAllDrivers();
        }
    }
}
