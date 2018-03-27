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
    public class LeaveController : ApiController
    {
        public IEnumerable<LeaveDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.LeaveDetails().ToList();
            }
        }


        public IEnumerable<UsersLeaveDetails_Result> Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.UsersLeaveDetails(Id).ToList();
            }
        }

        public void Post([FromBody] InsertLeave addleave)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.AddLeave(addleave.StartingDate, addleave.EndingDate, addleave.Reason, addleave.UserId);
                entities.SaveChanges();
            }
        }

        public void Put([FromBody] string status, int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.UpdateLeave( Id, status);
                entities.SaveChanges();
            }
        }

    }
}
