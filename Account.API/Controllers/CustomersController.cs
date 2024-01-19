using Account.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersDataStore _customersDataStore;
        public CustomersController(ICustomersDataStore customersDataStore)
        {
            _customersDataStore = customersDataStore;
        }


        [HttpGet()]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            return Ok(_customersDataStore.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(string id)
        {
            var customerToReturn = _customersDataStore.GetAllCustomers().FirstOrDefault(c => c.Id == id);

            if (customerToReturn == null)
            {
                return NotFound();
            }

            return Ok(customerToReturn);
        }
    }
}
