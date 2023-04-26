using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs_UI.source.main.logic
{
    internal class LoginTestLogic : MainLogic
    {
        private BaseElements elements;

        public LoginTestLogic(IWebDriver driver, WebDriverWait wait, BaseElements elements) : base(driver, wait, elements)
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


        public void Check()
        {
            Login();
            Console.WriteLine("VLADOS!!!");
        }
    }
}
