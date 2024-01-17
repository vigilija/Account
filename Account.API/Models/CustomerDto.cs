namespace Account.API.Models
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<AccountDto> Accounts { get; set; } = new List<AccountDto>();
    }
}
