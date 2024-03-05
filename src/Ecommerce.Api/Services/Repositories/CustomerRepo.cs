using Ecommerce.Models;
using Ecommerce.Models.Models;
using Services.Interfaces;

namespace Ecommerce.Services.Repositories
{
    public class CustomerRepo : ICustomer
    {
        private EcommerceDBContext _dbContext;

        public CustomerRepo(EcommerceDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(string customerId)
        {
            // Retrieve the customer from the database
            var customer = _dbContext.Customers.Find(customerId);

            // If the customer exists, remove it from the DbSet
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
            return customer;

        }
    }
}
