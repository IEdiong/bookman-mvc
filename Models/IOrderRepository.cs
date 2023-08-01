using System;
namespace Bookman.Models
{
	public interface IOrderRepository
	{
        void CreateOrder(Order order);
        IEnumerable<Order> GetUserOrders(string userId);
    }
}

