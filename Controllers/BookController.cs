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
        public IActionResult Create(BookViewModel model)
        {
            return View();
        }
    }
}

