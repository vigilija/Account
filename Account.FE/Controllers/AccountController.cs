using Account.FE.Models;
using Json.Net;
using Microsoft.AspNetCore.Mvc;

namespace Account.FE.Controllers
{
    public class AccountController : Controller
    {
        public static async Task<List<AccountForShow>> OnGetAsync(string? customerId, AccountForShow accountData)
        {
            var path = Environment.GetEnvironmentVariable("END_POINT_URL");
            List<AccountForShow> accounts = new();

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
