using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Entaria.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public int ClientId { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string GeoCode { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string CreatedByUserName { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}