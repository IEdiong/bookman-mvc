using Bookman.Models;
using Bookman.Services;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookman.Controllers
{
    [Authorize(Roles = "Admin")]
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
                var newBook = new Book(model.Name);
                if (model.ImageFile != null)
                {
                    string fileName = UtilsService.GetUniqueFileName(model.ImageFile.FileName);
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "imgs", fileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    newBook.FileName = fileName;
                }

                newBook.Author = model.Author;
                newBook.Year = model.Year;
                newBook.Price = model.Price;
                newBook.Description = model.Description;
                newBook.Date = DateTime.Now;

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

