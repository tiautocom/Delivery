using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.ACESSO.DADOS;

namespace TI.REGRA.NEGOCIOS
{
    public class DepartamentoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        string qtdes = "quant";

        public string GerarIndex(int id, string url, string descrica, string detalhes, string preco, int cont, string tel)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<div class=\"col-lg-3 col-md-4 col-sm-6 portfolio-item\" style=\"width:20rem; height:33rem\">");
                sb.Append("<div class=\"row main-low-margin text-center\">");
                sb.Append("<div class=\"card-deck\">");
                sb.Append("<div class=\"card\">");
                sb.Append("<a data-toggle=\"modal\" data-target=\"#myModal" + id + "\">");
                sb.Append("<img class=\"card-img-top\" src=\"" + url + "\" alt=\"" + descrica + "\" height=\"300\" width=\"200\"/>");
                sb.Append("<div class\"card-body\">");
                sb.Append("<h5 class=\"card-title\">" + descrica + "</h5>");
                sb.Append("<strong class=\"strong-preco\"> R$" + preco + "</strong>");
                sb.Append("<p class=\"card-text\">" + detalhes + ".</p>");
                sb.Append("<br>");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"card-footer\">");
                sb.Append("<small class=\"text-muted\">Atualizados 3 minutos atrás</small>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                if (cont == 4)
                {
                    sb.Append("<br>");
                    sb.Append("<br>");
                    sb.Append("<br>");
                    sb.Append("<br>");
                    sb.Append("<br>");
                    sb.Append("<br>");
                }

                sb.Append("<div class=\"modal fade\" id=\"myModal" + id + "\">");
                sb.Append("<div class=\"modal-dialog modal-lg\">");
                sb.Append("<div class=\"modal-content\">");

                sb.Append("<div class=\"modal-header\">");
                sb.Append("<h5 class=\"modal-title\" id=\"TituloModalCentralizado\">" + descrica + "</h5>");
                sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Fechar\">");
                sb.Append("<span aria-hidden=\"true\">&times;</span>");
                sb.Append("</button>");
                sb.Append("</div>");

                sb.Append("<div class=\"card mb-3\">");
                sb.Append("<div class=\"bg-image hover-overlay ripple\" data-mdb-ripple-color=\"light\">");
                sb.Append("<img src=\"" + url + "\" height=\"400px\" width=\"100%\"");
                sb.Append("class=\"img-fluid\"/>");
                sb.Append("<a href ==\"#!\">");
                sb.Append("<div class=\"mask\" style=\"background-color: rgba(251, 251, 251, 0.15);\"></div>");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"card-body\">");
                sb.Append("<h5 class=\"card-title\">");
                sb.Append("<td><span class=\"preco-produto\">R$ " + preco + "</span></td>");
                sb.Append("</h5>");
                sb.Append("<p class=\"card-text\">");
                sb.Append("" + detalhes + "");
                sb.Append("</p>");

                sb.Append("<div class=\"card mb-3\">");
                sb.Append("<textarea id=\"txtObs" + id + "\" style=\"height: 64px; width=\"100%\" placeholder=\"Ex. Sem Maionese\"></textarea>");
                sb.Append("</div>");
                sb.Append("<strong>");

                sb.Append("<tfoot>");
                sb.Append("<tr>");
                sb.Append("<td class=\"texto-total\">Total da Compra </td>");
                sb.Append("<td><span id=\"total\">R$: " + preco + "</span></td>");
                sb.Append("</tr>");
                sb.Append("</tfoot>");
                sb.Append("</strong>");

                sb.Append("<div class=\"modal-footer\">");

                sb.Append("<div data-app=\"product.quantity\" class=\"quantidade" + id + "\">");
                sb.Append("<span id=\"span_erro_carrinho\" class=\"blocoAlerta\" style=\"display:none;\">Selecione uma opção para variação do produto</span>");
                sb.Append("<strong>Quantidade:</strong>");
                sb.Append("<input class=\"btn btn-danger\" type=\"button\" width=\"50px\" id=\"plus" + id + "\" value='-' onclick=\"processar" + id + "(-1)\"/>");
                sb.Append("<input class=\"btn btn-outline-dark\" id=\"quant" + id + "\" name=\"quant" + id + "\" class=\"text\" size=\"1\" type=\"text\" value=\"1\" maxlength=\"5\"/>");
                sb.Append("<input class=\"btn btn-success\" type=\"button\" id=\"minus" + id + "\" value='+' onclick=\"processar" + id + "(1)\">");

                sb.Append("</div>");

                sb.Append("<button type=\"button\" id=\"adicionar1\" id=\"produto1\" onclick=\"AddCarrinho('" + descrica + "', document.getElementById('quant" + id + "').value, '" + preco.Replace(",", ".") + "', " + id + ",  document.getElementById('txtObs" + id + "').value)\" class=\"btn btn-primary\" width=\"100%\"> Adicionar </button>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListaDepartamento()
        {
            throw new NotImplementedException();
        }

        public string GerarIndexDepartamento(int id, string url, string desc, string det, string preco, int cont, string tel)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<div class=\"row\">");
                sb.Append("<div class=\"col-12 col-md-8\">");
                sb.Append("<strong>" + desc + " - R$ " + preco.Replace(".",",") + "</strong>");
                sb.Append("<p>" + det + "</p>");
                sb.Append("</div>");
                sb.Append("<div class=\"col-6 col-md-4\">");
                sb.Append("<button type=\"button\" data-toggle=\"modal\" data-target=\"#myModal" + id + "\" class=\"btn btn-outline-success\" style=\"width:300px;\"> Opa... esse eu Quero!!! </button>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<hr>");

                sb.Append("<div class=\"modal fade\" id=\"myModal" + id + "\">");
                sb.Append("<div class=\"modal-dialog modal-lg\">");
                sb.Append("<div class=\"modal-content\">");

                sb.Append("<div class=\"modal-header\">");
                sb.Append("<h5 class=\"modal-title\" id=\"TituloModalCentralizado\">" + desc + "</h5>");
                sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Fechar\">");
                sb.Append("<span aria-hidden=\"true\">&times;</span>");
                sb.Append("</button>");
                sb.Append("</div>");

                sb.Append("<div class=\"card mb-3\">");
                sb.Append("<div class=\"bg-image hover-overlay ripple\" data-mdb-ripple-color=\"light\">");
                sb.Append("<img src=\"" + url + "\" height=\"400px\" width=\"100%\"");
                sb.Append("class=\"img-fluid\"/>");
                sb.Append("<a href==\"#!\">");
                sb.Append("<div class=\"mask\" style=\"background-color: rgba(251, 251, 251, 0.15);\"></div>");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"card-body\">");
                sb.Append("<h5 class=\"card-title\">");
                sb.Append("<td><span class=\"preco-produto\">R$ " + preco + "</span></td>");
                sb.Append("</h5>");
                sb.Append("<p class=\"card-text\">");
                sb.Append("" + det + "");
                sb.Append("</p>");

                sb.Append("<div class=\"card mb-3\">");
                sb.Append("<textarea id=\"txtObs" + id + "\" style=\"height: 64px; width=\"100%\" placeholder=\"Ex. Sem Maionese\"></textarea>");
                sb.Append("</div>");
                sb.Append("<strong>");

                sb.Append("<tfoot>");
                sb.Append("<tr>");
                sb.Append("<td class=\"texto-total\">Total da Compra </td>");
                sb.Append("<td><span id=\"total\">R$ " + preco + "</span></td>");
                sb.Append("</tr>");
                sb.Append("</tfoot>");
                sb.Append("</strong>");

                sb.Append("<div class=\"modal-footer\">");

                sb.Append("<div data-app=\"product.quantity\" class=\"quantidade" + id + "\">");
                sb.Append("<span id=\"span_erro_carrinho\" class=\"blocoAlerta\" style=\"display:none;\">Selecione uma opção para variação do produto</span>");
                //sb.Append("<strong>Quant:</strong>");
                sb.Append("<input class=\"btn btn-danger\" type=\"button\" width=\"50px\" id=\"plus" + id + "\" value='-' onclick=\"processar" + id + "(-1)\"/>");
                sb.Append("<input class=\"btn btn-outline-dark\" id=\"quant" + id + "\" name=\"quant" + id + "\" class=\"text\" size=\"1\" type=\"text\" value=\"1\" maxlength=\"5\"/>");
                sb.Append("<input class=\"btn btn-success\" type=\"button\" id=\"minus" + id + "\" value='+' onclick=\"processar" + id + "(1)\">");

                sb.Append("</div>");

                sb.Append("<button type=\"button\" id=\"adicionar1\" id=\"produto1\" onclick=\"AddCarrinho('" + desc + "', document.getElementById('quant" + id + "').value, '" + preco.Replace(",", ".") + "', " + id + ",  document.getElementById('txtObs" + id + "').value)\" class=\"btn btn-primary\" width=\"100%\"> Adicionar </button>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GerarCardsDepartanentos(int id, string url, string desc, string descDep, string empresa)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<div class=\"col-lg-3 col-md-4 col-sm-6 portfolio-item\" style=\"width:20rem; height:33rem\">");
                sb.Append("<div class=\"row main-low-margin text-center\">");
                sb.Append("<div class=\"card-deck\">");
                sb.Append("<div class=\"card\">");
                sb.Append("<a href=\"produtos-" + empresa + "?id=" + id + "\">");
                sb.Append("<img class=\"card-img-top\" src=\"" + url + "\" alt=\"" + descDep + "\" height=\"300\" width=\"200\"/>");
                sb.Append("<div class\"card-body\">");
                sb.Append("<h5 class=\"card-title\">" + descDep + "</h5>");
                sb.Append("<p class=\"card-text\">" + desc + ".</p>");
                sb.Append("<br>");
                sb.Append("</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"card-footer\">");
                sb.Append("<small class=\"text-muted\">Atualizados 3 minutos atrás</small>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable PesquisarDepartamentosIdEmpresa(int idEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoPesquisarIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GerarScriptModal(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<script>");

                sb.Append("function processar" + id + "(quant) {");

                qtdes = ("quant" + id.ToString());

                sb.Append("var value = parseInt(document.getElementById(\"" + qtdes + "\").value);");
                sb.Append("value += quant;");
                sb.Append("if (value < 1)");
                sb.Append("{");

                sb.Append("document.getElementById(\"" + qtdes + "\").value = 1;");
                sb.Append("}");
                sb.Append(" else");
                sb.Append("{");

                sb.Append("document.getElementById(\"" + qtdes + "\").value = value;");
                sb.Append("}");
                sb.Append("}");

                sb.Append("</script>");

                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GerarIndexModal(int id, string url, string descrica, string detalhes)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<div class=\"modal fade\" id=\"myModal" + id + "\">");
                sb.Append("<div class=\"modal-dialog modal-lg\">");
                sb.Append("<div class=\"modal-content\">");


                sb.Append("<div class=\"col-lg-10\">");

                sb.Append("<div class=\"col-lg-3 col-md-4 col-sm-6 portfolio-item\" style=\"width:100%;\">");
                sb.Append("<div class=\"row main-low-margin text-center\">");
                sb.Append("<div class=\"card-deck\">");
                sb.Append("<div class=\"card\">");
                sb.Append("<img class=\"card-img-top\" src=\"" + url + "\" alt=\"" + descrica + "\" height=\"500\" width=\"200\"/>");
                sb.Append("<div class\"card-body\">");
                sb.Append("<h5 class=\"card-title\">" + descrica + "</h5>");
                sb.Append("<p class=\"card-text\">" + detalhes + ".</p>");
                sb.Append("</div>");
                sb.Append("<div class=\"card-footer\">");
                sb.Append("<small class=\"text-muted\">Atualizados 3 minutos atrás</small>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                sb.Append("<div class=\"modal-footer\">");
                sb.Append("<button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Fechar</button>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable Pesquisar(int idEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarDepartamentoIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Pesquisar(int idEmpresa, int idDepartamento)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                conexaoSqlServer.AdicionarParametros("@ID", idDepartamento);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspDepartamentoProsutoListarIdDep");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
