using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.Utils
{
    public static class EnvironmentMps
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
            //Suporte
            Ambiente = "Suporte";
            return "http://tst04.tjsp.jus.br/RHF/SubstituicaoSuporte/default.aspx";

            //Homol
            //Ambiente = "Homol";
            //return "http://tst04.tjsp.jus.br/RHF/Substituicao/default.aspx";
        }

        /// <summary>
        /// Retorna o navegador que os testes devem rodar
        /// </summary>
        /// <returns>string Navegador</returns>
        internal static string RetornarBrowser()
        {
            return "ie";

            //return "chrome";

            //return "firefox";            
        }
    }
}
