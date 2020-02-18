using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.Utils
{
    public static class EnvironmentTST
    {
        public static string Ambiente;

        //TODO: Verificar indice dinamicamente
        public static int IntegranteRH
        {
            get
            {
                if (Ambiente == "Homol")
                    return 5;
                else
                    return 3;
            }
        }

        /// <summary>
        /// Retorna a Url 
        /// </summary>
        /// <returns>String url</returns>
        public static string RetornarUrl()
        {
            Ambiente = "Homol";
            return "http://www.juliodelima.com.br/taskit/";
        }

        /// <summary>
        /// Retorna o navegador que os testes devem rodar
        /// </summary>
        /// <returns>string Navegador</returns>
        internal static string RetornarBrowser()
        {
            //return "ie";

            return "chrome";

            //return "firefox";            
        }
    }
}
