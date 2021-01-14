using CinePopCorn.Application.Movies;
using CinePopCorn.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Page.Session["logado"]))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Login.aspx';</script>");
                return;
            }
             
            MoviesApplication app = new MoviesApplication();
            List<Movie> movies = app.GetMovies();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("title");
            dt.Columns.Add("description");
            dt.Columns.Add("time");
            foreach (var item in movies)
            {
                DateTime date = new DateTime(2020, 1, 1, 0, 0, 0);
                date = date.AddMinutes(item.Time);
                string mt = (date.Hour > 0 ? (date.Hour == 1 ? date.Hour + "h " : date.Hour + "hs ") : "") + (date.Minute > 0 ? date.Minute + "min" : "");

                DataRow row = dt.NewRow();
                dt.Rows.Add(item.Id, item.Title, item.Description, mt);
            }
            gvMovies.DataSource = dt;
            gvMovies.DataBind();
        }


        protected void gvMovies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            int IdSelected = Convert.ToInt32(gv.DataKeys[e.RowIndex].Value);

            MoviesApplication app = new MoviesApplication();
            string result = app.DeleteMovie(IdSelected);

            if (result != "")
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'>alert('" + result + "')</script>");
                return;
            }

            Page_Load(null, null);
        }

        protected void gvMovies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                            button.OnClientClick = "if (!confirm('Confirma exclusão do filme?')) return;";
                    }
                }
            }
        }

        protected void btnAddMovie_Click(object sender, EventArgs e)
        {
            Page.Session["idMovie"] = null;
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/MoviesAdd.aspx';</script>");
        }

        protected void gvMovies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMovies.PageIndex = e.NewPageIndex;
            gvMovies.DataBind();
        }

        protected void gvMovies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            int IdSelected = Convert.ToInt32(gv.DataKeys[e.NewEditIndex].Value);
            Page.Session["idMovie"] = IdSelected;
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/MoviesAdd.aspx';</script>");
        }
    }
}