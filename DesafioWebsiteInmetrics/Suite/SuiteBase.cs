using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioWebsiteInmetrics.ScreenShot;
using DesafioWebsiteInmetrics.PageObjects;
using System.Diagnostics;

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

        public SignUpPO SignUpPO
        {
            get
            {
                if (_signUpPO is null)
                    _signUpPO = new SignUpPO();

                return _signUpPO;
            }
        }
        private SignUpPO _signUpPO;

        public LoginPO LoginPO
        {
            get
            {
                if (_loginPO is null)
                    _loginPO = new LoginPO();

                return _loginPO;
            }
        }
        private LoginPO _loginPO;

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
            WebDriverFactory.WebDriverFactoryTST.Close();
            // Fechar Processos do Chrome
            var processos = Process.GetProcessesByName("chromedriver");
            foreach (var p in processos)
                p.Kill();
        }
        #endregion
    }
}
