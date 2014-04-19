using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entaria.Abstract;
using Entaria.Models;

namespace Entaria.Concrete
{
    public class EFAdminRepository : IAdminRepository
    {
        private EntariaContext context = new EntariaContext();
        public IQueryable<Admin> Admins
        {
            get { return context.Admins; }
        }

        public void SaveAdmin(Admin admin)
        {
            if (admin.AdminId == 0)
            {
                context.Admins.Add(admin);
            }
            else
            {
                Admin a = context.Admins.Find(admin.AdminId);
                if (a != null)
                {
                    a.Title = admin.Title;
                    a.FirstName = admin.FirstName;
                    a.LastName = admin.LastName;
                    a.UserName = admin.UserName;
                    a.Password = admin.Password;
                    a.LastLoginDate = admin.LastLoginDate;
                    a.FailedLoginCount = admin.FailedLoginCount;
                    a.LoginFailureContactNotification = admin.LoginFailureContactNotification;
                    a.CreationDateTime = admin.CreationDateTime;
                    a.ModificationDateTime = admin.ModificationDateTime;
                    a.LastModifiedByUserName = admin.LastModifiedByUserName;
                    a.CreatedByUserName = admin.CreatedByUserName;
                }
            }
            context.SaveChanges();
        } // end save method

        public Admin DeleteAdmin(int adminId)
        {
            Admin a = context.Admins.Find(adminId);

            if (a != null)
            {
                context.Admins.Remove(a);
                context.SaveChanges();
            }
            return a;
        } // end delete method



    }
}