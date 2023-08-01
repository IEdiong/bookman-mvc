namespace Bookman.Models
{
	public interface IOrderRepository
	{
        void CreateOrder(Order order);
        IEnumerable<Order> GetUserOrders(string userId);
        IEnumerable<Order> GetAllOrders { get; }
        Order? GetOrder(int orderId);
        void SaveOrder();
    }
}

