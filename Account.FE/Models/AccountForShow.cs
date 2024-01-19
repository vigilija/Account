using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Account.FE.Models
{
    public class AccountForShow
    {
        public string? Id { get; set; }

      //  [DisplayFormat]
        public double Balance { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? CreatedDate { get; set; }

        public  ICollection<Transaction> Transactions { get; set; } =  new List<Transaction>();
    }
}
