using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs_UI.source.main.utils
{
    internal class WebDriverWaitHelper
    {
        public static WebDriverWait GenerateWaits(IWebDriver driver, int iWait, int eWait, int pollingTime)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(iWait);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(eWait));
            wait.PollingInterval = TimeSpan.FromSeconds(pollingTime);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.IgnoreExceptionTypes(typeof(WebDriverException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }
    }
}
