using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertProduct2
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public Nullable<double> ManufacturePrice { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> DiscountType { get; set; }
    }
}