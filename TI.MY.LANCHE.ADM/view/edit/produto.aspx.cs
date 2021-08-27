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

        int idProducto, idDepartamento = 0;
        //string urlEndereco = "";
        string idRetorno, idEmpresa, nomeEmpresa, idProduto, url, extensaoImg = "";


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
            nomeEmpresa = Request.QueryString["nomeEmpresa"];
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
                    ddlDepartamento.SelectedValue = dadosTabela.Rows[0]["ID_DEPARTAMENTO"].ToString();
                    ddlDepartamento.DataTextField = dadosTabela.Rows[0]["DESCRICAO_DEPARTAMENTO"].ToString();
                    chkAtivo.Checked = Convert.ToBoolean(dadosTabela.Rows[0]["ATIVO"].ToString());
                    txtDescricao.Text = dadosTabela.Rows[0]["DESCRICAO"].ToString();
                    txtUnidade.Text = dadosTabela.Rows[0]["UNID"].ToString();
                    txtPreco.Text = dadosTabela.Rows[0]["PRECO"].ToString();
                    txtCusto.Text = dadosTabela.Rows[0]["CUSTO"].ToString();
                    //flUpFile = dadosTabela.Rows[0]["URL_PRODUTO"].ToString();
                    txtGranel.Text = dadosTabela.Rows[0]["GRANEL"].ToString();
                    txtCusto.Text = dadosTabela.Rows[0]["CUSTO"].ToString();
                    txtEstoque.Text = dadosTabela.Rows[0]["ESTOQUE"].ToString();
                    txtIngredientes.Text = dadosTabela.Rows[0]["INGREDIENTES"].ToString();
                }
                else
                {
                    ddlDepartamento.DataSource = null;
                }
                txtPreco.Focus();

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
                    try
                    {
                        string[] nomeImag = flUpFile.FileName.Split('.');
                        extensaoImg = nomeImag[1].ToString();
                    }
                    catch (Exception)
                    {
                        extensaoImg = idProduto + ".jpg";
                    }
                    producto.urlFoto = "http://adm.idisque.com.br\\img\\produtos\\" + idEmpresa +"\\" + idProduto + "." + extensaoImg;

                    producto.ingredientes = txtIngredientes.Text.Trim();

                    producto.Departamento_Produto = new Departamento_Produto();

                    producto.Departamento_Produto.idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
                    producto.Departamento_Produto.idEmpresa = Convert.ToInt32(idEmpresa);
                    producto.Departamento_Produto.preco = Convert.ToDecimal(txtPreco.Text);
                    try
                    {
                        producto.Departamento_Produto.custo = Convert.ToDecimal(txtCusto.Text);
                    }
                    catch
                    {
                        producto.Departamento_Produto.custo = 0;

                    }
                    try
                    {
                        producto.Departamento_Produto.estoque = Convert.ToDecimal(txtEstoque.Text);
                    }
                    catch
                    {
                        producto.Departamento_Produto.estoque = 0;
                    }
                    producto.Departamento_Produto.granel = txtGranel.Text.ToUpper();
                    producto.Departamento_Produto.ativo = Convert.ToBoolean(chkAtivo.Checked);

                    //produto.Produto_Observacao.Observacao = txtIngredientes.Text.Trim();


                    //PRODUTO
                    produtoRegraNegocios = new ProdutoRegraNegocios();
                    idRetorno = produtoRegraNegocios.AddProduto(producto, 2);

                    try
                    {
                        if ((flUpFile.FileName != ""))
                        {
                            UploadImagem();
                        }
                        Convert.ToInt32(idRetorno);

                        Response.Redirect("~/view/list/produto.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + nomeEmpresa + "&idDepartamento=" + producto.Departamento_Produto.idDepartamento, false);
                      
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

                url = flUpFile.PostedFile.FileName;
                string[] nomeImag = url.Split('.');
                string extensaoImg = nomeImag[1].ToString();
                url = idProduto + "." + extensaoImg;

                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\departamentos\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\departamentos\\" + idEmpresa + "\\"));

                //string diretorio = this.Server.MapPath("~\\idisque.com.br\\img\\departamento\\" + idEmpresa + "\\" + url);


                Directory.CreateDirectory(Server.MapPath("~\\img\\"));
                Directory.CreateDirectory(Server.MapPath("~\\img\\produtos\\"));
                Directory.CreateDirectory(Server.MapPath("~\\img\\produtos\\" + idEmpresa + "\\"));


                string diretorio = this.Server.MapPath("~\\img\\produtos\\" + idEmpresa + "\\" + url);


                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\produtos\\"));
                //Directory.CreateDirectory(Server.MapPath("~\\idisque.com.br\\img\\produtos\\" + idEmpresa + "\\"));


                //string diretorio = this.Server.MapPath("~\\idisque.com.br\\img\\produtos\\" + idEmpresa + "\\" + url);

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