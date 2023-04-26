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
        public IWebElement UsernameInputField;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordInputField;

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginBtn;

    }
}
