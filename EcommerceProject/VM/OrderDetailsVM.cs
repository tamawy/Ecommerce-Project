using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EcommerceProject.Models;

namespace EcommerceProject.VM
{
    public class OrderDetailsVM : OrderDetails
    {
        [Required(ErrorMessage = "Error")]
        public long Price { get; set; }
        [Required]
        public long TotalPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}