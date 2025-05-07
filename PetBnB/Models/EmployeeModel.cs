using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBnB.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeID { get; set; } = Guid.NewGuid();// PK

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        //parent of BookingModel
        public virtual List<BookingModel> Bookings { get; set; }

        // parent of BookingStatusLogs
        public virtual List<BookingStatusLogModel> BookingStatusLogs { get; set; }
        public EmployeeModel()
        {
            EmployeeID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
            BookingStatusLogs = new List<BookingStatusLogModel>();
        }
    }
}