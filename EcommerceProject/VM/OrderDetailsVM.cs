using System.ComponentModel.DataAnnotations;
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