using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM
{
    public partial class login : System.Web.UI.Page
    {
        UsuarioRegraNegocios usuarioRegraNegocios;
        EmpresaRegraNegocios empresaRegraNegocios;

        public int  IdNivel, idEmpresa, idPessoa, idUsuario = 0;
        public string email, senha, fantasia = "";
        public bool status;

        //public string administradora, logradouroAdm, numAdm, cidadeAdm, cepAdm, ufAdm, telefoneAdm, emailAdm = "";
        public int idAdministradora = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Logar()
        {
            try
            {
                email = txtEmailCel.Text.Trim();
                senha = txtSenha.Text.Trim();

                if (email.Trim() == "")
                {
                    FailureText.Text = "Atenção, Campo Login não Pode ser Nulo ou Vázio.";
                }
                else if (senha.Trim() == "")
                {
                    FailureText.Text = "Atenção, Campo Senha não Pode ser Nulo ou Vázio.";
                }
                else
                {
                    usuarioRegraNegocios = new UsuarioRegraNegocios();

                    var lista = usuarioRegraNegocios.Logar(email, senha);

                    if (lista.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(lista.Rows[0]["Status"].ToString()) == false)
                        {
                            Response.Redirect("~/Ops.aspx", false);
                        }
                        else
                        {
                            try
                            {
                                idEmpresa = Convert.ToInt32(lista.Rows[0]["ID_EMPRESA"].ToString());
                            }
                            catch
                            {
                                idEmpresa = Convert.ToInt32(lista.Rows[0]["Id"].ToString());
                            }

                            idUsuario = Convert.ToInt32(lista.Rows[0]["Id"].ToString());
                            IdNivel = Convert.ToInt32(lista.Rows[0]["ID_TIPO_USUARIO"].ToString());
                            email = lista.Rows[0]["Email"].ToString().Trim();
                            fantasia = lista.Rows[0]["FANTASIA"].ToString().Trim();

                            Session["idUsuario"] = idUsuario;
                            Session["idEmpresa"] = idEmpresa;
                            Session["usuarioLogado"] = fantasia.Trim();


                            GerarCookies();


                            Response.Redirect("~/Default.aspx?idEmpresa=" + idEmpresa + "&nomeEmpresa=" + fantasia , false);
                        }
                    }
                    else
                    {
                        FailureText.Text = "Login ou Senha está Incorreto";
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Logar();
        }



        public void GerarCookies()
        {
            try
            {
                //Time para expiração (1min)
                DateTime dtNow = DateTime.Now;
                TimeSpan tsMinute = new TimeSpan(1, 0, 0, 0);

                #region ID USUSARIO

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieIdUsuario = new HttpCookie("IdUsuario");
                cookieIdUsuario.Value = idUsuario.ToString();

                cookieIdUsuario.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieIdUsuario);

                #endregion

                #region LOGIN

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieLogin = new HttpCookie("Email");
                cookieLogin.Value = email.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieLogin.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieLogin);

                #endregion

                #region EMPRESA

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieNomeAdm = new HttpCookie("Empresa");
                cookieNomeAdm.Value = fantasia.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieNomeAdm.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieNomeAdm);

                #endregion

                #region NIVEL

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieNivel = new HttpCookie("idNivel");
                cookieNivel.Value = IdNivel.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieNivel.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieNivel);

                #endregion

                #region ID EMPRESA

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieAIdEmpresa = new HttpCookie("idEmpresa");
                cookieAIdEmpresa.Value = idEmpresa.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieAIdEmpresa.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieAIdEmpresa);

                #endregion
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}