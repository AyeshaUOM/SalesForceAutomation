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
    public class RoutesOutletsController : ApiController
    {

        public void Post(InsertRoutesAndProducts add)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                var x = entities.AddOutletsOfRoutes(add.RouteId).ToArray();
                int y = x.Count();
                var date = add.Date1.Date;
                for ( int i=0; i<y; i++)
                {
                    entities.CreateRouteHasOutlets(date, add.UserId, x[i], add.VanId);
                }
                int c = add.l1.Count();
                for(int J=0; J<c; J++)
                {
                    entities.AddVanProducts(add.VanId, add.l1[J].Id, add.l1[J].Quantity);
                }
            }
        }
    }
}
