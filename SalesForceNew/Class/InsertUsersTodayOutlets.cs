using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertUsersTodayOutlets
    {

        public string Name { get; set; }
        public string ContactNo { get; set; }
        
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public Nullable<int> RouteId { get; set; }
    }
}