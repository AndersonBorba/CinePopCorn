using CinePopCorn.Application.Sessions;
using CinePopCorn.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class Sessions : System.Web.UI.Page
    {
        SessionsApplication app = new SessionsApplication();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Page.Session["logado"]))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Login.aspx';</script>");
                return;
            }

            List<Session> Sessions = app.GetSessions();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("date");
            dt.Columns.Add("value");
            dt.Columns.Add("typeanimation");
            dt.Columns.Add("typesound");
            dt.Columns.Add("movie");
            dt.Columns.Add("room");
            foreach (var item in Sessions)
            {
                string animation = item.TypeAnimation == 0 ? "2D" : "3D";
                string sound = item.TypeAnimation == 0 ? "Original" : "Dublado";
                DataRow row = dt.NewRow();
                dt.Rows.Add(item.Id, item.Date.ToString("dd/MM/yyyy HH:mm"), item.Value, animation, sound, item.movie.Title, item.room.Name);
            }
            gvSessions.DataSource = dt;
            gvSessions.DataBind();
        }


        protected void gvSession_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            int IdSelected = Convert.ToInt32(gv.DataKeys[e.RowIndex].Value);

            string result = app.DeleteSession(IdSelected);
            if (result != "")
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'>alert('" + result + "')</script>");

            Page_Load(null, null);
        }

        protected void gvSession_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                            button.OnClientClick = "if (!confirm('Confirma exclusão da sessão?')) return;";
                    }
                }
            }
        }

        protected void btnAddSession_Click(object sender, EventArgs e)
        {
            Page.Session["idSession"] = null;
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/SessionsAdd.aspx';</script>");
        }

        protected void gvSession_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSessions.PageIndex = e.NewPageIndex;
            gvSessions.DataBind();
        }

        protected void gvSession_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            int IdSelected = Convert.ToInt32(gv.DataKeys[e.NewEditIndex].Value);
            Page.Session["idSession"] = IdSelected;
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/SessionsAdd.aspx';</script>");
        }
    }
}