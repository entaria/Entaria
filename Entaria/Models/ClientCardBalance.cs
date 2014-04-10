using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entaria.Models
{
    public class ClientCardBalance
    {
        public int ClientCardBalanceId { get; set; }
        public int CardId { get; set; }
        public int ClientId { get; set; }
        public int PointsBalance { get; set; }
    }
}