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

        public string GerarStatusEstabelcimento(string abertura, string fechamento)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                DateTime HoraAtual = DateTime.Now;

                string variavelHora = DateTime.Now.ToString();

                if (Convert.ToDateTime(abertura) > Convert.ToDateTime(variavelHora))
                {
                    sb.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                    sb.Append("Estabelecimento Fechado!");
                    sb.Append("</div>");
                }
                else
                {
                    if (Convert.ToDateTime(variavelHora) < Convert.ToDateTime(fechamento))
                    {
                        sb.Append("<div class=\"alert alert-warning\" role=\"alert\">");
                        sb.Append("Estabelecimento Aberto!");
                        sb.Append("</div>");
                    }
                    else
                    {
                        sb.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                        sb.Append("Estabelecimento Fechado!");
                        sb.Append("</div>");
                    }
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
