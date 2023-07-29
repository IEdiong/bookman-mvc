using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookman.Models;
using Bookman.Services;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookman.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _hostEnvironment;


        public BookController(IBookRepository bookRepository, IWebHostEnvironment hostEnvironment)
        {
            _bookRepository = bookRepository;
            _hostEnvironment = hostEnvironment;
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
            if (ModelState.IsValid)
            {
                string fileName = UtilsService.GetUniqueFileName(model.ImageFile.FileName);
                string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "imgs", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                var newBook = new Book(model.Name)
                {
                    Author = model.Author,
                    Year = model.Year,
                    Price = model.Price,
                    Description = model.Description,
                    FileName = fileName
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

