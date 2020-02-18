using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.Suite
{
    [TestClass]
    public class SuiteLogin : SuiteBase
    {
        [TestMethod]
        public void CN0001_RealizarLoginSemPreencherCampos()
        {
            LoginPO.RealizarLoginSemPreencherCampos();
        }

        [TestMethod]
        public void CN0002_RealizarLoginCamposInvalidos()
        {
            LoginPO.RealizarLoginCamposInvalidos();
        }

        [TestMethod]
        public void CN0003_RealizarLogin()
        {
            LoginPO.RealizarLogin();
        }
    }
}
