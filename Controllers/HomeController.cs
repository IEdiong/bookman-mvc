using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookman.Models;
using Bookman.ViewModels;

namespace Bookman.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepository;

    public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
    }

    public IActionResult Index()
    {
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

