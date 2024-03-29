﻿using System.ComponentModel.DataAnnotations;

namespace Account.FE.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public double Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CreatedDate { get; set; }
    }
}
