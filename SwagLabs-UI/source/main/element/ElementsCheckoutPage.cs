using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabs_UI.source.main.element
{
    internal class ElementsCheckoutPage : ElementsProductPage
    {
        public ElementsCheckoutPage(IWebDriver driver) : base(driver)
        {}


        [FindsBy(How = How.CssSelector, Using = ".header_secondary_container span")]
        public IWebElement PageTitle { get; set; }


        /****************************************************** CART PAGE ********************************************************/

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement CheckoutButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "continue-shopping")]
        public IWebElement ContinueShoppingButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_name")]
        public IList<IWebElement> ProductTitleInCart { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_desc")]
        public IList<IWebElement> ProductDescInCart { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_price")]
        public IList<IWebElement> ProductPriceInCart { get; set; }


        /************************************************* CHECKOUT PAGE ********************************************************/

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement FirstNameInputField { get; set; }
        
        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement LastNameInputField { get; set; }
        
        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement ZipCodeInputField { get; set; }
        
        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement ContinueButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "cancel")]
        public IWebElement CancelButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".summary_subtotal_label")]
        public IWebElement ItemPriceText { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".summary_tax_label")]
        public IWebElement TaxPriceText { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".summary_total_label")]
        public IWebElement TotalPriceText { get; set; }
        
        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement FinishButton { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".complete-header")]
        public IWebElement FinishedOrderText { get; set; }

    }
}
