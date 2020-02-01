using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Commands
{
    public class AddBookCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageURL { get; set; }
        public long GoodReadsBookId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCompleted { get; set; } = DateTime.Now;
    }
}
