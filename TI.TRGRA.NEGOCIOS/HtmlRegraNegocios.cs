using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.TRGRA.NEGOCIOS
{
    public class HtmlRegraNegocios
    {
        public string GerarLogo(string urlLogo, string nome, string url, string telefone)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<a href=\"" + url + ".aspx\" class=\"navbar-brand\">");
                sb.Append("<img class=\"imagelogo\" src=\"" + urlLogo + "\" height =\"50\" alt=\"CoolBrand\"/>");
                sb.Append("<p class=\"produtosIntTitulo\">" + telefone + "</p>");

                sb.Append("</a>");

                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
