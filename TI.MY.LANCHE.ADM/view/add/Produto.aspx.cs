using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        //Pessoa pessoa;
        //Departamento departamento;
        //Departamento_Produto departamento_Produto;

        DepartamentoRegraNegocios DepartamentoRegraNegocios;
        ProdutoRegraNegocios ProdutoRegraNegocios;
        PessoaRegraNegocios PessoaRegraNegocios;
        
        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        //string urlEndereco = "";
        public string idEmpresa, nomeEmpresa, url = "";
        public int idEmp = 0;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaDepartamentos();

                ListQueryString();

                if (idEmpresa == null)
                {
                    Response.Redirect("~/", false);
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
            ListQueryString();
            try
            {
                DataTable dadosTabela = new DataTable();
                DepartamentoRegraNegocios = new DepartamentoRegraNegocios();

                dadosTabela = DepartamentoRegraNegocios.PesquisarDepartamentosIdEmpresa(idEmp);

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
                    try
                    {
                        produto.Departamento_Produto.estoque = Convert.ToDecimal(txtEstoque.Text);
                    }
                    catch (Exception)
                    {
                        produto.Departamento_Produto.estoque = 0;
                    }
                    produto.Departamento_Produto.granel = txtGranel.Text.ToUpper();
                    produto.Departamento_Produto.ativo = Convert.ToBoolean(chkAtivo.Checked);

                    //produto.Produto_Observacao.Observacao = txtIngredientes.Text.Trim();


                    //PRODUTO
                    ProdutoRegraNegocios = new ProdutoRegraNegocios();
                    idRetorno = ProdutoRegraNegocios.AddProduto(produto, 1);


                    try
                    {
                        UploadImagem();
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

        private void UploadImagem()
        {
            try
            {
                HttpFileCollection uploadedFiles = Request.Files;

                HttpPostedFile userPostedFile = uploadedFiles[0];

                ListQueryString();

                url = fupImagem.PostedFile.FileName;

                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\departamentos\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\departamentos\\" + idEmpresa + "\\"));

                //string diretorio = this.Server.MapPath("~\\idisque.com.br\\img\\departamento\\" + idEmpresa + "\\" + url);

                //Directory.CreateDirectory(Server.MapPath("~\\img\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\img\\produtos\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\img\\produtos\\" + idEmpresa + "\\"));

                //string diretorio = this.Server.MapPath("~\\img\\produtos\\" + idEmpresa + "\\" + url);

                Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\"));
                Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\produtos\\"));
                Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\produtos\\" + idEmpresa + "\\"));


                string diretorio = this.Server.MapPath("~\\idisque.com.br\\img\\produtos\\" + idEmpresa + "\\" + url);

                userPostedFile.SaveAs(diretorio);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}