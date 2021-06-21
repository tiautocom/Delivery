using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.OBJETO.TRANSFERENCIA;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM.view.add
{
    public partial class empresa : System.Web.UI.Page
    {
        #region CLASSES E OBJETOS

        Pessoa pessoa;
        //EmpresaPJ EmpresaPj;
        PessoaRegraNegocios pessoaRN;


        #endregion

        #region VARIAVEIS

        string idRetorno = "";
        string urlEndereco = "";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fantasia.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo Nome Fantasia não Pode ser Nulo ou Vázio')</script>");
                    Fantasia.Focus();
                }
                else if (txtCnpj.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo CNPJ não Pode ser Nulo ou Vázio')</script>");
                    txtCnpj.Focus();
                }
                else if (txtEmail.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo E-Mail não Pode ser Nulo ou Vázio')</script>");
                    txtEmail.Focus();
                }

                else
                {

                    pessoa = new Pessoa();

                    pessoa.Fantasia = Fantasia.Text.ToUpper().Trim();
                    pessoa.CpfCnpj = txtCnpj.Text.ToUpper().Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                    pessoa.RgIe = "";
                    pessoa.Email = txtEmail.Text.ToLower().Trim();
                    pessoa.Ativo = Convert.ToBoolean(ddlAtivo.SelectedValue);

                    pessoa.Empresa = new EmpresaPJ();

                    pessoa.Empresa.IM = "";
                    pessoa.Empresa.Telefone = txtFone.Text;
                    pessoa.Empresa.HoraAbertura = txtHoraAbertura.ToString();
                    pessoa.Empresa.HoraFechamento = txtHoraFechamnto.ToString();
                    pessoa.Empresa.Img_Logo = "";
                    pessoa.Empresa.idSetor = 1;

                   


                    //PESSOA
                    pessoaRN = new PessoaRegraNegocios();
                    idRetorno = pessoaRN.AddEmpresa(pessoa, 1);
                    

                    try
                    {
                        Convert.ToInt32(idRetorno);
                        Response.Redirect("~/View/Add/empresa.aspx?idEmpresa=" + idRetorno + "&nomeEmpresa=" + pessoa.Fantasia, false);

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

        private void CreateDirectory()
        {
            Directory.CreateDirectory(Server.MapPath("~\\idisque\\" + idRetorno + "\\"));
        }

        public bool SalvarFotoArquivo()
        {
            try
            {
               
                if (fupImagem.FileName == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Atenção, Informe Foto Desejado.')</script>");
                    return false;
                }
                else if (fupImagem.FileName.ToString().Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Atenção, Informe Foto Desejado.')</script>");
                    return false;
                }
                else
                {

                    CreateDirectory();

                    string filepath = Server.MapPath(urlEndereco);

                    fupImagem.PostedFile.SaveAs(filepath + "\\" + fupImagem.FileName);

                    return true;
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Session["Error"] = ex.Message;
                return false;
            }
            finally
            {
            }
        }

        protected void New_Click(object sender, EventArgs e)
        {

        }
    }
}