using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entaria.Models;

namespace Entaria.Concrete
{
    public class EntariaContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        // add other tables here later
    }
}