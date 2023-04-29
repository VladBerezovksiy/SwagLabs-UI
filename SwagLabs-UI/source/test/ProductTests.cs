using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SwagLabs_UI.source.main.logic;
using SwagLabs_UI.source.main.utils;
using SwagLabs_UI.source.main.element;

namespace SwagLabs_UI.source.test
{
    internal class ProductTests
    {
        private IWebDriver driver;
        private ProductTestLogic logic;

        [SetUp]
        public void BeforeClass()
        {
            driver = DriverInstances.GetInstance(Settings.DRIVER);
            WebDriverWait wait = WebDriverWaitHelper.GenerateWaits(driver, 5, 30, 3);
            ElementsProductPage elements = new ElementsProductPage(driver);
            logic = new ProductTestLogic(driver, wait, elements);
            logic.getRootPage();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_01_CheckProductSortingNameFromAToZ()
        {
            logic.CheckProductSortingNameFromAToZ();
        }
        
        [Test]
        public void Test_02_CheckProductSortingNameFromZToA()
        {
            logic.CheckProductSortingNameFromZToA();
        }
        
        [Test]
        public void Test_03_CheckProductSortingPriceFromLowToHigh()
        {
            logic.CheckProductSortingPriceFromLowToHigh();
        }
        
        [Test]
        public void Test_04_CheckProductSortingPriceFromHighToLow()
        {
            logic.CheckProductSortingPriceFromHighToLow();
        }
        
        [Test]
        public void Test_05_AddProductToCheckout()
        {
            logic.AddProductToCheckout();
        }
        
        [Test]
        public void Test_06_CheckProductItemCard()
        {
            logic.CheckProductItemCard();
        }

    }
}
