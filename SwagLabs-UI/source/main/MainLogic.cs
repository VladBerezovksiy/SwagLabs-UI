using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SwagLabs_UI.source.main.utils;

namespace SwagLabs_UI.source.main
{
    internal abstract class MainLogic
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public BaseElements elements;

        public MainLogic(IWebDriver driver, WebDriverWait wait, BaseElements elements)
        {
            this.driver = driver;
            this.wait = wait;
            this.elements = elements;
        }


        public abstract void getRootPage();
        public abstract void backToRootPage();


        /****************************************************** WAITS ******************************************************/

        public void WaitForJSToBeLoaded()
        {
            wait.Until(webDriver => (IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete");
        }

        public IWebElement WaitForVisible(IWebElement element)
        {
            WaitForJSToBeLoaded();
            if (!element.Displayed)
            {
                Environment.Exit(1);
            }
            return element;
        }


        /****************************************************** WAITS ******************************************************/

        public IWebElement ClickWhenReady(IWebElement element)
        {
            WaitForJSToBeLoaded();
            WaitForVisible(element);
            wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
            return element;
        }

        /****************************************************** LOGIN ******************************************************/

        public void BrowseLoginPage()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Variables.SWAGLABS_URL);
            driver.Manage().Window.Maximize();
            WaitForJSToBeLoaded();
        }

        public void Login()
        {
            BrowseLoginPage();
            WaitForVisible(elements.UsernameInputField).Clear();
            WaitForVisible(elements.UsernameInputField).SendKeys(Variables.MAIN_ACCOUNT);
            WaitForVisible(elements.PasswordInputField).Clear();
            WaitForVisible(elements.PasswordInputField).SendKeys(Variables.MAIN_PASSWORD);
            ClickWhenReady(elements.LoginBtn);
            WaitForJSToBeLoaded();

        }
    }
}
