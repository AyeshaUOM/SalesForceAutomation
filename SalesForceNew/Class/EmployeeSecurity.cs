using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesForceNew.Models;

namespace SalesForceNew.Class
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.Users.Any(User => User.Username.Equals(username,
                    StringComparison.OrdinalIgnoreCase) && User.Passwords == password);
            }
        }
    }
}