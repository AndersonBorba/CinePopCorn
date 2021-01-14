using CinePopCorn.Application.Rooms;
using CinePopCorn.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Page.Session["logado"]))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Login.aspx';</script>");
                return;
            }

            RoomsApplication app = new RoomsApplication();
            List<Room> rooms =  app.GetRooms();

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("qtd");
            foreach (var item in rooms)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(item.Name, item.Seats);
            }
            gvRooms.DataSource = dt;
            gvRooms.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }
    }
}