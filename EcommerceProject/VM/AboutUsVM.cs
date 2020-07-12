using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceProject.VM
{
    public class AboutUsVM : EcommerceProject.Models.AboutUs
    {
        [Required(ErrorMessage ="*")]
        [Display(Name = "Our vision")]
        public string Vision { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Our Mission")]
        public string Mission { get; set; }

        [Required(ErrorMessage ="*")]
        [Display(Name = "Who we are?")]
        public string WhoAreWe { get; set; }

    }
}