using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;

namespace SalesForceNew.Controllers
{
    public class LatestOutstandingDetailsController : ApiController
    {
        public Nullable<double> Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                try
                {
                    var x = entities.LatestOutstanding(Id).ToArray();
                    Nullable<double> y = x.Last();


                    return y;
                }
                catch(Exception e)
                {
                    return 0.0;
                }
            //    if (entities.LatestOutstanding(Id) == null)
            //    {
            //        Nullable<double> a = 0.0;
            //        return a;
            //    }
            //    else
            //    {
            //        var x = entities.LatestOutstanding(Id).ToArray();
            //        Nullable<double> y = x.Last();


            //        return y;
            //    }
            }
        }
    }
}
