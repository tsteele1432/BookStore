using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class PageInfo
    {
        //Create page info model
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Total pages calculation
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);

    }
}
