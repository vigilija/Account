using Account.FE.Controllers;
using Account.FE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Account.FE.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public IList<Customer> Customers { get; set; } = default;

        public async Task<PageResult> OnGet()
        {
            Customers = await CustomerController.OnGetAsync();
            return Page();
        }
    }
}
