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

        //create new account for given customerId and balance
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

            //if initialCredit is > 0 new Transaction is created 
            if (newAccount.Balance > 0)
            {
                newAccount.Transactions.Add(new TransactionDto() 
                {
                    Id = Guid.NewGuid().ToString(),
                    Amount = newAccount.Balance,
                    CreatedDate = DateTime.UtcNow
                });
            }

            //show created account
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
