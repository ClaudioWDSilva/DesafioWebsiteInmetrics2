using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioWebsiteInmetrics.Wrapper;

namespace DesafioWebsiteInmetrics.Utils
{
    public static class Util
    {
        /// <summary>
        /// Retorna texto da tabela 
        /// </summary>
        /// <param name="linha">int indice linha</param>
        /// <param name="coluna">int indice coluna</param>
        /// <param name="elementoTabela">HtmlTable tabela</param>
        /// <returns>string texto tabela</returns>
        public static string RetornarTextoTabela(int linha, int coluna, HtmlTable elementoTabela)
        {
            //Retorna Conteudo da Linha x Coluna
            return elementoTabela.GetCell(linha, coluna).WebElement.Text;
        }

        /// <summary>
        /// Acessa os menus dinamicamente, baseado nos indices
        /// </summary>
        /// <param name="indexsAcesso">list de int indices de acesso</param>
        /// <param name="menu">IwebElement menu</param>
        public static void AcessarMenu(List<int> indexsAcesso, IWebElement menu)
        {
            var listaMmenu = menu.FindElements(By.CssSelector("li"));

            for (int i = 0; i < indexsAcesso.Count; i++)
            {
                listaMmenu.ElementAt(indexsAcesso[i]).ClickCustom();

                //Se for o ultimo ciclo
                if (i == indexsAcesso.Count - 1)
                    continue;

                listaMmenu = listaMmenu.ElementAt(indexsAcesso[i]).FindElements(By.CssSelector("li"));
            }
        }
    }
}
