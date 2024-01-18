using Account.FE.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;


namespace Account.FE.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static async Task<List<Customer>> OnGetAsync()
        {
            List<Customer> customers = new List<Customer>();

            using (var httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7271/api/customers");

                string apiResponse = await response.Content.ReadAsStringAsync();

                customers = JsonNet.Deserialize<List<Customer>>(apiResponse);
            }
            return customers;//new JsonResult(customers);
        }
    }
}
