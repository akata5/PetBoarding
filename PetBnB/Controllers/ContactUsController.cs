using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBnB.Models;
using PetBnB.ViewModels;


namespace PetBnB.Controllers
{
    public class ContactUsController : Controller
    {
        // need dbcontext to post to database
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: ContactUs

        public ActionResult Index()
        {
            return View(new ContactUsSubmissionVM());
        }

        // POST: ContactUs
        [HttpPost]
        public ActionResult Index(ContactUsSubmissionVM contactUsSubmissionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(contactUsSubmissionVM);
            }

            ContactUsSubmissionModel submission = new ContactUsSubmissionModel();
            submission.Name = contactUsSubmissionVM.Name;
            submission.Email = contactUsSubmissionVM.Email;
            submission.PhoneNumber = contactUsSubmissionVM.PhoneNumber;
            submission.Subject = contactUsSubmissionVM.Subject;
            submission.Message = contactUsSubmissionVM.Message;
            submission.TimeSubmitted = DateTime.UtcNow;

            dbContext.ContactSubmissionModels.Add(submission);
            dbContext.SaveChanges();

            return RedirectToAction("ContactUsSuccessful");

        }

        public ActionResult ContactUsSuccessful()
        {
            return View();
        }
    }
}