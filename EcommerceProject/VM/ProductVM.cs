using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceProject.VM
{
    public class ProductVM : EcommerceProject.Models.Product
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Product price")]
        public long Price { get; set; }

        [Required(ErrorMessage = "*")]
        public string Decription { get; set; }

        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }


    }
}