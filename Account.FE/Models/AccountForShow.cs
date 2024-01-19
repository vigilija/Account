using System.Text.Json.Serialization;

namespace Account.FE.Models
{
    public class AccountForShow
    {
        public string? Id { get; set; }

        public decimal Balance { get; set; }

        public DateTime? CreatedDate { get; set; }

        public  ICollection<Transaction> Transactions { get; set; } =  new List<Transaction>();
    }
}
