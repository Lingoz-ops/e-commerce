using Ecommerce.Models;
using Ecommerce.Models.Models;
using Services.Interfaces;

namespace Services.Repositories
{
    public class OrderRepo : IOrder
    {
        private EcommerceDBContext _dbContext;

        public OrderRepo(EcommerceDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Order CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }
        public Order UpdateOrderById(string orderId, Order updatedOrder)
        {
            // Retrieve the order from the database based on orderId
            var existingOrder = _dbContext.Orders.Find(orderId);

            // If the order exists, update its properties with the new values
            if (existingOrder != null)
            {
                //existingOrder.CustomerId = updatedOrder.CustomerId;
                existingOrder.Paid = updatedOrder.Paid;
                existingOrder.Total = updatedOrder.Total;

                _dbContext.Orders.Update(existingOrder);
                _dbContext.SaveChanges();
            }

            return existingOrder;
        }
        public Order GetOrderById(string orderId)
        {
            var orderInDb = _dbContext.Orders.Find(orderId);
            return orderInDb;
        }

    }
}
