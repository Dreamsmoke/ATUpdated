using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PageObject.Page
{
    class MainPage
    {
        [FindsBy(How = How.Id, Using = "hotelsCity")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = @"//*[@id='ibu_hotel_container']/..//div[1]/h3")]
        private IWebElement texterror;

        [FindsBy(How = How.XPath, Using = @"//*[@id='ibu_hotel_container']/div/div[1]/ul/li[2]/div/div[1]/input")]
        private IWebElement calendar;

        [FindsBy(How = How.XPath, Using = @"//*[@id='ibu_hotel_tools']/..//tr[6]/td[1]")]
        private IWebElement lastday;

        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage InputSearch(string q)
        {
            searchInput.SendKeys(q);
            searchInput.SendKeys(Keys.Enter);
            Task.Delay(12000);
            Assert.AreEqual("Найдено 0 отелей", texterror.Text);
            return this;
        }

        public MainPage CalendarTools()
        {
            calendar.Click();
            lastday.Click();
            if (lastday.Displayed == true)
            {
                Console.WriteLine("True");
            }
            return this;
        }
    }
}
