using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.list
{
    public partial class pedidos : System.Web.UI.Page
    {
        PedidoRegraNegocios pedidoRegraNegocios;

        public int idEmpresa = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PesquisarPedidoAll();
            }
        }

        public void PesquisarPedidoAll()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                pedidoRegraNegocios = new PedidoRegraNegocios();

                dadosTabela = pedidoRegraNegocios.PesquisarPedidoAll(idEmpresa, txtPesquisar.Text.Trim());

                if (dadosTabela.Rows.Count > 0)
                {
                    literalName.Text = dadosTabela.Rows[0]["FANTASIA"].ToString().Trim();

                    gdvPedido.DataSource = null;
                    gdvPedido.DataSource = dadosTabela;
                    gdvPedido.DataBind();
                }
                else
                {
                    gdvPedido.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}