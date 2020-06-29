using EcommerceProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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