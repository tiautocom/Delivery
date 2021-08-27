using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.REGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.add
{
    public partial class departamentonovo : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Departament departamento;

        DepartamentoRegraNegocios departamentoRegraNegocios;

        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        //string urlEndereco = "";
        public string idEmpresa, nomeEmpresa, url, idDepartamento = "";
        public int idEmp, idDep = 0;

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
            lblEmpresa.Text = nomeEmpresa;

            idEmpresa = Request.QueryString["idEmpresa"];
            idEmp = Convert.ToInt32(idEmpresa);
            idDepartamento = Request.QueryString["idProduto"];
            idDep = Convert.ToInt32(idDepartamento);
            lblIdDepartamento.Text = idDepartamento;

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
                    departamento.urlFoto = fupImagem.ToString();
                    



                    //DEPARTAMENTO
                    departamentoRegraNegocios = new DepartamentoRegraNegocios();
                    idRetorno = departamentoRegraNegocios.AddDepartamento(departamento, 1);


                    try
                    {
                        UploadImagem();
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

                Directory.CreateDirectory(Server.MapPath("~\\img\\"));
                Directory.CreateDirectory(Server.MapPath("~\\img\\departamentos\\"));
                Directory.CreateDirectory(Server.MapPath("~\\img\\departamentos\\" + idEmpresa + "\\"));

                string diretorio = this.Server.MapPath("~\\idisque.com.br\\img\\departamentos\\" + idEmpresa + "\\" + url);

                userPostedFile.SaveAs(diretorio);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}