using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.REGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.add
{
    public partial class departmento : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Departamento departamento;

        DepartamentoRegraNegocios DepartamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        public string idEmpresa = "";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaDepartamentos();

                string nomeEmpresa = Request.QueryString["nomeEmpresaEdit"];
                lblEmpresa.Text = nomeEmpresa;

                idEmpresa = Request.QueryString["idEmpresa"];

                if (idEmpresa == null)
                {
                    ddlEmpresa.Visible = true;
                }
            }
        }

        private void ListaDepartamentos()
        {
            throw new NotImplementedException();
        }
    }
}