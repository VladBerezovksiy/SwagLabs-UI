using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace SwagLabs_UI.source.main.utils
{
    internal class DriverInstances
    {

        private static Dictionary<string, IWebDriver> webDriverInstances = new Dictionary<string, IWebDriver>();

        private DriverInstances()
        {
        }

        public static IWebDriver GetInstance(string driverType)
        {
            IWebDriver webDriver = null;

            if (webDriverInstances.ContainsKey(driverType))
            {
                webDriver = webDriverInstances[driverType];
            }

            switch (driverType.ToUpper())
            {
                case Variables.GOOGLE_CHROME:
                    webDriver = new ChromeDriver();
                    break;

                case Variables.FIREFOX:
                    webDriver = new FirefoxDriver();
                    break;

                case Variables.INTERNET_EXPLORER:
                    webDriver = new InternetExplorerDriver();
                    break;

                case Variables.EDGE:
                    webDriver = new EdgeDriver();
                    break;

                default:
                    Console.WriteLine("Empty or invalid browser type: " + driverType);
                    Environment.Exit(1);
                    break;
            }

            if(webDriver == null)
            {
                webDriverInstances[driverType] = webDriver;
            }
            Console.WriteLine("New WebDriver instance has been initialized: " + driverType);
            //webDriver.Manage().Timeouts().ToString.SetS(TimeSpan.FromSeconds(60));
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            return webDriver;
        }

    }
}
