using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entaria.Models;

namespace Entaria.Abstract
{
    public interface IAdminRepository
    {
        IQueryable<Admin> Admins { get; }

        void SaveAdmin(Admin admin);
        Admin DeleteAdmin(int adminId);
    }
}
