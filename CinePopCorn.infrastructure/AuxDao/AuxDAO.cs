using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.infrastructure.AuxDao
{
    static class AuxDAO
    {
        static public string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbPopCorn"].ConnectionString;
            return connectionString;
        }

        static public string GetPathImage()
        {
            string pathMovie = ConfigurationManager.AppSettings["PathMovies"];
            return pathMovie;
        }

        static public string GetUrlApiLog()
        {
            string url = ConfigurationManager.AppSettings["UrlLogger"];
            return url;
        }
    }
}
