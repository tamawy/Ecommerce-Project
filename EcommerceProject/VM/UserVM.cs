using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceProject.VM
{
    public class UserVM : EcommerceProject.Models.User
    {
        [Required  (ErrorMessage = "*")]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }
    }
}