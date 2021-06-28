using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.list
{
    public partial class produto : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Producto producto;
        ProdutoRegraNegocios produtoRegraNegocios;

        DataTable dadosTabela;
        #endregion

        #region VARIAVEIS

        public string descricao, nomeProduto, nomeUsuarioLogado, parceiro, qsLogado, idEmpresa, nomeEmpresa = "";

     
        int idRetorno, idEmp, idProduto = 0;

        #endregion

        protected void Novo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/add/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa , false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListQueryString();
                idEmp = Convert.ToInt32(idEmpresa);
                ListaProdutos(idEmp);

                if (idEmpresa == null)
                {
                   
                }
            }
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresaEdit"];
            lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            
        }

        private void ListaProdutos(int idEmp)
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                produtoRegraNegocios = new ProdutoRegraNegocios();

                dadosTabela = produtoRegraNegocios.ListProdutoEmpresaId(idEmp);

                if (dadosTabela.Rows.Count > 0)
                {
                    gdvProduto.DataSource = null;
                    gdvProduto.DataSource = dadosTabela;
                    gdvProduto.DataBind();
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

        protected void gdvProduto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ListQueryString();
            
            idProduto = 0;
            if (e.CommandName == "DELETAR")
            {
                idProduto = Convert.ToInt32(e.CommandArgument);
                //Delete(idEmpresa);
            }
            if (e.CommandName == "EDITAR")
            {
                //ListaLogado();
                idProduto = Convert.ToInt32(e.CommandArgument);
                

                //EditProdutoId(idEmp);

                Response.Redirect("~/view/edit/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa + "&idProduto=" + idProduto + "&nomeProduto=" + nomeProduto   , false);
                //Response.Redirect("~/View/EDIT/Empresa.aspx?idEmpresaEdit=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa, false);
                //Response.Redirect("~/View/EDIT/Empresa.aspx?idEmpresaEdit=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa + "&"+qsLogado, false);
            }
        }

        private void EditProdutoId(int idEmp)
        {
            try
            {
                dadosTabela = new DataTable();
                produtoRegraNegocios = new ProdutoRegraNegocios();

                dadosTabela = produtoRegraNegocios.PesquisaProdutoId(idEmpresa);

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

        protected void Pesquisar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}