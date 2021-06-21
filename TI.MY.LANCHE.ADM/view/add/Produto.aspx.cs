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

namespace TI.MY.LANCHE.ADM.view.add
{
    public partial class Produto : System.Web.UI.Page
    {

        #region CLASSES E OBJETOS

        Producto produto;
        Pessoa pessoa;
        //Departamento departamento;
        //Departamento_Produto departamento_Produto;

        DepartamentoRegraNegocios DepartamentoRegraNegocios;
        ProdutoRegraNegocios ProdutoRegraNegocios;
        PessoaRegraNegocios PessoaRegraNegocios;
        
        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        string urlEndereco = "";
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

                if (idEmpresa is null)
                {
                    ddlEmpresa.Visible = true;
                    ListaEmpresas();
                }
            }     

        }

        private void ListaEmpresas()
        {
            try
            {
                DataTable dadosTabela = new DataTable();
                PessoaRegraNegocios = new PessoaRegraNegocios();

                dadosTabela = PessoaRegraNegocios.Pesquisar();

                if (dadosTabela.Rows.Count > 0)
                {
                    ddlEmpresa.DataSource = dadosTabela;
                    ddlEmpresa.DataValueField = "ID";
                    ddlEmpresa.DataTextField = "FANTASIA";
                    ddlEmpresa.DataBind();
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
                DepartamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = DepartamentoRegraNegocios.ListaDepartamento();

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
            idEmpresa = Request.QueryString["idEmpresa"];
            try
            {
                //if (txtCodBarra.Text.Trim().Equals(""))
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo Codigo de Barra não Pode ser Nulo ou Vázio')</script>");
                //    txtCodBarra.Focus();
                //}
                //else 
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

                    produto = new Producto();

                    produto.codBarra = txtCodBarra.Text.Trim();
                    produto.descricao = txtDescricao.Text.ToUpper().Trim();
                    produto.unidade = txtUnidade.Text.ToUpper().Trim();
                    produto.dtCadastro = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    produto.urlFoto = fupImagem.ToString();
                    produto.ingredientes = txtIngredientes.Text.Trim();

                    produto.Departamento_Produto = new Departamento_Produto();

                    produto.Departamento_Produto.idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
                    produto.Departamento_Produto.idEmpresa = Convert.ToInt32(idEmpresa);
                    produto.Departamento_Produto.preco = Convert.ToDecimal(txtPreco.Text);
                    produto.Departamento_Produto.custo = Convert.ToDecimal(txtCusto.Text);
                    produto.Departamento_Produto.estoque = Convert.ToDecimal(txtEstoque.Text);
                    produto.Departamento_Produto.granel = txtGranel.Text.ToUpper();
                    produto.Departamento_Produto.ativo = Convert.ToBoolean(chkAtivo.Checked);

                    //produto.Produto_Observacao.Observacao = txtIngredientes.Text.Trim();


                    //PRODUTO
                    ProdutoRegraNegocios = new ProdutoRegraNegocios();
                    idRetorno = ProdutoRegraNegocios.AddProduto(produto, 1);


                    try
                    {
                        Convert.ToInt32(idRetorno);
                        Response.Redirect("~/View/Add/produto.aspx?idProduto=" + idRetorno + "&produto=" + produto.descricao, false);

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