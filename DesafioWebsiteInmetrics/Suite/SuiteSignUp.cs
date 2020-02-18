using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.Suite
{
    [TestClass]
    public class SuiteSignUp : SuiteBase
    {
        [TestMethod]
        public void CN0001_CriarUsuarioSemName()
        {
            SignUpPO.CriarUsuarioSemName();
        }

        [TestMethod]
        public void CN0002_CriarUsuarioSemLogin()
        {
            SignUpPO.CriarUsuarioSemLogin();
        }

        [TestMethod]
        public void CN0003_CriarUsuarioSemPassWord()
        {
            SignUpPO.CriarUsuarioSemPassWord();
        }

        [TestMethod]
        public void CN0004_CriarUsuario()
        {
            SignUpPO.CriarUsuario();
        }
    }
}
