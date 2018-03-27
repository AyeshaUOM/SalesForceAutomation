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
    
    public partial class Outlet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Outlet()
        {
            this.Orders = new HashSet<Order>();
            this.Outstandings = new HashSet<Outstanding>();
            this.RouteHasOutlets = new HashSet<RouteHasOutlet>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Barcode { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Nullable<int> RouteId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outstanding> Outstandings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteHasOutlet> RouteHasOutlets { get; set; }
    }
}