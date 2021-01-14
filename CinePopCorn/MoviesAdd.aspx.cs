using CinePopCorn.Application.Movies;
using CinePopCorn.Domain.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class MoviesAdd : System.Web.UI.Page
    {
        MoviesApplication movieApp = new MoviesApplication();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Page.Session["logado"]))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Login.aspx';</script>");
                return;
            }

            int idMovie = Convert.ToInt32(Page.Session["idMovie"]);

            if (idMovie == 0)
                idimage.Visible = false;

            if (idMovie > 0)
            {
                Movie movie = movieApp.GetMovieById(idMovie);
                idtitle.Value = movie.Title;
                iddescription.Value = movie.Description;
                idtime.Value = Convert.ToString(movie.Time);
                string[] nameImage = movie.ImageName.Split('.');
                foreach (var item in nameImage)
                {
                    idimage.ImageUrl = "images/movies/" + idMovie + "." + item;
                }
            }
        }

        protected void BtnMovie_Click(object sender, EventArgs e)
        {
            int idMovie = Convert.ToInt32(Page.Session["idMovie"]);

            Movie m = new Movie();
            m.Id = idMovie;
            m.Title = Convert.ToString(Request.Form["idtitle"]);
            m.Description = Convert.ToString(Request.Form["iddescription"]);
            m.Time = Convert.ToInt32(Request.Form["idtime"]);

            if (idanexararquivo.HasFile)
            {
                m.ImageName = idanexararquivo.PostedFile.FileName;
                m.ImageType = idanexararquivo.PostedFile.ContentType;

                using (Stream fs = idanexararquivo.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        m.Image = br.ReadBytes((Int32)fs.Length);
                    }
                }
            }

            string result = string.Empty;

            if (idMovie > 0)
                result = movieApp.UpdateMovie(m);
            else
                result = movieApp.AddMovie(m);

            if (result == "")
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Movies.aspx';</script>");
            else
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> alert('" + result + "')</script>");
        }
    }
}