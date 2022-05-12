using CinePopCorn.Domain.Movies;
using CinePopCorn.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Domain.Sessions
{
   public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int TypeAnimation { get; set; }
        public int TypeSound { get; set; }
        public Movie movie { get; set; }
        public Room room { get; set; }
    }
}
