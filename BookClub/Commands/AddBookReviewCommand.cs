﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Commands
{
    public class AddBookReviewCommand
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int GoodReadsBookId { get; set; }
    }
}
