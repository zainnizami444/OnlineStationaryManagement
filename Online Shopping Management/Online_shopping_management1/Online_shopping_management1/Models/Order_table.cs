//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_shopping_management1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_table
    {
        public int oid { get; set; }
        public Nullable<int> Empid { get; set; }
        public Nullable<int> Stationary_id { get; set; }
        public Nullable<int> Statid { get; set; }
        public Nullable<System.DateTime> Date_Of_Order { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Emp Emp { get; set; }
        public virtual Stationary Stationary { get; set; }
        public virtual Stat Stat { get; set; }
    }
}
