//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactUs
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public string facebook { get; set; }
        public string phone { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
