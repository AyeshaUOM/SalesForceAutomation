using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertLeave
    {
       
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public string Reason { get; set; }
       
        public Nullable<int> UserId { get; set; }
    }
}