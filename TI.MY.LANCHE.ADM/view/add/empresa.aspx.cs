using System;
using System.Collections.Generic;
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
        EmpresaPJ empresaPj;
        PessoaRegraNegocios pessoaRN;


        #endregion

        #region VARIAVEIS

        string idRetorno = "";

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
                else if (Cnpj.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo CNPJ não Pode ser Nulo ou Vázio')</script>");
                    Cnpj.Focus();
                }
                else if (Email.Text.Trim().Equals(""))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('* Campo E-Mail não Pode ser Nulo ou Vázio')</script>");
                    Email.Focus();
                }

                else
                {

                    pessoa = new Pessoa();

                    pessoa.Fantasia = Fantasia.Text.ToUpper().Trim();
                    pessoa.CpfCnpj = Cnpj.Text.ToUpper().Replace(".", "").Replace("-", "").Replace("/", "").Trim();
                    pessoa.RgIe = "";
                    pessoa.Email = Email.Text.ToLower().Trim();
                    pessoa.Ativo = Convert.ToBoolean(ddlAtivo.SelectedValue);


                    empresaPj = new EmpresaPJ();
                    empresaPj.IM = "";
                    empresaPj.Telefone = txtFone.Text;
                    empresaPj.HoraAbertura = "";
                    empresaPj.HoraFechamento = "";
                    empresaPj.Img_Logo = "";
                    empresaPj.idSetor = 1;



                    //PESSOA
                    pessoaRN = new PessoaRegraNegocios();
                    idRetorno = pessoaRN.AddEmpresa(pessoa, empresaPj, 1);
                    CreateDirectory();
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

        }

        protected void New_Click(object sender, EventArgs e)
        {

        }
    }
}