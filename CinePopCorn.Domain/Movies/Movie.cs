using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Domain.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }

        public string ImageName { get; set; }
        public string ImageType { get; set; }

    }
}
