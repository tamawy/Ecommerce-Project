using EcommerceProject.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.VM
{
    public class UserAddressVM : UserAddress
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string phone { get; set; }
    }
}