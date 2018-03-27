using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceNew.Models;
using SalesForceNew.Class;
using System.Data.Entity.Core.Objects;



namespace SalesForceNew.Controllers
{
    public class VanOrderController : ApiController



    {
        public void Post([FromBody]InsertVanOrder addorder)
        {


            using (SalesForceEntities entities = new SalesForceEntities())

            {
                entities.CreateVanOrder(addorder.Date, addorder.UserId, addorder.OutletId ,addorder.Remarks, addorder.Longitude, addorder.Longitude);
                entities.SaveChanges();



            }



            using (SalesForceEntities entities = new SalesForceEntities())

            {

                ObjectResult<Nullable<int>> id = entities.GetOrderId(addorder.Date, addorder.UserId, addorder.OutletId);
                var item = id.First();
                int i = Convert.ToInt32(item);
                entities.CreatePayment(i, addorder.PaymentType, addorder.Amount);
                entities.SaveChanges();

                ObjectResult<Nullable<int>> a = entities.GetVanId(addorder.UserId);
                var b = a.First();
                int j = Convert.ToInt32(b);

                Nullable<double> TotalCost = 0.0;

                for (int x = 0; x < addorder.abc.Count; x++)
                {

                    entities.CreateVanOrderProducts2(i, addorder.abc[x].ProductId, addorder.abc[x].ProductQuantity,addorder.abc[x].OrderType);
                    entities.SaveChanges();

                    Nullable<double> costperunit = entities.GetProductPrice(addorder.abc[x].ProductId).First();
                    Nullable<double> cost = costperunit * addorder.abc[x].ProductQuantity;
                    TotalCost = TotalCost + cost;
                        

                    entities.UpdateProductAfterOrder(addorder.abc[x].ProductQuantity, addorder.abc[x].ProductId);
                    entities.SaveChanges();

                    entities.UpdateVanProductAfterOrder(addorder.abc[x].ProductQuantity, addorder.abc[x].ProductId, j);

                }
                var p = entities.LatestOutstanding(addorder.OutletId).ToArray();
                double y =(double) p.Last();


                double Outstanding = (double)(TotalCost + y - addorder.Amount);

                entities.CreateOutstanding(addorder.Date, addorder.OutletId, Outstanding);
                entities.SaveChanges();

            }



        }

    }
}


