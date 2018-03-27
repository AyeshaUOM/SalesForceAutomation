using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;
using SalesForceNew.Class;

namespace SalesForceNew.Controllers
{
    public class UsersSalesController : ApiController
    {
        public IEnumerable<UsersSalesSummary_Result> Get(Nullable<int> userId, Nullable<int> month, Nullable<int> year)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.UsersSalesSummary(userId, month, year).ToList();
                


            }
        }
    }
}
