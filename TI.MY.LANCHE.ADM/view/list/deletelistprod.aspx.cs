using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.REGRA.NEGOCIOS;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.list
{
    public partial class deletelistprod : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Producto producto;
        ProdutoRegraNegocios produtoRegraNegocios;
        DepartamentoRegraNegocios departamentoRegraNegocios;

        DataTable dadosTabela;
        #endregion

        #region VARIAVEIS

        public string descricao, nomeProduto, nomeUsuarioLogado, parceiro, qsLogado, idEmpresa, nomeEmpresa = "";

        int idRetorno, idEmp, idProduto, idDepartamento = 0;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListQueryString();
                idEmp = Convert.ToInt32(idEmpresa);
                ListaProdutos(idEmp);
                ListaDepartamento(idEmp);

                if (idEmpresa == null)
                {

                }
            }
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/view/add/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa, false);
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresa"];
            lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            idEmp = Convert.ToInt32(idEmpresa);

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

        private void ListaProdutos(int idEmp, int idDepartamento)
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                produtoRegraNegocios = new ProdutoRegraNegocios();

                dadosTabela = produtoRegraNegocios.ListProdutoEmpresaId(idEmp, idDepartamento);


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

        private void ListaDepartamento(int idEmp)
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.PesquisarDepartamentosIdEmpresa(idEmp);

                if (dadosTabela.Rows.Count > 0)
                {
                    ddlDepartamento.DataSource = dadosTabela;
                    ddlDepartamento.DataValueField = "ID";
                    ddlDepartamento.DataTextField = "DESCRICAO_DEPARTAMENTO";
                    ddlDepartamento.DataBind();
                }
                else
                {
                    ddlDepartamento.DataSource = null;
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
                SuspendeProduto(idProduto, idEmp);
            }
        }

        private string SuspendeProduto(int idProduto, int idEmp)
        {
            ListQueryString();
            try
            {

                producto = new Producto();

                producto.id = idProduto;
                producto.Departamento_Produto = new Departamento_Produto();

                producto.Departamento_Produto.idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
                producto.Departamento_Produto.idEmpresa = Convert.ToInt32(idEmpresa);
                producto.Departamento_Produto.ativo = false;

                //produto.Produto_Observacao.Observacao = txtIngredientes.Text.Trim();


                //PRODUTO
                produtoRegraNegocios = new ProdutoRegraNegocios();
       //         idRetorno = produtoRegraNegocios.SuspenderProduto(producto, 2);


                try
                {
                    Convert.ToInt32(idRetorno);

                    Response.Redirect("~/view/list/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa + "&idDepartamento=" + nomeEmpresa, false);

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
            return idRetorno.ToString();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListQueryString();
            idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
            ListaProdutos(idEmp, idDepartamento);
        }


        List<Producto> listaProduto = new List<Producto>();

        protected void SuspenderSelecao_Click(object sender, EventArgs e)
        {
            //CheckBox check = new CheckBox();

            try
            {

                foreach (GridViewRow row in gdvProduto.Rows) //Running all lines of grid
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("cb101") as CheckBox);

                        if (chkRow.Checked)
                        {
                                 listaProduto = new List<Producto>();

                                 listaProduto.Add(new Producto()
                                {
                                    //id = Convert.ToInt32(gdvProduto.Rows[i].Cells[1].Text)
                                    id = Convert.ToInt32(gdvProduto.Rows[0].Cells[0].Text)

                                });
                        }
                    }
                }

                //for (int i = 0; i < gdvProduto.Rows.Count; i++)
                //{

               //     bool checks = Convert.ToBoolean(gdvProduto.DataKeys[i].Values["chkwhatever"].ToString().Trim());

                    //bool aqui = Convert.ToBoolean(gdvProduto.Rows[i].FindControl("cb101"));

                    //CheckBox check = FindControl("chkSel") as CheckBox;
                    //check = (CheckBox)gdvProduto.FindControl("chkSel");
                    //check = (CheckBox)this.FindControl("chkSel");

                    //if (check !=null )
                    //{
                    
                    //}
                //}
            }
             catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}