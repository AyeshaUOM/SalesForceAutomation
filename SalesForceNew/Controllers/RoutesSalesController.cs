using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;

namespace SalesForceNew.Controllers
{
    public class RoutesSalesController : ApiController
    {
        public IEnumerable<RoutesSalesSummary_Result> Get(Nullable<int> userId, Nullable<int> month, Nullable<int> year)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.RoutesSalesSummary(userId, month, year).ToList();



            }
        }
    }
}
