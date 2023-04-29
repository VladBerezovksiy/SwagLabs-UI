using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SwagLabs_UI.source.main.element;
using SwagLabs_UI.source.main.logic;
using SwagLabs_UI.source.main.utils;

namespace SwagLabs_UI.source.test
{
    internal class CheckoutTests
    {
        private IWebDriver driver;
        private CheckoutTestLogic logic;

        [SetUp]
        public void BeforeClass()
        {
            driver = DriverInstances.GetInstance(Settings.DRIVER);
            WebDriverWait wait = WebDriverWaitHelper.GenerateWaits(driver, 5, 30, 3);
            ElementsCheckoutPage elements = new ElementsCheckoutPage(driver);
            logic = new CheckoutTestLogic(driver, wait, elements);
            logic.getRootPage();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_01_VerifyCheckoutOneItem()
        {
            logic.VerifyCheckoutOneItem();
        }
        
        [Test]
        public void Test_01_VerifyCheckoutSomeItems()
        {
            logic.VerifyCheckoutSomeItems();
        }

    }
}
