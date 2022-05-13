using CinePopCorn.Application.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class Login : System.Web.UI.Page
    {
        LoggersApplication loggersApplication;
        public Login()
        {
            loggersApplication = new LoggersApplication();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Page.Session["logado"] = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (idemail.Value == "hiper@tech.com" & idsenha.Value == "@1234&")
                Page.Session["logado"] = true;
            else
            {
                Page.Session["logado"] = false;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'>alert('Usuário e/ou senha inválidos')</script>");
                return;
            }

            Task.Factory.StartNew(() =>
            {
                loggersApplication.logar("logar", $"usuario:{idemail.Value} efetuou login!");
            });

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Rooms.aspx';</script>");
        }
    }
}


