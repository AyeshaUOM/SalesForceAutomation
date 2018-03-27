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
    public class VanController : ApiController
    {
        
        
            public IEnumerable<VanDetails_Result> Get()
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    return entities.VanDetails().ToList();
                }
            }

            public VanDetails_Result Get(int Id)
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    return entities.VanDetails().FirstOrDefault(d => d.Id == Id); ;
                }
            }

            public void Post([FromBody] InsertVan addvan)
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    entities.CreateVan(addvan.VanType, addvan.RegistrationNo);
                    entities.SaveChanges();
                }
            }



            public void Put([FromBody] InsertVan addvan)
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    entities.UpdateVan(addvan.Id, addvan.VanType, addvan.RegistrationNo);
                    entities.SaveChanges();
                }
            }
        public void Delete(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.DeleteVan(Id);
                entities.SaveChanges();
            }
        }

    }

    
}
    

