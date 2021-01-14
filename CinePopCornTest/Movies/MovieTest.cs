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

    }
}
