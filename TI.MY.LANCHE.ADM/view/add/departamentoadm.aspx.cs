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
    public partial class departamentoadm : System.Web.UI.Page
    {

        #region CLASSES E OBJETOS

        Departament departamento;

        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        //string urlEndereco = "";
        public string idEmpresa, nomeEmpresa = "";
        public int idEmp = 0;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                ListQueryString();

            }
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresa"];
            //lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            idEmp = Convert.ToInt32(idEmpresa);

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            AddDepartamento();
        }

        private void AddDepartamento()
        {
            try
            {
                if (txtDescricao.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo CNPJ não Pode ser Nulo ou Vázio')</script>");
                    txtDescricao.Focus();
                }
               
                else
                {

                    departamento = new Departament();

                    departamento.descricao = txtDescricao.Text.ToUpper().Trim();

                    //DEPARTAMENTO
                    departamentoRegraNegocios = new DepartamentoRegraNegocios();
                    idRetorno = departamentoRegraNegocios.AddDepartamento(departamento, 1);


                    try
                    {
                        Convert.ToInt32(idRetorno);
                        Response.Redirect("~/View/Add/produto.aspx?idProduto=" + idRetorno + "&produto=" + departamento.descricao, false);

                    }
                    catch
                    {
                        Response.Write("<script>alert('Mensagem');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
            //return idRetorno;
        }
    }
}