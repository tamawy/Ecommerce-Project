using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceProject.VM
{
    public class ContactUsVM : EcommerceProject.Models.ContactUs
    {
        [Required(ErrorMessage ="*")]
        [Display(Name = "Compony Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Compony Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Compony Facebook Account")]
        public string facebook { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Compony Phone Number")]
        public string phone { get; set; }
    }
}