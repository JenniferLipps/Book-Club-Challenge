using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        //public int ISBN { get; set; }
        public Uri Image { get; set; }
    }
}
