using Ecommerce.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer customer)
        {
            var result = _customer.AddCustomer(customer);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult<Customer> DeleteCustomer(string customerId)
        {
            var result = _customer.DeleteCustomer(customerId);
            return Ok(result);

        }
    }
}
