using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.REGRA.NEGOCIOS;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE
{
    public partial class degraus_nautico : System.Web.UI.Page
    {
        DepartamentoRegraNegocios departamentoRegraNegocios;
        PessoaRegraNegocios pessoaRegraNegocios;
        HtmlRegraNegocios htmlRegraNegocios;

        public int idEmpresa = 3;
        public int id = 0;
        public string layoutIndex, htmlindexModal = "";
        public string scriptModal, scriptAddCarrinho, layoutEstabelicmento, abertura, fechamento = "";
        public string desc, det, url, preco, tel = "";
        public int cont = 0;
        public string nomeEmpresa, layoutLogo, urlLogo = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PesquisarEmpresaLogado();
                PesquisarDadosEmpresaLogada();
            }
        }

        public void PesquisarEmpresaLogado()
        {
            string url = Request.Path.Replace("/", "").Replace(".aspx", "");

            if (url != null)
            {
                DataTable dadosTabela = new DataTable();
                pessoaRegraNegocios = new PessoaRegraNegocios();
                htmlRegraNegocios = new HtmlRegraNegocios();

                dadosTabela = pessoaRegraNegocios.PesquisarId(idEmpresa);

                if (dadosTabela.Rows.Count > 0)
                {
                    Session["idEmpresa"] = idEmpresa;
                    nomeEmpresa = dadosTabela.Rows[0]["FANTASIA"].ToString().Trim();
                    urlLogo = dadosTabela.Rows[0]["IMG_LOGO"].ToString().Trim();
                    tel = dadosTabela.Rows[0]["TELEFONE"].ToString().Trim();
                    abertura = dadosTabela.Rows[0]["HORA_INICIO"].ToString().Trim();
                    fechamento = dadosTabela.Rows[0]["HORA_FIM"].ToString().Trim();

                    layoutLogo = htmlRegraNegocios.GerarLogo(urlLogo, idEmpresa, nomeEmpresa, "degraus-nautico", tel);
                    layoutEstabelicmento = htmlRegraNegocios.GerarStatusEstabelcimento(abertura, fechamento);

                    Session["iFramelogoScript"] = layoutLogo;

                    iFrameEstabelecimento.Controls.Add(new LiteralControl(layoutEstabelicmento));
                }
            }
            else
            {
                Response.Redirect("index.aspx", false);
                Session["iFramelogoScript"] = null;
                Session["Departamento"] = null;
                Session["iFrameIndex"] = null;
            }
        }

        public void PesquisarDadosEmpresaLogada()
        {
            try
            {
                DataTable dadosTabela = new DataTable();

                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.Pesquisar(idEmpresa);

                layoutIndex = "";
                scriptModal = "";

                if (dadosTabela.Rows.Count > 0)
                {
                    Departamentos.Text = dadosTabela.Rows[0]["DEPARTAMENTO"].ToString().Trim();

                    for (int i = 0; i < dadosTabela.Rows.Count; i++)
                    {
                        url = dadosTabela.Rows[i]["URL_PRODUTO"].ToString().Trim();
                        desc = dadosTabela.Rows[i]["PRODUTO"].ToString().Trim();
                        det = dadosTabela.Rows[i]["INGREDIENTES"].ToString().Trim();
                        id = Convert.ToInt32(dadosTabela.Rows[i]["ID_PRODUTO"].ToString());
                        preco = dadosTabela.Rows[i]["PRECO"].ToString().Trim();

                        Session["idEmpresa"] = Convert.ToInt32(dadosTabela.Rows[0]["ID_EMPRESA"].ToString());

                        layoutIndex += departamentoRegraNegocios.GerarIndex(id, url, desc, det, preco, cont, tel);
                        scriptModal += departamentoRegraNegocios.GerarScriptModal(id);

                        if (cont == 4)
                        {
                            cont = 0;
                        }
                        else
                        {
                            cont++;
                        }
                    }

                    iFrameIndex.Controls.Add(new LiteralControl(layoutIndex));
                    iFrameScript.Controls.Add(new LiteralControl(scriptModal));
                }
            }
            catch
            {
            }
        }
    }
}