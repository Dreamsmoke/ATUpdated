using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    class MinValueRoomsPage : AbstractPage
    {
        private const string BASE_URL = "https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1";
        private IWebDriver driver;
        
        [FindsBy(How = How.CssSelector, Using = ".room-guest.room-guest-normal")]
        private IWebElement peopleBox;

        //*[@id="ibu_hotel_container"]/..//div/span[1]/i
        [FindsBy(How = How.XPath, Using = "//*[@id='ibu_hotel_container']/..//div/span[1]/i")]
        private IWebElement roomMinus;
        //*[@id='ibu_hotel_container']/..//div[3]/div[1]/div/span[2]
        [FindsBy(How = How.XPath, Using = "//*[@id='ibu_hotel_container']/..//div[3]/div[1]/div/span[2]")]
        private IWebElement roomsValue;

        public MinValueRoomsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public MinValueRoomsPage GetStatiscBox()
        {
            peopleBox.Click();
            return new MinValueRoomsPage(driver);
        }

        public MinValueRoomsPage DeleteRoom()
        {
            roomMinus.Click();
            return new MinValueRoomsPage(driver);
        }

        public string GetMinValueRooms()
        {
            var v = roomsValue.Text;
            return roomsValue.Text.ToString();
        }
    }
}
