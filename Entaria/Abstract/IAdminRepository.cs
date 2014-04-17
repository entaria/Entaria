using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entaria.Models;

namespace Entaria.Abstract
{
    interface IAdminRepository
    {
        IQueryable<Admin> Admins { get; }
    }
}
