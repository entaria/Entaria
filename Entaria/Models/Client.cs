using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Entaria.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string MainContactTitle { get; set; }
        public string MainContactName { get; set; }
        public string PrimaryStreet { get; set; }
        public string PrimaryTown { get; set; }
        public string PrimaryCity { get; set; }
        public string PrimaryCounty { get; set; }
        public string PrimaryCountry { get; set; }
        public string PrimaryGeoCode { get; set; }
        public string Website { get; set; }
        public string PrimaryPhone { get; set; }
        public string VatNumber { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int FailedLoginCount { get; set; }
        public string LoginFailureContactNotification { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string LastModifiedByUserName { get; set; }
        public string CreatedByUserName { get; set; }
    }
}