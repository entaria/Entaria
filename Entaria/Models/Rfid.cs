using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entaria.Models
{
    public class Rfid
    {
        public int RfidId { get; set; }
        public int LoyaltyCardHolderId { get; set; }
        public string Number { get; set; }
    }
}