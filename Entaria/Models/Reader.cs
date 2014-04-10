using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entaria.Models
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public int LocationId { get; set; }
        public string HardwareIdentifier { get; set; }
        public string AttachedToNote { get; set; }
    }
}