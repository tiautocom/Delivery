using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE.ADM
{

    public partial class SiteMaster : MasterPage
    {
        #region CLASSES E OBJETOS

        #endregion

        #region VARIAVEIS

        public string idEmpresa, login = "";
        public string nomeEmpresa = "";

        public int idEmp, idUsuario, idNivel = 0;

        PessoaRegraNegocios pessoaRegraNegocios;


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!IsPostBack)
                {
                    idUsuario = Convert.ToInt32(Session["IdUsuario"]);

                    idEmp = Convert.ToInt32(Convert.ToInt32(Session["IdEmpresa"]));

                    if (idEmp > 0)
                    {
                        Session["IdEmpresa"] = idEmp;
                    }
                    else
                    {
                        idEmp = Convert.ToInt32(Convert.ToInt32(Session["IdEmpresa"]));
                    }
                }
                else
                {
                    idEmp = Convert.ToInt32(Session["IdEmpresa"]);
                }

                LerCookie();

                //GetDados();

                //PesquisarEmpresas();
            }

        }

        private void PesquisarEmpresas()
        {
            try
            {
                pessoaRegraNegocios = new PessoaRegraNegocios();

                var Lista = pessoaRegraNegocios.Login();

                if (Lista.Rows.Count > 0)
                {
                  
                    int cont = 0;

                    for (int i = 0; i < Lista.Rows.Count; i++)
                    {
                        idUsuario = Convert.ToInt32(Lista.Rows[i]["Id"].ToString().Trim());
                        idNivel = Convert.ToInt32(Lista.Rows[i]["Tipo"].ToString().Trim());
                        nomeEmpresa = Lista.Rows[i]["NomeRazao"].ToString().Trim();
                        login = Lista.Rows[i]["Email"].ToString().Trim();

                        cont++;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex.Message;
                Response.Redirect("~/Error.aspx");
            }
        }

        private void GetDados()
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
                cookieLogin.Value = login.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieLogin.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieLogin);

                #endregion
                             
                #region NIVEL

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieNivel = new HttpCookie("idNivel");
                cookieNivel.Value = idNivel.ToString();

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
                cookieAIdEmpresa.Value = idEmp.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieAIdEmpresa.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieAIdEmpresa);

                #endregion

                #region NOME

                //Cria a estancia do obj HttpCookie passando o nome do mesmo
                HttpCookie cookieEmpresa = new HttpCookie("nomeEmpresa");
                cookieEmpresa.Value = nomeEmpresa.ToString();


                //HttpCookie cookieNomeAdm = new HttpCookie("NomeEmpresa");
                //cookieNomeAdm.Value = nomeEmpresa.ToString();

                //Time para expiração (1min)
                dtNow = DateTime.Now;
                tsMinute = new TimeSpan(1, 0, 0, 0);

                cookieEmpresa.Expires = (dtNow + tsMinute);

                //Adiciona o cookie
                Response.Cookies.Add(cookieEmpresa);

                #endregion
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void LerCookie()
        {
            try
            {
                //Cria o obj cookie e recebe o IdUsuario
                HttpCookie cookieU = new HttpCookie("idUsuario");
                cookieU = Request.Cookies["idUsuario"];
                idUsuario = Convert.ToInt32(cookieU.Value.ToString());

                //Cria o obj cookie e recebe o Login
                HttpCookie cookieLogin = new HttpCookie("Email");
                cookieLogin = Request.Cookies["Email"];
                login = cookieLogin.Value.ToString().Trim();

                //Cria o obj cookie e recebe o SenhaSeg
                HttpCookie cookieFantasia = new HttpCookie("Empresa");
                cookieFantasia = Request.Cookies["Empresa"];
                nomeEmpresa = cookieFantasia.Value.ToString().Trim();

                //Cria o obj cookie e recebe o IdUsuario
                HttpCookie cookieE = new HttpCookie("idEmpresa");
                cookieE = Request.Cookies["idEmpresa"];
                idEmp = Convert.ToInt32(cookieU.Value.ToString());

                //Cria o obj cookie e recebe o SenhaSeg
                HttpCookie cookieIdNivel = new HttpCookie("idNivel");
                cookieIdNivel = Request.Cookies["idNivel"];
                idNivel = Convert.ToInt32(cookieIdNivel.Value.ToString().Trim());

                if (idUsuario > 0)
                {
                    //loginEmpresa.Text = nomeEmpresa.Trim();
                    //loginEmpresa2.Text = nomeEmpresa.Trim();
                    //loginEmpresa3.Text = nomeEmpresa.Trim();

                    //LiteralAba.Text = nomeEmpresa;

                    Session["NomeEmpresa"] = nomeEmpresa.Trim();
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            catch
            {
                idUsuario = 0;

                Response.Redirect("~/Login.aspx", false);
            }
        }

        private void ListQueryString()
        {
                nomeEmpresa = Request.QueryString["nomeEmpresa"];

                idEmpresa = Request.QueryString["idEmpresa"];
                idEmp = Convert.ToInt32(idEmpresa);

        }
    }
}