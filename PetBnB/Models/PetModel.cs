using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace PetBnB.Models
{
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; } = Guid.NewGuid();// PK
        public Guid PetOwnerID { get; set; } // FK

        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public int FeedingFrequency { get; set; }
        public string FeedingAmount { get; set; }
        public string MedicalNotes { get; set; }
        public string SpecialInstructions { get; set; }

        // parent of BookingModel
        public virtual List<BookingModel> Bookings { get; set; }

        // child of PetOwnerModel
        [Required]
        public virtual PetOwnerModel PetOwner { get; set; }
       
        public PetModel()
        {
            PetID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
        }
    }
}