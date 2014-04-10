using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Entaria.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
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