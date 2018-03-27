using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class InsertExpenses
    {
        
        public string Date { get; set; }
        public string Description { get; set; }
        public Nullable<double> Amount { get; set; }
       
        public Nullable<int> UserId { get; set; }
    }
}