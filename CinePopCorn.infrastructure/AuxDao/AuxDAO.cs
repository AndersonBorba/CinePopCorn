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
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=I:\PROJECTS\CINE\CinePopCorn.infrastructure\CinePopCorn.mdf;Integrated Security=True";
        }

        static public string GetPathImage()
        {
            return @"I:\PROJECTS\CINE\CinePopCorn\images\movies\";
        }
    }
}
