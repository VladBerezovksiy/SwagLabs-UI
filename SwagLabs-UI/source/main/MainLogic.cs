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

        public IWebElement WaitForElementContainsText(IWebElement element, string text)
        {
            WaitForJSToBeLoaded();
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            return element;
        }


        /****************************************************** ACTIONS ******************************************************/

        public IWebElement ClickWhenReady(IWebElement element)
        {
            WaitForJSToBeLoaded();
            WaitForVisible(element);
            wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
            return element;
        }

        public IWebElement JsClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return element;
        }


        /********************************************** OPERATION WITH ELEMENTS ********************************************/

        public void SelectDropDownOptions(IWebElement dropDownButton, IWebElement dropDownView,
            IList<IWebElement> dropDownOptions, int index)
        {
            ClickWhenReady(dropDownButton);
            WaitForVisible(dropDownView);
            string selectedText = dropDownOptions[index].Text;
            ClickWhenReady(dropDownOptions[index]);
            Console.WriteLine(selectedText);
            WaitForElementContainsText(dropDownButton, selectedText);
        }


        /****************************************************** OTHER ******************************************************/

        public void MakePause(int millis)
        {
            Thread.Sleep(millis);
        }

        /****************************************************** LOGIN ******************************************************/

        public void BrowseLoginPage()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(Variables.SWAGLABS_URL);
            driver.Manage().Window.Maximize();
            WaitForJSToBeLoaded();
        }

        public void Login(string username, string password)
        {
            BrowseLoginPage();
            WaitForVisible(elements.UsernameInputField).Clear();
            WaitForVisible(elements.UsernameInputField).SendKeys(username);
            WaitForVisible(elements.PasswordInputField).Clear();
            WaitForVisible(elements.PasswordInputField).SendKeys(password);
            ClickWhenReady(elements.LoginBtn);
            WaitForJSToBeLoaded();
            WaitForVisible(elements.MenuBurgerBtn);
        }

        public void Logout()
        {
            WaitForJSToBeLoaded();
            ClickWhenReady(elements.MenuBurgerBtn);
            MakePause(2000);
            ClickWhenReady(elements.LogoutBtn);
            WaitForJSToBeLoaded();
            WaitForVisible(elements.UsernameInputField);
            WaitForVisible(elements.PasswordInputField);
            WaitForVisible(elements.LoginBtn);
        }
    }
}
