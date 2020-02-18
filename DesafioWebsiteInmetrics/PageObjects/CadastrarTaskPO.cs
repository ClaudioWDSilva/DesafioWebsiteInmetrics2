using DesafioWebsiteInmetrics.Wrapper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.PageObjects
{
    public class CadastrarTaskPO : PageObjectsBase
    {
        #region :: Declarações

        private IWebElement btnTelaTask => Waiting.Until(x => x.FindElement(By.ClassName("btn")));

        private IWebElement txtMyTasks => Waiting.Until(x => x.FindElement(By.XPath("/html/body/div[1]/div/div/h5")));

        private IWebElement txtMsgMyTasks => Waiting.Until(x => x.FindElement(By.XPath("/html/body/div[1]/div/div/p")));

        private IWebElement divContainer => Waiting.Until(x => x.FindElement(By.ClassName("container")));

        private IWebElement btnAddTask => Waiting.Until(x => divContainer.FindElement(By.ClassName("btn")));

        // Modal Add a New Task
        private IWebElement ModalAddTask => Waiting.Until(x => x.FindElement(By.Id("addtask")));

        private IWebElement tituloModalAddTask => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='addtask']/div[1]/h4")));

        private IWebElement msgModalAddTask => Waiting.Until(x => x.FindElement(By.XPath("//*[@id='addtask']/div[1]/div[1]")));

        private IWebElement titleTask => Waiting.Until(x => x.FindElement(By.Name("title")));

        private IWebElement dateLimitTask => Waiting.Until(x => x.FindElement(By.Id("P1267060638_root")));

        private IWebElement timeLimitTask => Waiting.Until(x => x.FindElement(By.ClassName("clockpicker")));

        private IWebElement TellUsTask => Waiting.Until(x => x.FindElement(By.Name("text")));

        private IWebElement comboDoneTask => Waiting.Until(x => x.FindElement(By.Name("done")));

        #endregion


        #region :: Métodos da Tela Cadasro de Task

        private void AcessarTelaAddTask()
        {
            LoginPO entrar = new LoginPO();
            entrar.RealizarLogin();
            btnTelaTask.Click();
            WaitElement(btnAddTask);
            btnAddTask.Click();
        }

        #endregion

    }
}
