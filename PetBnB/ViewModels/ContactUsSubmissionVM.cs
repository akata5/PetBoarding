using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.ViewModels
{
    public class ContactUsSubmissionVM
    {
        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}