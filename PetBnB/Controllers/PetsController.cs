using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBnB.Models;

namespace PetBnB.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(Guid petOwnerID, string name, string species, int age, decimal weight, int feedingFrequency, string feedingAmount, string medicalNotes, string specialInstructions)
        {
            // Connect to database
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                PetOwnerModel owner = dbContext.PetOwnerModels.Find(petOwnerID);
                if (owner == null)
                {
                    return Content("Can't create pet, owner not found");
                }

                // Create our object
                PetModel petModel = new PetModel();
                petModel.PetOwnerID = petOwnerID;
                petModel.Name = name;
                petModel.Species = species;
                petModel.Age = age;
                petModel.Weight = weight;
                petModel.FeedingFrequency = feedingFrequency;
                petModel.FeedingAmount = feedingAmount;
                petModel.MedicalNotes = medicalNotes;
                petModel.SpecialInstructions = specialInstructions;

                // add to our dbset
                dbContext.PetModels.Add(petModel);

                // finalize/save the model
                try
                {
                    dbContext.SaveChanges();
                    return Content("Added pet");
                }
                catch (Exception ex)
                {
                    return Content("Error in adding pet"); ;
                }
            }
        }
        public ActionResult Delete(Guid petID)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                PetModel pet = dbContext.PetModels.Find(petID);
                if (pet == null)
                {
                    return Content("Pet not found");
                }
                foreach(BookingModel booking in pet.Bookings.ToList())
                {
                    foreach (BookingStatusLogModel statusLog in booking.BookingStatusLogs.ToList())
                    {
                        // delete logs first
                        dbContext.BookingStatusLogModels.Remove(statusLog);
                    }
                    //delete booking second
                    dbContext.Bookings.Remove(booking);
                }
                //delete pet last
                dbContext.PetModels.Remove(pet);

                try
                {
                    dbContext.SaveChanges();
                    return Content("Deleted pet");
                }
                catch (Exception ex)
                {
                    return Content("Error deleting pet");
                }
            }
        }
    }
}