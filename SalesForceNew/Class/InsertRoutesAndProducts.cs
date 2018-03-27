using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertRoutesAndProducts
    {
       
        public DateTime Date1 { get; set; }
        public Nullable<int> UserId { get; set; }

        public Nullable<int> RouteId { get; set; }
        public Nullable<int> VanId { get; set; }
        public List<InsertProductsToVan> l1 { get; set; }
       
    }
}

