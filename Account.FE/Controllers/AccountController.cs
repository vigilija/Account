using Account.FE.Models;
using Json.Net;

//using Json.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Account.FE.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public static async Task<List<Models.AccountForShow>> OnGetAsync(string? customerId, Models.AccountForShow accountData)
        {
            List<Models.AccountForShow> accounts = new List<Models.AccountForShow>();

            using (var httpClient = new HttpClient())
            {
                var accountObjectForCreation = new AccountForCreation() { Balance = accountData.Balance };

                var accountContent = JsonContent.Create(accountObjectForCreation);

                using HttpResponseMessage response = 
                    await httpClient.PostAsync($"https://localhost:7271/api/customers/{customerId}/account", accountContent);
                                                 
                string apiResponse = await response.Content.ReadAsStringAsync();

                accounts = JsonNet.Deserialize<List<AccountForShow>>(apiResponse);
            }
            return accounts;
        }
    }
}
