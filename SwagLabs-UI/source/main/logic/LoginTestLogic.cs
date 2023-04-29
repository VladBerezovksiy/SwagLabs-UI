using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SwagLabs_UI.source.main.utils;

namespace SwagLabs_UI.source.main.logic
{
    internal class LoginTestLogic : MainLogic
    {
        public LoginTestLogic(IWebDriver driver, WebDriverWait wait, BaseElements elements) : base(driver, wait, elements)
        {}

        public override void backToRootPage()
        {
            BrowseLoginPage();
        }

        public override void getRootPage()
        {
            BrowseLoginPage();
        }


        public void VerificationOnTheMainPage()
        {
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);
            Logout();
        }

        private void IncorrectEnterValues()
        {
            BrowseLoginPage();
            WaitForVisible(elements.UsernameInputField).Clear();
            WaitForVisible(elements.UsernameInputField).SendKeys(Variables.NONEXISTENT_EMAIL);
            WaitForVisible(elements.PasswordInputField).Clear();
            WaitForVisible(elements.PasswordInputField).SendKeys(Variables.INCORRECT_PASSWORD);
            ClickWhenReady(elements.LoginBtn);
            WaitForJSToBeLoaded();
        }
        public void CheckLoginPage()
        {
            IncorrectEnterValues();
            Login(Variables.MAIN_ACCOUNT, Variables.MAIN_PASSWORD);
            Logout();
        }
    }
}
