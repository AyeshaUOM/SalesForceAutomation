using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;

namespace SalesForceNew.Controllers
{
    public class VanProductsController : ApiController
    {
        public List<VanProductDetails_Result> Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.VanProductDetails(Id).ToList();
            }
        }
    }
}
