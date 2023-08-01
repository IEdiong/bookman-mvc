using System;
using Bookman.Data;

namespace Bookman.Models
{
	public class OrderRepository : IOrderRepository
	{
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
	}
}

