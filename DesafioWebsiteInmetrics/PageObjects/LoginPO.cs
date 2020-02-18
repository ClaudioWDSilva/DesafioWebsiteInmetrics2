using DesafioWebsiteInmetrics.Utils;
using DesafioWebsiteInmetrics.Wrapper;
using DesafioWebsiteInmetrics.WebDriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DesafioWebsiteInmetrics.PageObjects
{
    public class LoginPO : PageObjectsBase
    {
        #region :: Elementos

        private IWebElement inserirUsuario => Waiting.Until(x => ModalLogin.FindElement(By.Name("login")));

        private IWebElement inserirSenha => Waiting.Until(x => ModalLogin.FindElement(By.Name("password")));

        private IWebElement botaoEntrar => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='signinbox']/div[2]/a")));

        private IWebElement menuSignIn => Waiting.Until(x => x.FindElement(By.ClassName("modal-trigger")));

        private IWebElement ModalLogin => Waiting.Until(x => x.FindElement(By.Id("signinbox")));

        private IWebElement msgCamposObrigatorios => Waiting.Until(x => x.FindElement(By.Id("toast-container")));

        private IWebElement txtModalLogin => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='signinbox']/div[1]/form/div[1]")));

        private IWebElement tituloModalLogin => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='signinbox']/div[1]/form/h4")));

        private string textomodal = "Hey, seems like you have an account here. Well, what about fill your secret information and get access to your tasks? I assure that the information will not be shared with anyone.";

        private string txtMensagemObrigatorio = "Maybe you brain dropped the password or login in some place!";

        #endregion

        #region :: Ações da Tela

        private void AcessarTelaLogin()
        {
            WebDriverFactoryTST.AbrirNavegador(EnvironmentTST.RetornarUrl());
            WaitAvailabilityElement(By.ClassName("banner"));
            menuSignIn.Click();
            WaitElement(ModalLogin);
        }
        private void AcaoBotaoEntrar()
        {
            WaitElement(botaoEntrar);
            Thread.Sleep(500);
            botaoEntrar.Click();
        }

        private void ValidacoesModal()
        {
            Assert.AreEqual("Sign in", tituloModalLogin.Text);
            Assert.AreEqual(textomodal, txtModalLogin.Text);
        }

        #endregion

        #region :: Métodos para a Suíte

        internal void RealizarLoginSemPreencherCampos()
        {
            AcessarTelaLogin();
            ValidacoesModal();
            AcaoBotaoEntrar();
            Assert.AreEqual(txtMensagemObrigatorio, msgCamposObrigatorios.Text);
        }

        internal void RealizarLoginCamposInvalidos()
        {
            AcessarTelaLogin();
            Thread.Sleep(1000);
            inserirUsuario.Click();
            inserirUsuario.SendKeys("9999999999999999");
            inserirUsuario.SendKeys(Keys.Tab);
            inserirSenha.SendKeys("00000000000000000");
            AcaoBotaoEntrar();
            Assert.AreEqual(txtMensagemObrigatorio, msgCamposObrigatorios.Text);
        }

        internal void RealizarLogin()
        {
            AcessarTelaLogin();
            inserirUsuario.Click();
            inserirUsuario.SendKeys(usercad);
            inserirUsuario.SendKeys(Keys.Tab);
            inserirSenha.SendKeys(passcad);
            AcaoBotaoEntrar();
            Assert.AreEqual("Task it!", tituloPagina.Text);
            Assert.AreEqual("Hi, " + nomecad, saudacoesMe.Text);
        }

        #endregion



    }
}
