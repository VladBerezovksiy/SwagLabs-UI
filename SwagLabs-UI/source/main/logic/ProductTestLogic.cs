using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagLabs_UI.source.main.element;
using SwagLabs_UI.source.main.utils;
using System.Text.RegularExpressions;

namespace SwagLabs_UI.source.main.logic
{
    internal class ProductTestLogic : MainLogic
    {

        private ElementsProductPage elements;

        public ProductTestLogic(IWebDriver driver, WebDriverWait wait, ElementsProductPage elements) : base(driver, wait, elements)
        {
            this.elements = elements;
        }

        public void setElement(ElementsProductPage elements)
        {
            this.elements = elements;
        }

        public override void backToRootPage()
        {
            BrowseLoginPage();
        }

        public override void getRootPage()
        {
            BrowseLoginPage();
        }


        public void CheckProductSortingNameFromAToZ()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            IList<IWebElement> productBeforeSort = elements.ProductTitleLink;
            List<string> productValueBeforeSort = productBeforeSort.Select(m => m.Text).ToList();
            List<string> productValueToLowercaseBeforeSort = productValueBeforeSort.Select(m => m.ToLower()).ToList();

            SelectDropDownOptions(elements.ProductSortDropDownBtn, elements.ProductSortDropDownBtn, elements.ProductSortDropDownOptions, 0);
            MakePause(2000);

            IList<IWebElement> productAfterSort = elements.ProductTitleLink;
            List<string> productValueAfterSort = productAfterSort.Select(m => m.Text).ToList();
            List<string> productValueToLowercaseAfterSort = productValueAfterSort.Select(m => m.ToLower()).ToList();

            List<string> productValueSortedByValue = new List<string>(productValueToLowercaseBeforeSort);
            productValueSortedByValue.Sort();

            Assert.AreEqual(productValueSortedByValue, productValueToLowercaseAfterSort, "Products are not sorted correctly");
        }

        public void CheckProductSortingNameFromZToA()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            IList<IWebElement> productBeforeSort = elements.ProductTitleLink;
            List<string> productValueBeforeSort = productBeforeSort.Select(m => m.Text).ToList();
            List<string> productValueToLowercaseBeforeSort = productValueBeforeSort.Select(m => m.ToLower()).ToList();

            SelectDropDownOptions(elements.ProductSortDropDownBtn, elements.ProductSortDropDownBtn, elements.ProductSortDropDownOptions, 1);
            MakePause(2000);

            IList<IWebElement> productAfterSort = elements.ProductTitleLink;
            List<string> productValueAfterSort = productAfterSort.Select(m => m.Text).ToList();
            List<string> productValueToLowercaseAfterSort = productValueAfterSort.Select(m => m.ToLower()).ToList();

            List<string> productValueSortedByValue = new List<string>(productValueToLowercaseBeforeSort);
            productValueSortedByValue.Sort();
            productValueSortedByValue.Reverse();

            Assert.AreEqual(productValueSortedByValue, productValueToLowercaseAfterSort, "Products are not sorted correctly");
        }

        public void CheckProductSortingPriceFromLowToHigh()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            IList<IWebElement> productBeforeSort = elements.ProductPriceText;
            List<string> productValueBeforeSort = productBeforeSort.Select(m => Regex.Match(m.Text, @"\d+").Value).ToList();
            List<int> productValueToLowercaseBeforeSort = productValueBeforeSort.Select(m => int.Parse(m)).ToList();

            SelectDropDownOptions(elements.ProductSortDropDownBtn, elements.ProductSortDropDownBtn, elements.ProductSortDropDownOptions, 2);
            MakePause(2000);

            IList<IWebElement> productAfterSort = elements.ProductPriceText;
            List<string> productValueAfterSort = productAfterSort.Select(m => Regex.Match(m.Text, @"\d+").Value).ToList();
            List<int> productValueToLowercaseAfterSort = productValueAfterSort.Select(m => int.Parse(m)).ToList();

            List<int> productValueSortedByValue = new List<int>(productValueToLowercaseBeforeSort);
            productValueSortedByValue.Sort();

            Assert.AreEqual(productValueSortedByValue, productValueToLowercaseAfterSort, "Products are not sorted correctly");

        }

        public void CheckProductSortingPriceFromHighToLow()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            IList<IWebElement> productBeforeSort = elements.ProductPriceText;
            List<string> productValueBeforeSort = productBeforeSort.Select(m => Regex.Match(m.Text, @"\d+").Value).ToList();
            List<int> productValueToLowercaseBeforeSort = productValueBeforeSort.Select(m => int.Parse(m)).ToList();

            SelectDropDownOptions(elements.ProductSortDropDownBtn, elements.ProductSortDropDownBtn, elements.ProductSortDropDownOptions, 3);
            MakePause(2000);

            IList<IWebElement> productAfterSort = elements.ProductPriceText;
            List<string> productValueAfterSort = productAfterSort.Select(m => Regex.Match(m.Text, @"\d+").Value).ToList();
            List<int> productValueToLowercaseAfterSort = productValueAfterSort.Select(m => int.Parse(m)).ToList();

            List<int> productValueSortedByValue = new List<int>(productValueToLowercaseBeforeSort);
            productValueSortedByValue.Sort();
            productValueSortedByValue.Reverse();

            Assert.AreEqual(productValueSortedByValue, productValueToLowercaseAfterSort, "Products are not sorted correctly");
        }

        public void AddProductToCheckout()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            string buttonTextBefore = elements.AddToCartBtn[0].Text;
            ClickWhenReady(elements.AddToCartBtn[0]);
            MakePause(2000);

            string buttonTextAfter = elements.AddToCartBtn[0].Text;

            Assert.AreNotEqual(buttonTextBefore, buttonTextAfter, "Didn't click on Add to Card button");

            Console.WriteLine("Card QTY = " + elements.IndexCart.Text);
            Assert.True(int.Parse(elements.IndexCart.Text).Equals(1));
        }

        public void CheckProductItemCard()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            string expectedTitleText = elements.ProductTitleLink[0].Text;
            string expectedDescOfProductText = elements.ProductDescText[0].Text;
            string expectedPriceText = elements.ProductPriceText[0].Text;

            ClickWhenReady(elements.ProductTitleLink[0]);
            WaitForJSToBeLoaded();

            string actualTitleText = elements.ProductTitleLinkInCard.Text;
            string actualDescOfProductText = elements.ProductDescTextInCard.Text;
            string actualPriceText = elements.ProductPriceTextInCard.Text;

            Assert.AreEqual(actualTitleText, expectedTitleText, "Product title isn't matched");
            Assert.AreEqual(actualDescOfProductText, expectedDescOfProductText, "Product description isn't matched");
            Assert.AreEqual(actualPriceText, expectedPriceText, "Product price isn't matched");
        }
    }
}
