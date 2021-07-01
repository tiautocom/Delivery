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
    public partial class empresa : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        //Pessoas empresa;
        PessoaRegraNegocios PessoaRegraNegocios;
        // Pessoas empresa;

        DataTable dadosTabela;
        #endregion

        #region VARIAVEIS

        public string descricao, nomeEmpresa, nomeUsuarioLogado, parceiro, qsLogado = "";
        int idEmpresa, idUsuarioLogado, idTipoUsuario = 0;

        //protected void gdvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        int idRetorno = 0;

        #endregion
        //protected void gdvEmp_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                descricao = Pesquisar.Text.Trim();

                ListarEmpresa(descricao);
            }
        }

       

        private void ListarEmpresa(string descricao)
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                PessoaRegraNegocios = new PessoaRegraNegocios();

                dadosTabela = PessoaRegraNegocios.PesquisarNome(descricao);

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvEmp.DataSource = null;
                    gdvEmp.DataSource = dadosTabela;
                    gdvEmp.DataBind();
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

        protected void Pesquisar_TextChanged(object sender, EventArgs e)
        {
            ListarEmpresa(descricao);
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            ListarEmpresa(descricao);
        }

        protected void gdvEmp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dadosTabela = new DataTable();
            idEmpresa = 0;
            if (e.CommandName == "DELETAR")
            {
                idEmpresa = Convert.ToInt32(e.CommandArgument);
                //Delete(idEmpresa);
            }
            if (e.CommandName == "EDITAR")
            {
                //ListaLogado();
                idEmpresa = Convert.ToInt32(e.CommandArgument);

                ListarEmpresa(idEmpresa);

                Response.Redirect("~/view/add/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa, false);
                //Response.Redirect("~/View/EDIT/Empresa.aspx?idEmpresaEdit=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa, false);
                //Response.Redirect("~/View/EDIT/Empresa.aspx?idEmpresaEdit=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa + "&"+qsLogado, false);
            }
        }

        private void ListarEmpresa(int idEmpresa)
        {
            try
            {
                dadosTabela = new DataTable();
                PessoaRegraNegocios = new PessoaRegraNegocios();

                dadosTabela = PessoaRegraNegocios.PesquisarId(idEmpresa);

                if (dadosTabela.Rows.Count > 0)
                {
                    nomeEmpresa = dadosTabela.Rows[0]["FANTASIA"].ToString();
                    //nomeEmpresa = dadosTabela.Rows[0][4].ToString();

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

        private void Editar(int idEmpresa)
        {
            try
            {
                Convert.ToInt32(idEmpresa);
                Response.Redirect("~/View/Add/Empresa.aspx?idEmpresa = " + idEmpresa, false);
            }
            catch
            {
                Response.Write("<script>alert('Mensagem');</script>");
            }

        }

        //private void Delete(int idEmpresa)
        //{
        //    PessoaRegraNegocios = new PessoaRegraNegocios();
        //    try
        //    {
        //        Convert.ToInt32(idEmpresa);
        //        //idRetorno = PessoaRegraNegocios.DeleteEmpresa(idEmpresa);
        //        Response.Write("<script>alert('Empresa " + idEmpresa + " Deletada com sucesso.'); window.location.href = window.location.href;</script>");
        //    }
        //    catch (Exception)
        //    {
        //        Response.Write("<script>alert('Mensagem');</script>");
        //    }
        //}

        protected void gdvEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Novo_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/View/Add/Empresa.aspx", false);
        //}
    }
}