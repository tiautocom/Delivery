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

namespace TI.MY.LANCHE.ADM.view.edit
{
    public partial class produto : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Producto producto;
        //Pessoa pessoa;
        //Departamento departamento;
        //Departamento_Produto departamento_Produto;

        DepartamentoRegraNegocios departamentoRegraNegocios;
        ProdutoRegraNegocios produtoRegraNegocios;
        //PessoaRegraNegocios PessoaRegraNegocios;

        #endregion

        #region VARIAVEIS

        int idProducto = 0;
        //string urlEndereco = "";
        string idRetorno, idEmpresa, nomeEmpresa, idProduto, nomeProduto = "";


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListQueryString();
                ListaDepartamentos();
                PesquisaProdutoIdEmpresa();

                if (idEmpresa == null)
                {
                    Response.Redirect("~/", false);
                }
            }
        }

        private void ListQueryString()
        {
            nomeEmpresa = Request.QueryString["nomeEmpresaEdit"];
            lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            idProduto = Request.QueryString["idProduto"];
            idProducto = Convert.ToInt32(idProduto);
            lblIdProduto.Text = idProduto;

        }

        private void PesquisaProdutoIdEmpresa()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                produtoRegraNegocios = new ProdutoRegraNegocios();

                dadosTabela = produtoRegraNegocios.ListProdutoEmpresaId(idEmpresa, idProduto);

                if (dadosTabela.Rows.Count > 0)
                {
                    txtCodBarra.Text = dadosTabela.Rows[0]["COD_BAR"].ToString();
                    ddlDepartamento.Text = dadosTabela.Rows[0]["DESCRICAO_DEPARTAMENTO"].ToString();
                    chkAtivo.Checked = Convert.ToBoolean(dadosTabela.Rows[0]["ATIVO"].ToString());
                    txtDescricao.Text = dadosTabela.Rows[0]["DESCRICAO"].ToString();
                    txtUnidade.Text = dadosTabela.Rows[0]["UNID"].ToString();
                    txtPreco.Text = dadosTabela.Rows[0]["PRECO"].ToString();
                    txtCusto.Text = dadosTabela.Rows[0]["CUSTO"].ToString();
                    txtGranel.Text = dadosTabela.Rows[0]["GRANEL"].ToString();
                    txtCusto.Text = dadosTabela.Rows[0]["CUSTO"].ToString(); 
                    txtEstoque.Text = dadosTabela.Rows[0]["ESTOQUE"].ToString();
                    txtIngredientes.Text = dadosTabela.Rows[0]["INGREDIENTES"].ToString();
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

        private void ListaDepartamentos()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                departamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = departamentoRegraNegocios.ListaDepartamento();

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

        protected void Add_Click(object sender, EventArgs e)
        {
            AddProduto();
        }

        private string AddProduto()
        {
            ListQueryString();
            try
            {
                if (txtDescricao.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo CNPJ não Pode ser Nulo ou Vázio')</script>");
                    txtDescricao.Focus();
                }
                else if (txtPreco.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo E-Mail não Pode ser Nulo ou Vázio')</script>");
                    txtPreco.Focus();
                }

                else
                {

                    producto = new Producto();

                    producto.id = idProducto;
                    producto.codBarra = txtCodBarra.Text.Trim();
                    producto.descricao = txtDescricao.Text.ToUpper().Trim();
                    producto.unidade = txtUnidade.Text.ToUpper().Trim();
                    producto.dtCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    producto.urlFoto = fupImagem.ToString();
                    producto.ingredientes = txtIngredientes.Text.Trim();

                    producto.Departamento_Produto = new Departamento_Produto();

                    producto.Departamento_Produto.idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
                    producto.Departamento_Produto.idEmpresa = Convert.ToInt32(idEmpresa);
                    producto.Departamento_Produto.preco = Convert.ToDecimal(txtPreco.Text);
                    producto.Departamento_Produto.custo = Convert.ToDecimal(txtCusto.Text);
                    producto.Departamento_Produto.estoque = Convert.ToDecimal(txtEstoque.Text);
                    producto.Departamento_Produto.granel = txtGranel.Text.ToUpper();
                    producto.Departamento_Produto.ativo = Convert.ToBoolean(chkAtivo.Checked);

                    //produto.Produto_Observacao.Observacao = txtIngredientes.Text.Trim();


                    //PRODUTO
                    produtoRegraNegocios = new ProdutoRegraNegocios();
                    idRetorno = produtoRegraNegocios.AddProduto(producto, 2);


                    try
                    {
                        Convert.ToInt32(idRetorno);
                        Response.Redirect("~/view/list/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresaEdit=" + nomeEmpresa, false);

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
            return idRetorno;
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}