using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TI.REGRA.NEGOCIOS;
using TI.TRGRA.NEGOCIOS;

namespace TI.MY.LANCHE
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PesquisarEmpresaLogado();
            }
        }
        public string layoutLogo = "";

        public void PesquisarEmpresaLogado()
        {
            try
            {
                loginEmpresa.Text = Request.Path.Replace("/", "").Replace(".aspx", "").Replace("-", " ").ToUpper() ;
                layoutLogo = Session["iFramelogoScript"].ToString();

                iFramelogoScript.Controls.Add(new LiteralControl(layoutLogo));
            }
            catch
            {
                layoutLogo = "";
            }
        }
    }
}