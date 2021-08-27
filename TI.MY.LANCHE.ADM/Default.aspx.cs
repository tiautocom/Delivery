using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TI.MY.LANCHE.ADM
{
    public partial class _Default : Page
    {

        #region CLASSES E OBJETOS

        #endregion

        #region VARIAVEIS

        public string idEmpresa, nomeEmpresa = "";

        public int idEmp = 0;


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListQueryString();
                idEmp = Convert.ToInt32(idEmpresa);

                lblEmpresa.Text = nomeEmpresa;

                if (idEmpresa == null)
                {

                }
            }
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresa"];

            if (nomeEmpresa != null)
            {
                idEmpresa = Request.QueryString["idEmpresa"];
                idEmp = Convert.ToInt32(idEmpresa);
            }
            else
            {
                Response.Redirect("\\login.aspx");
            }

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            ListQueryString();
            Response.Redirect("\\view\\list\\produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa);
        }
    }
}