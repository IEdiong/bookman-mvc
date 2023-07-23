using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookman.Models;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookman.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /<controller>/
        [HttpPost]
        public IActionResult Create(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var newBook = new Book(book.Name)
                {
                    Author = book.Author,
                    Year = book.Year,
                    Price = book.Price,
                    Description = book.Description
                };
                _bookRepository.CreateBook(newBook);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}

