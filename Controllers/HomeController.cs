using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookman.Models;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Identity;
using Bookman.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Bookman.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWebHostEnvironment _hostEnvironment;

    public HomeController(ILogger<HomeController> logger,
        IBookRepository bookRepository,
        UserManager<IdentityUser> userManager,
         IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _userManager = userManager;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        //var user = await _userManager.GetUserAsync(User);
        //if (user != null)
        //{
        //    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        //    var roles = await _userManager.GetRolesAsync(user);
        //}
        var books = _bookRepository.AllBooks;
        return View(books);
    }

    public IActionResult Details(int bookId)
    {
        var book = _bookRepository.GetBookById(bookId);
        return View(book);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult Edit(int bookId)
    {
        var book_db = _bookRepository.GetBookById(bookId);
        if (book_db != null)
        {
            var book = new BookViewModel()
            {
                Id = book_db.Id,
                Name = book_db.Name,
                Author = book_db.Author!,
                Year = book_db.Year,
                Price = book_db.Price,
                Description = book_db.Description!
            };

            return View(book);
        }

        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult Edit(BookViewModel model)
    {
        if (ModelState.IsValid)
        {
            var id = model.Id;
            var bookToEdit = _bookRepository.GetBookById(id);
            if (bookToEdit != null)
            {
                if (model.ImageFile != null)
                {
                    string fileName = UtilsService.GetUniqueFileName(model.ImageFile.FileName);
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, "imgs", fileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    bookToEdit.FileName = fileName;
                }

                bookToEdit.Author = model.Author;
                bookToEdit.Year = model.Year;
                bookToEdit.Price = model.Price;
                bookToEdit.Description = model.Description;
                bookToEdit.Date = DateTime.Now;

                _bookRepository.SaveBook();
                return RedirectToAction("Details", "Home", new { bookId = id });
            }
            return NotFound();
        }
        else
        {
            return View();
        }
    }

    [HttpGet]
    public IActionResult Search(string searchString)
    {
        var books = _bookRepository.GetBooks(searchString);
        return View("Index", books);
    }

    [HttpGet]
    public IActionResult Filter(string filter)
    {
        var books = _bookRepository.FilterBooksBy(filter);
        return View("Index", books);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

