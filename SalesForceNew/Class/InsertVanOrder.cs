using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertVanOrder
    {
        
        public string Date { get; set; }
        public string Remarks { get; set; }
        
        public Nullable<int> UserId { get; set; }
        public Nullable<int> OutletId { get; set; }
       // public string DeliveryDate { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string PaymentType { get; set; }
        public Nullable<double> Amount { get; set; }
        public List<InsertOrderProducts> abc { get; set; }
        
    }
}