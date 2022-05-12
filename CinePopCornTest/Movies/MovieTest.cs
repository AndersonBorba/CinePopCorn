using CinePopCorn.Application.Movies;
using CinePopCorn.Domain.Movies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCornTest.Movies
{
    [TestClass]
    public class MovieTest
    {
        MoviesApplication movie = new MoviesApplication();
        [TestMethod]
        public void TestGetMovies()
        {
            List<Movie> movies = new List<Movie>();
            movies = movie.GetMovies();
            Assert.IsNotNull(movies, "Deve ser diferente de null");
        }

        [TestMethod]
        public void TestCreateMovie()
        {

            string title = Guid.NewGuid().ToString();
            Movie m = new Movie();
            m.Title = title;
            m.Time = 90;
            m.Description = "Ação";
            m.Image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            m.ImageName = "teste.jpg";
            m.ImageType = "image/jpeg";
            movie.AddMovie(m);

           m = movie.GetMovieByTitle(m.Title);

            Assert.AreEqual(m.Title, title);

        }

    }
}
