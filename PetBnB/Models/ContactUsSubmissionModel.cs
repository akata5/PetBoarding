using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.Models
{
    public class ContactUsSubmissionModel
    {
        [Key]
        public Guid ContactSubmissionID { get; set; } = Guid.NewGuid();// PK
        public Guid? PetOwnerID { get; set; } // FK

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime TimeSubmitted { get; set; }

        // child of PetOwnerModel
        public virtual PetOwnerModel PetOwner { get; set; }
        public ContactUsSubmissionModel()
        {
            ContactSubmissionID = Guid.NewGuid();
        }
    }
}