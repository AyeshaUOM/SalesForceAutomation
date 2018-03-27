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
    public class UsersController : ApiController
    {
        public IEnumerable<UserDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {

                return entities.UserDetails().ToList();
            }

        }

        public HttpResponseMessage Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                var entity = entities.UserDetails().FirstOrDefault(d => d.Id == Id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User with id " + Id + " not found");
                }
            }
        }


        public HttpResponseMessage Post([FromBody] InsertUser addusers)
        {
            try
            {
                using (SalesForceEntities entities = new SalesForceEntities())
                {
                    entities.CreateUser(addusers.NIC, addusers.Username, addusers.Passwords, addusers.FirstName, addusers.LastName, addusers.ResidenceNo, addusers.Lane, addusers.City, addusers.ContactNo, addusers.Email, addusers.Gender, addusers.UserType);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, addusers);
                    // message.Headers.Location = new Uri(Request.RequestUri + InsertUser.Id.ToString());
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
                    var entity = entities.Users.FirstOrDefault(d => d.Id == Id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The user with id " + Id.ToString() + "is not found");
                    }
                    else
                    {
                        entities.Users.Remove(entity);
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

        //public HttpResponseMessage Put(int Id, [FromBody] User user)
        //{
        //    try
        //    {
        //        using (SalesForceEntities entities = new SalesForceEntities())
        //        {
        //            var entity = entities.Users.FirstOrDefault(d => d.Id == Id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with " + Id.ToString() + " not found");
        //            }
        //            else
        //            {
        //                entity.FirstName = user.FirstName;
        //                entity.City = user.City;
        //                entity.ContactNo = user.ContactNo;
        //                entity.Email = user.Email;
        //                entity.Gender = user.Gender;
        //                entity.Lane = user.Lane;
        //                entity.LastName = user.LastName;
        //                entity.NIC = user.NIC;
        //                entity.Passwords = user.Passwords;
        //                entity.ResidenceNo = user.ResidenceNo;
        //                entity.Username = user.Username;
        //                entity.UserType = user.UserType;

        //                entities.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }


        public void Put([FromBody] InsertUser adduser)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.UpdateUser(adduser.Id,adduser.NIC, adduser.Username, adduser.Passwords, adduser.FirstName, adduser.LastName, adduser.ResidenceNo, adduser.Lane, adduser.City, adduser.ContactNo, adduser.Email, adduser.UserType, adduser.Gender );
                entities.SaveChanges();
               
            }
        }

    }
}
