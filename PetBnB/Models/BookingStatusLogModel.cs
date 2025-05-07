using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.Models
{
    public class BookingStatusLogModel
    {
        [Key]
        public Guid LogID { get; set; } = Guid.NewGuid();// PK
        public Guid BookingID { get; set; } // FK
        public Guid EmployeeID { get; set; } // FK 

        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime TimeModified { get; set; }
        public PetModel Pet { get; set; }

        // child of BookingModel
        [Required]
        public virtual BookingModel Booking { get; set; }

        // child of EmployeeModel
        [Required]
        public virtual EmployeeModel Employee { get; set; }

        public BookingStatusLogModel()
        {
            BookingID = Guid.NewGuid();
        }
    }
}