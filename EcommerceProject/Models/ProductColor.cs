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
    
    public partial class ProductColor
    {
        public long ID { get; set; }
        public string Image { get; set; }
        public long ProductFK { get; set; }
        public long ColorFk { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
