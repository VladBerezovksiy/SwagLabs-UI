using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagLabs_UI.source.main;
using SwagLabs_UI.source.main.logic;
using SwagLabs_UI.source.main.utils;

namespace SwagLabs_UI.source.test
{
    internal class LoginTests
    {
        private IWebDriver driver;
        private LoginTestLogic logic;

        [SetUp]
        public void BeforeClass()
        {
            driver = DriverInstances.GetInstance(Settings.DRIVER);
            WebDriverWait wait = WebDriverWaitHelper.GenerateWaits(driver, 5, 30, 3);
            BaseElements elements = new BaseElements(driver);
            logic = new LoginTestLogic(driver, wait, elements);
            logic.getRootPage();
        }

        [Test]
        public void Test_01()
        {
            logic.Check();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        } 
    }
}
