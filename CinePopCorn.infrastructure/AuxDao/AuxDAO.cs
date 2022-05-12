using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.infrastructure.AuxDao
{
    static class AuxDAO
    {
        static public string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aborba\source\repos\CinePopCorn-main\CinePopCorn.infrastructure\CinePopCorn.mdf;Integrated Security=True";
        }

        static public string GetPathImage()
        {
            return @"C:\Users\aborba\source\repos\CinePopCorn-main\CinePopCorn\images\movies\";
        }
    }
}
