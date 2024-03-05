using Ecommerce.Models.Models;

namespace Services.Interfaces
{
    public interface IOrder
    {
        Order CreateOrder(Order Order);
        Order UpdateOrderById(string OrderId, Order order);
        Order GetOrderById(string OrderId);
        // Order GetOrders(OrderProduct? ProductIds, string? CustomerId);
    }
}
