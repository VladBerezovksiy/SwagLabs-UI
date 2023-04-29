using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabs_UI.source.main.element
{
    internal class ElementsProductPage : BaseElements
    {
        public ElementsProductPage(IWebDriver driver) : base(driver)
        {}


        [FindsBy(How = How.CssSelector, Using = ".product_sort_container")]
        public IWebElement ProductSortDropDownBtn { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".product_sort_container option")]
        public IList<IWebElement> ProductSortDropDownOptions { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".pricebar button")]
        public IList<IWebElement> AddToCartBtn { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_label a")]
        public IList<IWebElement> ProductTitleLink { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_price")]
        public IList<IWebElement> ProductPriceText { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".inventory_item_desc")]
        public IList<IWebElement> ProductDescText { get; set; }


        /************************************************ ELEMENTS IN PRODUCT CARD ************************************************/

        [FindsBy(How = How.CssSelector, Using = ".inventory_details_name")]
        public IWebElement ProductTitleLinkInCard { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_details_price")]
        public IWebElement ProductPriceTextInCard { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_details_desc")]
        public IWebElement ProductDescTextInCard { get; set; }

    }
}
