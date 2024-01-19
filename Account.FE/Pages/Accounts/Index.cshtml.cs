using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Account.FE.Models;
using Account.FE.Controllers;


namespace Account.FE.Pages.Accounts
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public string CustomerId;

        public IActionResult OnGet(string id)
        {
            CustomerId = id;
            return Page();
        }

        public AccountForShow Account { get; set; }

        public string Id { get; set; }

        public async Task<IActionResult> OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Error");
            }

            var a = await AccountController.OnGetAsync(Id, Account);

            return RedirectToPage("/Customers/Index");
        }
    }
}
