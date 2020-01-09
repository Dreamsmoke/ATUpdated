using NUnit.Framework;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Lab5.Driver;
using System.Drawing.Imaging;

namespace Lab5.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        private IWebDriver Driver = DriverInstance.GetInstance();
        private Steps.Steps steps = new Steps.Steps();
        private static string USERNAME = StringUtils.DataStringUsername;
        private static string PASSWORD = StringUtils.DataStringPassword;
        private static string INCORRECT_CITY = StringUtils.DataStringIncorrectCity;
        private static string EERROR_TEXT = StringUtils.DataStringError;


        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLogin()
        {
            Logger.InitLogger();
            try
            {
                steps.LoginOn(USERNAME, PASSWORD);                
                Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);

                var screenshot = Driver.TakeScreenshot();
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [Test]
        public void EnterIncorrecCity()
        {
            Logger.InitLogger();
            try
            {                
                steps.SearchingError(INCORRECT_CITY);
                Assert.AreEqual(EERROR_TEXT.Replace("\\r", "").Replace("\\n", ""), steps.SearchIncorrectCity());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot(); 
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [Test]
        public void ChooseAmountOfRoomsLessThanOne()
        {
            Logger.InitLogger();
            try
            {
                steps.DeletingRoom();
                Assert.AreEqual("1", steps.MinValueQuantityRooms());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        // Выбор количества комнат больше 10
        [Test]
        public void ChooseAmountOfRoomsMoreThanTen()
        {
            Logger.InitLogger();
            try
            {
                steps.AddingRoom();
                Assert.AreEqual("10", steps.MaxValueQuantityRooms());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        // Выбор количества детей меньше нуля
        [Test]
        public void ChooseAmountOfChildrenLessThanZero()
        {
            Logger.InitLogger();
            try
            {
                steps.DeletingСhild();
                Assert.AreEqual("0", steps.ZeroChildren());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        // Выбор количества детей больше 3
        [Test]
        public void ChooseAmountOfChildrenMoreThanTree()
        {
            Logger.InitLogger();
            try
            {
                steps.AddingChild();
                Assert.AreEqual("3", steps.MaxValueChildren());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "С:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
    }
}
