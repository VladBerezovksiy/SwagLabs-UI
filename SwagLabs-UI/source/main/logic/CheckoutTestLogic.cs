using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagLabs_UI.source.main.element;
using SwagLabs_UI.source.main.utils;
using System.Text.RegularExpressions;

namespace SwagLabs_UI.source.main.logic
{
    internal class CheckoutTestLogic : MainLogic
    {

        private ElementsCheckoutPage elements;

        public CheckoutTestLogic(IWebDriver driver, WebDriverWait wait, ElementsCheckoutPage elements) : base(driver, wait, elements)
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


        public void VerifyCheckoutOneItem()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            string buttonTextBefore = elements.AddToCartBtn[0].Text;
            string expectedTitleText = elements.ProductTitleLink[0].Text;
            string expectedDescOfProductText = elements.ProductDescText[0].Text;
            string expectedPriceText = elements.ProductPriceText[0].Text;

            ClickWhenReady(elements.AddToCartBtn[0]);
            MakePause(2000);

            string buttonTextAfter = elements.AddToCartBtn[0].Text;

            Assert.AreNotEqual(buttonTextBefore, buttonTextAfter, "Didn't click on Add to Card button");

            Console.WriteLine("Card QTY = " + elements.IndexCart.Text);
            Assert.True(int.Parse(elements.IndexCart.Text).Equals(1));

            ClickWhenReady(elements.CartBtn);
            MakePause(2000);

            string actualTitleText = elements.ProductTitleInCart[0].Text;
            string actualDescOfProductText = elements.ProductDescInCart[0].Text;
            string actualPriceText = elements.ProductPriceInCart[0].Text;

            Assert.AreEqual(actualTitleText, expectedTitleText, "Product title isn't matched");
            Assert.AreEqual(actualDescOfProductText, expectedDescOfProductText, "Product description isn't matched");
            Assert.AreEqual(actualPriceText, expectedPriceText, "Product price isn't matched");

            ClickWhenReady(elements.ContinueShoppingButton);
            WaitForElementContainsText(elements.PageTitle, "Products");

            ClickWhenReady(elements.CartBtn);
            WaitForElementContainsText(elements.PageTitle, "Your Cart");

            ClickWhenReady(elements.CheckoutButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Your Information");

            WaitForVisible(elements.FirstNameInputField).Clear();
            WaitForVisible(elements.FirstNameInputField).SendKeys(Variables.FIRST_NAME);
            WaitForVisible(elements.LastNameInputField).Clear();
            WaitForVisible(elements.LastNameInputField).SendKeys(Variables.LAST_NAME);
            WaitForVisible(elements.ZipCodeInputField).Clear();
            WaitForVisible(elements.ZipCodeInputField).SendKeys(Variables.ZIP_CODE);

            ClickWhenReady(elements.CancelButton);
            WaitForElementContainsText(elements.PageTitle, "Your Cart");

            ClickWhenReady(elements.CheckoutButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Your Information");

            WaitForVisible(elements.FirstNameInputField).Clear();
            WaitForVisible(elements.FirstNameInputField).SendKeys(Variables.FIRST_NAME);
            WaitForVisible(elements.LastNameInputField).Clear();
            WaitForVisible(elements.LastNameInputField).SendKeys(Variables.LAST_NAME);
            WaitForVisible(elements.ZipCodeInputField).Clear();
            WaitForVisible(elements.ZipCodeInputField).SendKeys(Variables.ZIP_CODE);

            ClickWhenReady(elements.ContinueButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Overview");

            ClickWhenReady(elements.FinishButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Complete!");

            Assert.AreEqual(elements.FinishedOrderText.Text, "Thank you for your order!");
        }

        public void VerifyCheckoutSomeItems()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);

            string buttonTextBefore = elements.AddToCartBtn[0].Text;
            string expectedTitleText = elements.ProductTitleLink[0].Text;
            string expectedDescOfProductText = elements.ProductDescText[0].Text;
            string expectedPriceText = elements.ProductPriceText[0].Text;

            string buttonTextBefore1 = elements.AddToCartBtn[1].Text;
            string expectedTitleText1 = elements.ProductTitleLink[1].Text;
            string expectedDescOfProductText1 = elements.ProductDescText[1].Text;
            string expectedPriceText1 = elements.ProductPriceText[1].Text;

            ClickWhenReady(elements.AddToCartBtn[0]);
            ClickWhenReady(elements.AddToCartBtn[1]);
            MakePause(2000);

            string buttonTextAfter = elements.AddToCartBtn[0].Text;
            string buttonTextAfter1 = elements.AddToCartBtn[1].Text;

            Assert.AreNotEqual(buttonTextBefore, buttonTextAfter, "Didn't click on Add to Card button");
            Assert.AreNotEqual(buttonTextBefore1, buttonTextAfter1, "Didn't click on Add to Card button");

            Console.WriteLine("Card QTY = " + elements.IndexCart.Text);
            Assert.True(int.Parse(elements.IndexCart.Text).Equals(2));

            ClickWhenReady(elements.CartBtn);
            MakePause(2000);

            string actualTitleText = elements.ProductTitleInCart[0].Text;
            string actualDescOfProductText = elements.ProductDescInCart[0].Text;
            string actualPriceText = elements.ProductPriceInCart[0].Text;
            
            string actualTitleText1 = elements.ProductTitleInCart[1].Text;
            string actualDescOfProductText1 = elements.ProductDescInCart[1].Text;
            string actualPriceText1 = elements.ProductPriceInCart[1].Text;

            Assert.AreEqual(actualTitleText, expectedTitleText, "Product title isn't matched");
            Assert.AreEqual(actualDescOfProductText, expectedDescOfProductText, "Product description isn't matched");
            Assert.AreEqual(actualPriceText, expectedPriceText, "Product price isn't matched");
            
            Assert.AreEqual(actualTitleText1, expectedTitleText1, "Product title isn't matched");
            Assert.AreEqual(actualDescOfProductText1, expectedDescOfProductText1, "Product description isn't matched");
            Assert.AreEqual(actualPriceText1, expectedPriceText1, "Product price isn't matched");

            ClickWhenReady(elements.ContinueShoppingButton);
            WaitForElementContainsText(elements.PageTitle, "Products");

            ClickWhenReady(elements.CartBtn);
            WaitForElementContainsText(elements.PageTitle, "Your Cart");

            ClickWhenReady(elements.CheckoutButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Your Information");

            WaitForVisible(elements.FirstNameInputField).Clear();
            WaitForVisible(elements.FirstNameInputField).SendKeys(Variables.FIRST_NAME);
            WaitForVisible(elements.LastNameInputField).Clear();
            WaitForVisible(elements.LastNameInputField).SendKeys(Variables.LAST_NAME);
            WaitForVisible(elements.ZipCodeInputField).Clear();
            WaitForVisible(elements.ZipCodeInputField).SendKeys(Variables.ZIP_CODE);

            ClickWhenReady(elements.CancelButton);
            WaitForElementContainsText(elements.PageTitle, "Your Cart");

            ClickWhenReady(elements.CheckoutButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Your Information");

            WaitForVisible(elements.FirstNameInputField).Clear();
            WaitForVisible(elements.FirstNameInputField).SendKeys(Variables.FIRST_NAME);
            WaitForVisible(elements.LastNameInputField).Clear();
            WaitForVisible(elements.LastNameInputField).SendKeys(Variables.LAST_NAME);
            WaitForVisible(elements.ZipCodeInputField).Clear();
            WaitForVisible(elements.ZipCodeInputField).SendKeys(Variables.ZIP_CODE);

            ClickWhenReady(elements.ContinueButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Overview");

            ClickWhenReady(elements.FinishButton);
            WaitForElementContainsText(elements.PageTitle, "Checkout: Complete!");

            Assert.AreEqual(elements.FinishedOrderText.Text, "Thank you for your order!");
        }
    }
}
