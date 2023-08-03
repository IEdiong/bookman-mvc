using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookman.Models;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bookman.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger,
        IBookRepository bookRepository,
        UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _userManager = userManager;
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

