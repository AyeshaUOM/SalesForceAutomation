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
    public class OrderController : ApiController

    

    {
        public void Post([FromBody]InsertOrder addorder)
        {


            using (SalesForceEntities entities = new SalesForceEntities())

            {
                entities.CreateOrder(addorder.Date, addorder.UserId, addorder.OutletId, addorder.DeliveryDate,addorder.Remarks,addorder.Longitude,addorder.Longitude);
                entities.SaveChanges();
               


            }



            using (SalesForceEntities entities = new SalesForceEntities())

            {

                ObjectResult<Nullable<int>> id = entities.GetOrderId(addorder.Date, addorder.UserId, addorder.OutletId);
                var item = id.First();
                int i = Convert.ToInt32(item);
                //entities.CreatePayment(i, addorder.PaymentType, addorder.Amount);
                //entities.SaveChanges();



                for (int x = 0; x < addorder.abc.Count; x++)
                {

                    entities.CreateVanOrderProducts(i, addorder.abc[x].ProductId, addorder.abc[x].ProductQuantity);
                    entities.SaveChanges();
                    //entities.UpdateProductAfterOrder(addorder.abc[x].ProductQuantity, addorder.abc[x].ProductId);
                    //entities.SaveChanges();

                }



            }



        }

    }
}


