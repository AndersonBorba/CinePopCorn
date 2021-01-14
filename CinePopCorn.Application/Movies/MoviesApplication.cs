using CinePopCorn.Domain.Movies;
using CinePopCorn.infrastructure.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Application.Movies
{
    public class MoviesApplication
    {
        MovieDAO dao;
        public MoviesApplication()
        {
            dao = new MovieDAO();
        }
        public List<Movie> GetMovies()
        {
            return dao.GetMovies();
        }

        public string DeleteMovie(int id)
        {
            int session = dao.GetSessionByIdMovie(id);
            if (session > 0)
                return "Filme com sessão vinculada, operação cancelada!!";
            dao.DeleteMovie(id);
            return "";
        }

        public string AddMovie(Movie m)
        {
            if (m.Image == null)
                return "Selecione uma imagem";

            int repeatedTitles = dao.GetRepeatedTitles(m.Title, 0);
            if (repeatedTitles > 0)
                return "Título já cadastrado";

            string result = dao.AddMovie(m);

            return result;
        }

        public Movie GetMovieById(object idMovie)
        {
            return dao.GetMovieById(idMovie);
        }

        public string UpdateMovie(Movie m)
        {
            int repeatedTitles = dao.GetRepeatedTitles(m.Title, m.Id);
            if (repeatedTitles > 0)
                return "Título já cadastrado";

            string result = dao.UpdateMovie(m);

            return result;
        }
    }
}
