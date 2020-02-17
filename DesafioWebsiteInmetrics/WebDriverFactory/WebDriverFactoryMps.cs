using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.WebDriverFactory
{
    public static class WebDriverFactoryMps
    {
        #region :: Declarações 

        private static InternetExplorerOptions Options
        {
            get
            {
                var options = new InternetExplorerOptions()
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                };

                return options;
            }

        }

        private static IWebDriver webDriver { get; set; }

        #endregion

        #region :: Metodos 
        public static void AbrirNavegador(string url)
        {
            var driver = GetDriver();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver GetDriver()
        {
            if (webDriver != null)
                return webDriver;

            switch (Utils.EnvironmentMps.RetornarBrowser())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "ie":
                    webDriver = new InternetExplorerDriver(Options);
                    break;
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }

            return webDriver;
        }

        public static void Close()
        {
            webDriver.Close();
            webDriver = null;
        }
        #endregion
    }
}
