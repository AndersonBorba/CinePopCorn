using CinePopCorn.Application.Movies;
using CinePopCorn.Application.Rooms;
using CinePopCorn.Application.Sessions;
using CinePopCorn.Domain.Movies;
using CinePopCorn.Domain.Rooms;
using CinePopCorn.Domain.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinePopCorn
{
    public partial class SessionsAdd : System.Web.UI.Page
    {
        MoviesApplication moviesApplication = new MoviesApplication();
        RoomsApplication roomsApplication = new RoomsApplication();
        SessionsApplication sessionAplication = new SessionsApplication();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Page.Session["logado"]))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Login.aspx';</script>");
                return;
            }

            int idSession = Convert.ToInt32(Page.Session["idSession"]);

            List<Movie> movies = new List<Movie>();
            movies = moviesApplication.GetMovies();
            foreach (var item in movies) { idmovie.Items.Add(new ListItem(item.Title + "/" + item.Time, item.Id.ToString())); }

            List<Room> rooms = new List<Room>();
            rooms = roomsApplication.GetRooms();
            foreach (var item in rooms) { idroom.Items.Add(new ListItem(item.Name, item.Id.ToString())); }

            if (idSession > 0)
            {
                Session session = sessionAplication.GetSessionById(idSession);
                iddate.Value = session.Date.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                idvalue.Value = session.Value.ToString("G").Replace(",", ".");
                idtypeanimation.Value = session.TypeAnimation.ToString();
                idtypesound.Value = session.TypeSound.ToString();
                idmovie.Value = session.movie.Id.ToString();
                idroom.Value = session.room.Id.ToString();
                idfimsessao.Value = session.Date.AddMinutes(session.movie.Time).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
            }
        }

        protected void BtnSession_Click(object sender, EventArgs e)
        {
            int idSession = Convert.ToInt32(Page.Session["idSession"]);

            Session s = new Session();
            s.Id = idSession;
            s.Date = Convert.ToDateTime(Request.Form["iddate"]);
            s.Value = Convert.ToDecimal(Request.Form["idvalue"].Replace(".", ","));
            s.TypeAnimation = Convert.ToInt32(Request.Form["idtypeanimation"]);
            s.TypeSound = Convert.ToInt32(Request.Form["idtypesound"]);
            s.movie = new Movie();
            s.movie = moviesApplication.GetMovieById(Convert.ToInt32(Request.Form["idmovie"]));
            s.room = new Room();
            s.room.Id = Convert.ToInt32(Request.Form["idroom"]);

            string result = string.Empty;

            if (idSession > 0)
                result = sessionAplication.UpdateSession(s);
            else
                result = sessionAplication.AddSession(s);

            if (result == "")
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> win = window.open('', '_self', 'toolbar=no, overflow = auto; scrollbars=auto, resizable=yes'); win.location.href ='/Sessions.aspx';</script>");
            else
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", @"<script type='text/javascript'> alert('" + result + "')</script>");
        }
    }
}