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

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
