using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.REGRA.NEGOCIOS;

namespace TI.MY.LANCHE
{
    public partial class Default : System.Web.UI.Page
    {
        DepartamentoRegraNegocios departamentoRegraNegocios;

        public int idEmpresa = 1;
        public int id = 0;
        public string layoutIndex, htmlindexModal = "";
        public string scriptModal, scriptAddCarrinho = "";
        public string desc, det, url, preco = "";
        public int cont = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            PesquisarEmpresaLogada();
        }

        public void PesquisarEmpresaLogada()
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

                        layoutIndex += departamentoRegraNegocios.GerarIndex(id, url, desc, det, preco, cont);
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