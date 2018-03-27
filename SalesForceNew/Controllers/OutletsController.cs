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
    public class OutletsController : ApiController
    {
        public IEnumerable<OutletDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {

                return entities.OutletDetails().ToList();
            }

        }

        public HttpResponseMessage Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                var entity = entities.OutletDetails().FirstOrDefault(d => d.Id == Id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Outlet with id " + Id + " not found");
                }
            }
        }


        public HttpResponseMessage Post([FromBody] InsertOutlets addoutlet)
        {
            try
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    entities.CreateOutlet(addoutlet.Name, addoutlet.ContactNo, addoutlet.Barcode ,addoutlet.Longitude, addoutlet.Latitude, addoutlet.OwnerName, addoutlet.Email,addoutlet.Status, addoutlet.RouteId);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, addoutlet);
                   //  message.Headers.Location = new Uri(Request.RequestUri + Outlet.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return (Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }


        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    var entity = entities.Outlets.FirstOrDefault(d => d.Id == Id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The user with id " + Id.ToString() + "is not found");
                    }
                    else
                    {
                        entities.Outlets.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK + " The user with id " + Id + "is deleted");
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put([FromBody] InsertOutlets addoutlet)
        {
            try
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    var entity = entities.Outlets.FirstOrDefault(d => d.Id == addoutlet.Id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Outlet with " + addoutlet.Id.ToString() + " not found");
                    }
                    else
                    {
                        entities.UpdateOutlets(addoutlet.Id,addoutlet.Name, addoutlet.ContactNo, addoutlet.Longitude, addoutlet.Latitude, addoutlet.OwnerName, addoutlet.Email, addoutlet.Status, addoutlet.RouteId);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
