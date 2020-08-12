using System.ComponentModel.DataAnnotations;

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