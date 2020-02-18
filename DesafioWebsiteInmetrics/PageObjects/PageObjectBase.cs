using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DesafioWebsiteInmetrics.Utils;

namespace DesafioWebsiteInmetrics.PageObjects
{
    //Herdar esta classe em todos PageObjects 
    public abstract class PageObjectsBase
    {

        #region :: Construtor

        public PageObjectsBase()
        {
            PageFactory.InitElements(WebDriver, this);
        }

        #endregion


        /*#region :: Declaração de Datas

        public string dataAtual = Util.DataAtual();

        public string dataRetroativa = Util.DataRetroativaUtil();

        protected ApplicationUnderTest applicationUnderTest;

        #endregion*/

        #region :: Variáveis

        public string nomecad = "Claudio W D Silva";
        public string usercad = "claudio.wds.silva";
        public string passcad = "SenhaForte";

        public IWebElement tituloPagina => Waiting.Until(x => x.FindElement(By.ClassName("brand-logo")));

        public IWebElement saudacoesMe => Waiting.Until(x => x.FindElement(By.ClassName("me")));

        #endregion

        #region :: Declarations

        private IWebDriver _WebDriver;
        TimeSpan TimeOut = TimeSpan.FromSeconds(60);

        protected WebDriverWait Waiting => new WebDriverWait(WebDriver, TimeOut);

        protected IWebDriver WebDriver
        {
            get
            {
                if (_WebDriver is null)
                    _WebDriver = WebDriverFactory.WebDriverFactoryTST.GetDriver();

                return _WebDriver;
            }
        }

        

        protected WebDriverWait Wait
        {
            get
            {
                return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(200));
            }
        }

        

        #endregion


        #region :: Ações 

        /// <summary>
        /// Aguarda que um elemento desapareça da tela
        /// </summary>
        /// <param name="acao">By com a condição de busca do elemento</param>
        protected void Loading(By acao)
        {
            //Thread.Sleep(1000);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(acao));
        }

        /// <summary>
        /// Aguarda que um elemento seja clicavel 
        /// </summary>
        /// <param name="acao">By com a condição de busca do elemento</param>
        protected void WaitElement(By acao)
        {
            TimeSpan.FromSeconds(10);
            Wait.Until(ExpectedConditions.ElementToBeClickable(acao));
        }

        /// <summary>
        /// Aguarda que um elemento seja clicavel 
        /// </summary>
        /// <param name="acao">IwebElement elemento para aguardar</param>
        protected void WaitElement(IWebElement element)
        {
            TimeSpan.FromSeconds(10);
            Wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        /// Aguarda disponibilidade do elemento
        /// </summary>
        /// <param name="element"></param>
        protected void WaitAvailabilityElement(By by)
        {
            //Thread.Sleep(3000);
            TimeSpan.FromSeconds(10);
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        #endregion
    }
}
