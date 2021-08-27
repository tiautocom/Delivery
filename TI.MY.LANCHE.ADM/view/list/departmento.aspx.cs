using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.REGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.list
{
    public partial class departmento : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Departament departamento;

        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        public string idEmpresa, nomeEmpresa = "";
        public int idEmp = 0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListQueryString();
                idEmp = Convert.ToInt32(idEmpresa);
                ListaDepartamentos();

                string nomeEmpresa = Request.QueryString["nomeEmpresa"];
                lblEmpresa.Text = nomeEmpresa;

                idEmpresa = Request.QueryString["idEmpresa"];

                if (idEmpresa == null)
                {

                }
            }
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresa"];
            lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            idEmp = Convert.ToInt32(idEmpresa);

        }

        private void ListaDepartamentos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.Pesquisar(idEmp);


                if (dadosTabela.Rows.Count > 0)
                {
                    gdvDepartamento.DataSource = null;
                    gdvDepartamento.DataSource = dadosTabela;
                    gdvDepartamento.DataBind();
                }
                else
                {
                    //gdvEmp.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}