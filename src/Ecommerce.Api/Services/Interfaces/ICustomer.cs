using Ecommerce.Models.Models;

namespace Services.Interfaces
{
    public interface ICustomer
    {
        Customer AddCustomer(Customer customer);
        Customer DeleteCustomer(string customerId);
    }
}
