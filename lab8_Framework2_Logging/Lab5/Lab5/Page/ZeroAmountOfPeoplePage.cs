﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace Lab5.Page
{
    class ZeroAmountOfPeoplePage : AbstractPage
    {
        private const string BASE_URL = "https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1";
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".room-guest.room-guest-normal")]
        private IWebElement peopleBox;


        [FindsBy(How = How.XPath, Using = "//*[@id='ibu_hotel_container']/..//div[3]/div[3]/div/span[1]")]
        private IWebElement childMinus;

        [FindsBy(How = How.XPath, Using = "//*[@id='ibu_hotel_container']/..//div[3]/div[3]/div/span[2]")]
        private IWebElement childrenValue;

        public ZeroAmountOfPeoplePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public ZeroAmountOfPeoplePage GetStatiscBox()
        {
            peopleBox.Click();
            return new ZeroAmountOfPeoplePage(driver);
        }

        public ZeroAmountOfPeoplePage DeleteChild()
        {
            childMinus.Click();
            return new ZeroAmountOfPeoplePage(driver);
        }

        public string PositivValueAmountOfChildren()
        {
            var v = childrenValue.Text;
            return childrenValue.Text.ToString();
        }
    }
}
