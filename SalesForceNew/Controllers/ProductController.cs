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
   // [BasicAuthentication]
    public class ProductController : ApiController
    {
        public IEnumerable<ProductDetails_Result> Get()
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.ProductDetails().ToList();
            }
        }

        public ProductDetails_Result Get(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                return entities.ProductDetails().FirstOrDefault(d => d.Id == Id);
            }
        }

        public void Post([FromBody] InsertProduct2 adddproduct)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.CreateProduct( adddproduct.Name, adddproduct.Brand, adddproduct.Category, adddproduct.ManufacturePrice, adddproduct.RetailPrice, adddproduct.Quantity, adddproduct.DiscountType);
                entities.SaveChanges();
                List<ProductDetails_Result> l2 = entities.ProductDetails().ToList();
                int a = l2.Count;
                List<VanDetails_Result> l1 = entities.VanDetails().ToList();
                int x = l1.Count;
                int y = 0;
                while(y<x)
                {
                    entities.createProductsToVan(l1[y].Id, l2[a - 1].Id, 0);
                    y++;
                }
                
            }
        }

        

        public void Put([FromBody] InsertProduct adddproduct)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.UpdateProduct(adddproduct.Id , adddproduct.Name, adddproduct.Brand, adddproduct.Category, adddproduct.ManufacturePrice, adddproduct.RetailPrice, adddproduct.Quantity, adddproduct.DiscountType);
                entities.SaveChanges();
            }
        }


        public void Delete(int Id)
        {
            using (SalesForceEntities entities = new SalesForceEntities())
            {
                entities.DeleteProduct(Id);
                entities.SaveChanges();
            }
        }
    }
}
