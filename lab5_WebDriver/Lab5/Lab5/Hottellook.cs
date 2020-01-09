using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5
{
    class Hottellook
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void SelectCityTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement searchInput = driver.FindElement(By.Id("hotelsCity"));
            searchInput.SendKeys("Мепалвяываал" + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement texterror = driver.FindElement(By.XPath("//*[@id='ibu_hotel_container']/..//div[1]/h3"));
            Assert.AreEqual("Найдено 0 отелей", texterror.Text);
        }

        [Test]
        public void CalendarTest()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement searchInput = driver.FindElement(By.Id("hotelsCity"));
            searchInput.SendKeys("Москва" + Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement calendar = driver.FindElement(By.XPath("//*[@id='ibu_hotel_container']/div/div[1]/ul/li[2]/div/div[1]/input"));
            calendar.Click();
            IWebElement lastday = driver.FindElement(By.XPath("//*[@id='ibu_hotel_tools']/..//tr[6]/td[1]"));
            lastday.Click();
                
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
