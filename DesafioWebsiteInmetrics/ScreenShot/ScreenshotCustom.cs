using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.ScreenShot
{
    public class ScreenshotCustom
    {
        #region Construtor 
        public ScreenshotCustom()
        {
        }
        #endregion

        #region :: Declarations         

        public IWebDriver _WebDriver;

        public IWebDriver WebDriver
        {
            get
            {
                if (_WebDriver is null)
                    _WebDriver = WebDriverFactory.WebDriverFactoryTST.GetDriver();

                return _WebDriver;
            }
        }

        #endregion

        #region :: Ações 
        public void ScreenShot()
        {
            var ss = ((ITakesScreenshot)WebDriver).GetScreenshot();
            var arquivo = string.Format(@"{0} \{1}.png", CriarPasta(), DateTime.Now.Ticks.ToString());
            ss.SaveAsFile(arquivo, ScreenshotImageFormat.Png);
        }

        private string CriarPasta()
        {
            // TestName é populado no testInitialize 
            string folder = string.Format(@"C:\EvidenciasTestes\{0}\{1}{2}", DateTime.Now.ToShortDateString().Replace("/", "-"), ScreenShotFields.TestName, ScreenShotFields.Token);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return folder;
        }
        #endregion
    }
}
