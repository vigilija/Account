namespace Account.API.Models
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
