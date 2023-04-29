using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabs_UI.source.main
{
    internal class BaseElements
    {
        public BaseElements(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UsernameInputField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInputField { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginBtn { get; set; }


        /*************************************************** LOGOUT ******************************************************/

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement MenuBurgerBtn { get; set; }

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement LogoutBtn { get; set; }


        /*********************************************** HEADER ELEMENTS **************************************************/

        [FindsBy(How = How.CssSelector, Using = ".shopping_cart_link")]
        public IWebElement CartBtn { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = ".shopping_cart_link .shopping_cart_badge")]
        public IWebElement IndexCart { get; set; }

    }
}
