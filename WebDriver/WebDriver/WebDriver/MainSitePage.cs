using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriver
{
    public static class MainSitePage
    {
        public static string pageUrl = "https://www.hotellook.ru/";
        public static string searchInputTagId = "search";
        public static string firstProductPath = "//*[@class='amhighlight']";

        public static string GetSearchFieldValue(string productName, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(pageUrl);
            IWebElement searchElement = driver.FindElement(By.Id(searchInputTagId));
            CartPage.SlowType(searchElement, productName);
            Thread.Sleep(3000);

            string prductTitle = driver.FindElement(By.XPath(firstProductPath)).Text;
            return prductTitle;
        }
    }
}
