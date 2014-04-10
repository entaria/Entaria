using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entaria.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int LoyaltyCardHolderId { get; set; }
        public string Number { get; set; }
    }
}