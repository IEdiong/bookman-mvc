using Bookman.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookman.Models
{
	public class OrderRepository : IOrderRepository
	{
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetUserOrders(string userId)
        {
            return _context.Orders.Where(order => order.UserId == userId).Include(order => order.Book).ToList();
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
	}
}

