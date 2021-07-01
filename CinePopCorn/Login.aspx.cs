using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Page.Session["logado"] = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (idemail.Value == "exactsales@tech.com" & idsenha.Value == "@1234&")
                Page.Session["logado"] = true;
            else
            {
                Page.Session["logado"] = false;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'>alert('Usuário e/ou senha inválidos')</script>");
                return;
            }

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Rooms.aspx';</script>");
        }
    }
}


