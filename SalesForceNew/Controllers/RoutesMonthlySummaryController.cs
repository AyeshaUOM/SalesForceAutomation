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
    public class RoutesMonthlySummaryController : ApiController
    {
        public List<SalesSummary1> Get(int id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                List<SalesSummary1> summary = new List<SalesSummary1>();

                List<RoutesSalesSummary_Result> l1 = new List<RoutesSalesSummary_Result>();

                int count = 0;

                string k = DateTime.Now.Month.ToString();
                int x = Convert.ToInt32(k);

                string l = DateTime.Now.Year.ToString();
                int y = Convert.ToInt32(l);

                while (count < 12)

                {



                    try
                    {
                        l1 = (entities.RoutesSalesSummary(id, x, y).ToList());
                        int c = l1.Count();
                        int d = 0;
                        Nullable<double> amount = 0;
                        while (d < c)
                        {
                            amount = amount + l1[d].Amount;
                            d++;
                        }
                        SalesSummary1 sum = new SalesSummary1(amount, x, y);

                        summary.Add(sum);
                    }
                    catch (Exception e)
                    {

                    }

                    if (x > 1)
                    {
                        x--;
                    }
                    else
                    {
                        x = 12;
                        y--;

                    }



                    count++;

                }

                return summary;
            }



        }
    }
}
