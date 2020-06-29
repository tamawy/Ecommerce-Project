using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceProject.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.VM
{
    public class ContactMessageVM : ContactMesaage
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Message { get; set; }

        [Required(ErrorMessage = "*")]
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime CreationDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}