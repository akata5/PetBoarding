using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.Models
{
    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; } = Guid.NewGuid();// PK
        public Guid PetID { get; set; } // FK
        public Guid? CheckInEmployeeID { get; set; } // FK (nullable)
        public Guid? CheckOutEmployeeID { get; set; } // FK (nullable)
        public DateTime? CreatedDateTime { get; set; }

        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; } // nullable
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        // parent of BookingStatusLogModel
        public virtual List<BookingStatusLogModel> BookingStatusLogs { get; set; }
        // child of EmployeeModel

        public virtual EmployeeModel Employee { get; set; }

        // child of PetModel
        [Required]
        public virtual PetModel Pet { get; set; }
        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            CreatedDateTime = DateTime.UtcNow;
            BookingStatusLogs = new List<BookingStatusLogModel>();
        }
    }
}