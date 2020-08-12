using System.ComponentModel.DataAnnotations;


namespace EcommerceProject.VM
{
    public class BrandVM : EcommerceProject.Models.Brand
    {
        [Required]
        public string Name { get; set; }
    }
}