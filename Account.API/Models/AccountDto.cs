namespace Account.API.Models
{
    public class AccountDto
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public IList<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
    }
}
