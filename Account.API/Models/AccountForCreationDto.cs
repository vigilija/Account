using System.ComponentModel.DataAnnotations;

namespace Account.API.Models
{
    public class AccountForCreationDto
    {
        [Required(ErrorMessage = "You should provide a Balance value.")]
        public decimal Balance { get; set; }
    }
}
