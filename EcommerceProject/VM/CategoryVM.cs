using EcommerceProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceProject.VM
{
    public class CategroyVM : Category
    {
        [Required]
        public string Name { get; set; }
    }
}