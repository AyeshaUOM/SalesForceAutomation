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
    public class RouteController : ApiController
    {
        public IEnumerable<RouteDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.RouteDetails().ToList();
            }
        }

        public RouteDetails_Result Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.RouteDetails().FirstOrDefault(d => d.Id == Id); ;
            }
        }

        public void Post([FromBody] InsertRoute addroute)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.CreateRoute(addroute.Name, addroute.Description);
                entities.SaveChanges();
            }
        }



        public void Put([FromBody] InsertRoute addroute)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.UpdateRoute(addroute.Id, addroute.Name, addroute.Description);
                entities.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.DeleteRoute(Id);
                entities.SaveChanges();
            }
        }
    }
}
