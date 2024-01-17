using Account.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<IEnumerable<CustomerDto>> GetCities()
        {
            return Ok(CustomersDataStore.Instance.Customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCity(string id)
        {
            var customerToReturn = CustomersDataStore.Instance.Customers.FirstOrDefault(c => c.Id == id);

            if (customerToReturn == null)
            {
                return NotFound();
            }

            return Ok(customerToReturn);
        }
    }
}
