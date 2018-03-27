using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;

namespace SalesForceNew.Controllers
{
    public class UsersVanProductsController : ApiController
    {
        public IEnumerable<UsersVanProductDetails_Result> Get(int UserId)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                Nullable<int> x = entities.UsersOutlets(UserId).First();

                return entities.UsersVanProductDetails(UserId, x).ToList();
            }
        }
    }
}
