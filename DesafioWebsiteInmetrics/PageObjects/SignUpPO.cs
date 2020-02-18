using DesafioWebsiteInmetrics.Utils;
using DesafioWebsiteInmetrics.WebDriverFactory;
using DesafioWebsiteInmetrics.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.PageObjects
{
    public class SignUpPO : PageObjectsBase
    {
        #region :: Elementos

        public IWebElement ModalSignUp => Waiting.Until(x => x.FindElement(By.Id("signupbox")));

        public IWebElement TituloModal => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='signupbox']/div[1]/form/h4")));

        public IWebElement msgModal => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='signupbox']/div[1]/form/div[1]")));

        public IWebElement inputName => Waiting.Until(x => x.FindElement(By.Name("name")));

        public IWebElement inputLogin => Waiting.Until(x => x.FindElement(By.Name("login")));

        public IWebElement inputPassWord => Waiting.Until(x => x.FindElement(By.Name("password")));

        public IWebElement btnSave => Waiting.Until(x => x.FindElement(By.ClassName("btn-flat")));

        public IWebElement toastMessage => Waiting.Until(x => x.FindElement(By.Id("toast-container")));

        public IWebElement divCadastrado => Waiting.Until(x => x.FindElement(By.ClassName("section center")));

        public IWebElement btnCadastrar => Waiting.Until(x => x.FindElement(By.Id("signup")));

        private string msgToast = "Someone choose this login before, please pick another!";
        //private string nomecad = "Claudio W D Silva";
        //private string usercad = "claudio.wd.silva";
        //private string passcad = "SenhaForte";

        #endregion


        #region :: Métodos da tela Sign Up

        private void AcessarTelaCadastro()
        {
            WebDriverFactoryTST.AbrirNavegador(EnvironmentTST.RetornarUrl());
            WaitAvailabilityElement(By.ClassName("banner"));
            btnCadastrar.Click();
            WaitElement(ModalSignUp);
        }

        private void PreencherCamposModalSignUp()
        {
            inputName.SendKeys(nomecad);
            inputLogin.SendKeys(usercad);
            inputPassWord.SendKeys(passcad);
        }

        private void AcaoClicarModalSignUp()
        {
            btnSave.Click();
        }

        private void ValidarMensagemToast()
        {
            WaitElement(toastMessage);
            Assert.AreEqual(msgToast, toastMessage.Text);
            Loading(By.Id("toast-container"));
        }


        #endregion


        #region :: Métodos acessíveis pela Suíte

        internal void CriarUsuarioSemName()
        {
            AcessarTelaCadastro();
            inputLogin.SendKeys(usercad);
            inputPassWord.SendKeys(passcad);
            AcaoClicarModalSignUp();
        }

        internal void CriarUsuarioSemLogin()
        {
            AcessarTelaCadastro();
            inputName.SendKeys(nomecad);
            inputPassWord.SendKeys(passcad);
            AcaoClicarModalSignUp();
            ValidarMensagemToast();
        }

        internal void CriarUsuarioSemPassWord()
        {
            AcessarTelaCadastro();
            inputName.SendKeys(nomecad);
            inputLogin.SendKeys(usercad);
            AcaoClicarModalSignUp();
        }

        internal void CriarUsuario()
        {
            AcessarTelaCadastro();
            PreencherCamposModalSignUp();
            AcaoClicarModalSignUp();
            WaitAvailabilityElement(By.ClassName("banner")); // Aguardar carregamento do Banner
            Assert.AreEqual("Task it!", tituloPagina.Text);
            Assert.AreEqual("Hi, " + nomecad, saudacoesMe.Text);
        }

        #endregion

    }
}
