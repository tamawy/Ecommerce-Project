using EcommerceProject.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.VM
{
    public class CategroyVM : Category
    {
        [Required]
        public string Name { get; set; }
    }
}