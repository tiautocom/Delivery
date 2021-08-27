using System;
using System.Collections.Generic;
using System.Data;
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

        Departament departamento;
        Departament_Empresa departament_Empresa;

        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        public string idEmpresa, nomeEmpresa = "";
        public int idEmp, idDepartamento = 0;

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
                    #region chk
                    //cklDepartamento.DataSource = null;
                    //cklDepartamento.DataSource = dadosTabela;
                    //cklDepartamento.DataTextField = "DESCRICAO_DEPARTAMENTO";
                    //cklDepartamento.DataValueField = "ID";
                    //cklDepartamento.DataBind();
                    #endregion

                    gdvDepartamentoEmpresa.DataSource = null;
                    gdvDepartamentoEmpresa.DataSource = dadosTabela;
                    gdvDepartamentoEmpresa.DataBind();

                }

                else
                {
                    //gdvEmp.DataSource = null;
                }
                dadosTabela = null;
                dadosTabela = departamentoRegraNegocios.ListaDepartamento();

                ListarEmpresa(dadosTabela);

            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void gdvDepartamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListQueryString();

            idDepartamento = 0;

            if (e.CommandName == "CADASTRAR")
            {

                GridViewRow row = null;
                int index = Convert.ToInt32(e.CommandArgument);
                row = gdvDepartamento.Rows[index];

                string descricaoDepartamento = gdvDepartamento.DataKeys[index].Values["DESCRICAO_DEPARTAMENTO"].ToString().Trim();
                idDepartamento = Convert.ToInt32(gdvDepartamento.DataKeys[index].Values["ID_DEPARTAMENTO"].ToString().Trim());

                //Convert.ToBoolean(gdvDepartamento.DataKeys[index].Values["DESCRICAO_DEPARTAMENTO"].ToString().Trim());

                //string desc = e.CommandName;
                Response.Redirect("~/view/add/departamentonovo.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa + "&idDepartamento=" + idDepartamento + "&departamento=" + descricaoDepartamento, false);
                //CadastrarDepartamentoEmpresa(idDepartamento, idEmp);
            }
        }

        protected void gdvDepartamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label nomeLabbel = (e.Row.FindControl("lbDescricao") as Label);
                Label idDepartamento = (e.Row.FindControl("lblId") as Label);

                Response.Redirect("~/view/add/departamentonovo.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa + "&idDepartamento=" + idDepartamento + "&DescricaoDepartamento=" + nomeLabbel, false);


            }
        }


        protected void gdvDepartamentoEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListQueryString();

            idDepartamento = 0;
            if (e.CommandName == "DESATIVAR")
            {
                idDepartamento = Convert.ToInt32(e.CommandArgument);
                CadastrarDepartamentoEmpresa(idDepartamento, idEmp);
            }
        }

        public void ListarEmpresa(DataTable dadosTab)
        {
            if (dadosTab.Rows.Count > 0)
            {
                #region chk
                //cklDepEmpresa = new CheckBoxList();
                //cklDepEmpresa.DataSource = null;
                //cklDepEmpresa.DataSource = dadosTab;
                //cklDepEmpresa.DataTextField = "DESCRICAO_DEPARTAMENTO";
                //cklDepEmpresa.DataValueField = "ID";
                //cklDepEmpresa.DataBind();
                #endregion
                gdvDepartamento.DataSource = null;
                gdvDepartamento.DataSource = dadosTab;
                gdvDepartamento.DataBind();
            }
        }

        private void CadastrarDepartamentoEmpresa(int idDepartamento, int idEmp)
        {
            ListQueryString();
            try
            {

                departamento = new Departament();
                departamento.Departament_Empresa = new Departament_Empresa();

                departamento.Departament_Empresa.idDepartamento = idDepartamento;
                departamento.Departament_Empresa.idEmpresa = idEmp;
                //DEPARTAMENTO_EMPRESA
                departamentoRegraNegocios = new DepartamentoRegraNegocios();
                idRetorno = departamentoRegraNegocios.AtivarDepartamentoEmpresa(departamento.Departament_Empresa, 1);

                try
                {
                    Convert.ToInt32(idRetorno);
                    //Alert();

                }
                catch
                {
                    Response.Write("<script>alert('Mensagem');</script>");
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