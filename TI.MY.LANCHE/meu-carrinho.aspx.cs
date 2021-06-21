using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE
{
    public partial class meucarrinho : System.Web.UI.Page
    {
        public static int idEmpresa = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idEmpresa = Convert.ToInt32(Session["idEmpresa"]); 
            }
        }

        [WebMethod]
        public static string SalvarPedido(Pedidos pedido)
        {
            try
            {
                PedidoRegraNegocios pedidoRegraNegocios = new PedidoRegraNegocios();
                return pedidoRegraNegocios.Salvar(pedido);
            }
            catch (Exception ex)
            {
                return "Detalhes do Error: " + ex.Message + "\n\nErro ao Cadastrar Pedido...";
            }
        }
    }
}