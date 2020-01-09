using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework.Internal;

namespace PageObject
{
    [TestClass]
    public class Test
    {
        IWebDriver Browser;
        private static string HomePage = "https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1";
        
        //Ввод несуществующего места назначения
        [TestMethod]
        public void SelectCityTest()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl(HomePage);

            MainPage selectCity = new MainPage(Browser).InputSearch("Мепалвяываал");
            Browser.Quit();
        }
        
        [TestMethod]
        public void CalendarTest()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl(HomePage);

            MainPage calendarChoice = new MainPage(Browser).InputSearch("Москва").CalendarTools();

            Browser.Quit();
        }      

    }
}
