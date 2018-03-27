using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForceNew.Class
{
    public class SalesSummary1
    {
        
        public Nullable<double> Amount { get; set; }
        public int month { get; set; }
        public int year { get; set; }

        public SalesSummary1( Nullable<double> Amount, int month, int year)
        {
            
            this.Amount = Amount;
            this.month = month;
            this.year = year;
        }


    }
}