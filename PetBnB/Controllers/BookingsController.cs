using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBnB.Models;

namespace PetBnB.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Guid petId, DateTime startTime, DateTime endTime, string status, string Notes)
        {
            // connect to database
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                //validate pet exists
                PetModel pet = dbContext.PetModels.Find(petId);
                if (pet == null)
                {
                    return Content("Can't create booking, pet does not exist");
                }
                if (startTime >= endTime)
                {
                    return Content("Can't create booking, startTime must be before endTime");
                }
                // create object
                BookingModel bookingModel = new BookingModel();
                bookingModel.PetID = petId;
                bookingModel.StartTime = startTime;
                bookingModel.EndTime = endTime;
                bookingModel.Status = status;
                bookingModel.Notes = Notes;

                // add to dbcontext
                dbContext.Bookings.Add(bookingModel);

                // finalize/save the model
                try
                {
                    dbContext.SaveChanges();
                    return Content("Added booking");
                }
                catch (Exception ex)
                {
                    return Content("Error creating booking");
                }
            }
        }
        public ActionResult Delete(Guid bookingID)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                BookingModel booking = dbContext.Bookings.Find(bookingID);

                if (booking == null)
                {
                    return Content("Booking not found");
                }

                // delete status logs
                foreach (BookingStatusLogModel statusLog in booking.BookingStatusLogs.ToList())
                {
                    dbContext.BookingStatusLogModels.Remove(statusLog);
                }

                //remove booking
                dbContext.Bookings.Remove(booking);

                try
                {
                    dbContext.SaveChanges();
                    return Content("Deleted Booking");
                }
                catch (Exception ex)
                {
                    return Content("Error deleting booking");
                }
            }
        }
    }
}