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
        //public IActionResult Index()
        //{
        //    var env = Environment.GetEnvironmentVariable("END_POINT_URL");
        //    Console.WriteLine(env);
        //    return View();
        //}
        public static async Task<List<Models.AccountForShow>> OnGetAsync(string? customerId, Models.AccountForShow accountData)
        {
            var path = Environment.GetEnvironmentVariable("END_POINT_URL");

            List<Models.AccountForShow> accounts = new List<Models.AccountForShow>();

            using (var httpClient = new HttpClient())
            {
                var accountObjectForCreation = new AccountForCreation() { Balance = accountData.Balance };

                var accountContent = JsonContent.Create(accountObjectForCreation);

                using HttpResponseMessage response = 
                    await httpClient.PostAsync($"{path}/customers/{customerId}/account", accountContent);
                                                 
                string apiResponse = await response.Content.ReadAsStringAsync();

                accounts = JsonNet.Deserialize<List<AccountForShow>>(apiResponse);
            }
            return accounts;
        }
    }
}
