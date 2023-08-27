using Bookman.Models;
using Bookman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Bookman.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;


        public OrderController(
            UserManager<IdentityUser> userManager,
            IBookRepository bookRepository,
            IOrderRepository orderRepository
            )
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        // GET: /<controller>
        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var orders = _orderRepository.GetUserOrders(userId);
            return View(orders);
        }

        // GET: /<controller>/Create
        [HttpGet]
        public IActionResult Create(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            ViewData["book"] = book;
            return View();
        }

        // POST: /<controller>/Create
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var book = _bookRepository.GetBookById(model.BookId);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    var order = new Order(user.Id, model.Address, model.Email, model.PhoneNumber)
                    {
                        BookId = model.BookId,
                        Date = DateTime.Now,
                        Price = book.Price,
                        Status = OrderStatus.Pending
                    };

                    _orderRepository.CreateOrder(order);
                    TempData["msg"] = $"Hi {user.Email}, your order for " +
                        $"{book.Name} has been processed except a call from us.";
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        // GET: /<controller>/Admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Admin()
        {
            var orders = _orderRepository.GetAllOrders;
            return View(orders);
        }

        // POST: /<controller>/Admin
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GrantOrder(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                if (order.Status != OrderStatus.Success)
                    order.Status = OrderStatus.Success;

                _orderRepository.SaveOrder();
                return RedirectToAction("Admin");
            }
            
        }
    }
}

