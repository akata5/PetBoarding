using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.Models
{
    public class PetOwnerModel
    {
        [Key]
        public Guid PetOwnerID { get; set; } = Guid.NewGuid(); // PK
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        public string EmergencyContactPhone { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }

        // parent of PetModel
        public virtual List<PetModel> Pets { get; set; }

        // parent of ContactSubmissionModel
        public virtual List<ContactUsSubmissionModel> ContactSubmissions { get; set; }
        public PetOwnerModel()
        {
            PetOwnerID = Guid.NewGuid();
            Pets = new List<PetModel>();
            ContactSubmissions = new List<ContactUsSubmissionModel>();
        }
    }
}