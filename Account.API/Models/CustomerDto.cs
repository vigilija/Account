using System.ComponentModel.DataAnnotations;

namespace Account.API.Models
{
    public class CustomerDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "You should provide a Name value.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should provide a Surname value.")]
        public string Surname { get; set; }
        public ICollection<AccountDto> Accounts { get; set; } = new List<AccountDto>();
    }
}
