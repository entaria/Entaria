using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entaria.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ClientId { get; set; }
        public int LocationId { get; set; }
        public int ReaderId { get; set; }
        public int CardId { get; set; }
        public string ReceiptNumber { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}