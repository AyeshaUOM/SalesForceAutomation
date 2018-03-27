using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;

namespace SalesForceNew.Controllers
{
    public class OutstandingController : ApiController
    {
        public List<OutstandingDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                List<OutletDetails_Result> l = new List<OutletDetails_Result>();
                l = entities.OutletDetails().ToList();
                int count = l.Count();
                int x=0;
                List<OutstandingDetails_Result> list = new List<OutstandingDetails_Result>();
               try
                {
                    while (x < count)
                    {
                        OutstandingDetails_Result result1 = new OutstandingDetails_Result();
                       
                        result1 = entities.OutstandingDetails(l[x].Id).Last();
                        list.Add(result1);
                       
                        x++;
                    }
                }

                catch(Exception e)
                {

                }
                return list;
            }
        
        }
       
    }
}
