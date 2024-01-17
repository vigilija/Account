using Account.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [Route("api/customers/{customerId}/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("{accountId}", Name = "GetAccount")]
        public ActionResult<AccountDto> GetAccount(string customerId, string accountId)
        {
            var customer = CustomersDataStore.Instance.Customers
                .FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            // find account for customer
            var account = customer.Accounts
                .FirstOrDefault(c => c.Id == accountId);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
        [HttpPost]
        public ActionResult<AccountDto> CreateAccount( string customerId, AccountForCreationDto account)
        {
            var customer = CustomersDataStore.Instance.Customers
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound();
            }

            var newAccount = new AccountDto()
            {
                Id = Guid.NewGuid().ToString(),
                Balance = account.Balance,
                CreatedDate = DateTime.UtcNow,
            };

            customer.Accounts.Add(newAccount);

            return CreatedAtRoute("GetAccount",
                 new
                 {
                     customerId = customerId,
                     accountId = newAccount.Id
                 },
                 newAccount);
        }

    }
}
