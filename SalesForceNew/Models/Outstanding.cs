//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesForceNew.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Outstanding
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public Nullable<int> OutletId { get; set; }
        public Nullable<double> Amount { get; set; }
    
        public virtual Outlet Outlet { get; set; }
    }
}
