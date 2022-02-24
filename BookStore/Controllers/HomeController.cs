using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {

        // use repo pattern
        private IBookStoreRepository repo;
        public HomeController (IBookStoreRepository temp)
        {
            repo = temp;
        }

        
        //function passes values to PageInfo
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                    .Where(b => b.Category == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title)
                    .Skip(pageSize * (pageNum - 1))
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (bookCategory == null 
                            ? repo.Books.Count() 
                            : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            //return BookViewModel
            return View(x);
        }
    }
}
