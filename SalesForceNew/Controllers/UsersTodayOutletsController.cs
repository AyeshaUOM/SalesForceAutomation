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
    public class UsersTodayOutletsController : ApiController
    {

        public IEnumerable<UsersTodayOutelts_Result> Get(int id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {

                return entities.UsersTodayOutelts(id).ToList();
            }

        }


    }
}
