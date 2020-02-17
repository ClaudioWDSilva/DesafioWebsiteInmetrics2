using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioWebsiteInmetrics.ScreenShot;

namespace DesafioWebsiteInmetrics.Suite
{
    //Herdar esta classe em todos Suites
    public abstract class SuiteBase
    {

        #region :: Declarações         

        public TestContext TestContext
        {
            get => testContextInstance;
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        #endregion

        #region :: Métodos pré e pós execução. 

        [TestInitialize()]
        public virtual void TesteInit()
        {
            //Armazena o nome do teste e token para o screenshot
            ScreenShotFields.Token = DateTime.Now.ToLongTimeString().Replace(":", "");
            ScreenShotFields.TestName = TestContext.TestName;
        }

        [TestCleanup()]
        public void TestFinish()
        {
            new ScreenshotCustom().ScreenShot();
            WebDriverFactory.WebDriverFactoryMps.Close();
        }
        #endregion
    }
}
