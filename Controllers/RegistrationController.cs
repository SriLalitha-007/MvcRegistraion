using Microsoft.AspNetCore.Mvc;
using MvcRegistraion.Models;
using MvcRegistraion.Services;
using System.Threading.Tasks;
using System;
using System.Text;

namespace MvcRegistraion.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegisterServices _registerServices;
        private readonly EmailService _emailService;

        public RegistrationController(RegisterServices registerServices, EmailService emailService)
        {
            _registerServices = registerServices;
            _emailService = emailService;
        }

        // GET: /Registration/Create
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistrationForm model)
        {
            if (ModelState.IsValid)
            {
                // Assuming you want to set the registration date to the current date
                model.RegDate = DateTime.Now;

                await _registerServices.CreateAsync(model);

                // Sending the email after saving to MongoDB
                string fromEmail = "kotilalitha7@example.com";
                string toEmail = model.Email;
                string subject = "Registration Details";
                // string body = "Here are the registration details: " + model.ToString();
                // Create the email body in HTML format with field names in bold
                var body = new StringBuilder();
                body.Append("<html><body>");

                body.Append("<p><strong>First Name:</strong> " + model.FirstName + "</p>");
                body.Append("<p><strong>Last Name:</strong> " + model.LastName + "</p>");
                body.Append("<p><strong>Age:</strong> " + model.Age + "</p>");
                body.Append("<p><strong>Gender:</strong> " + model.Gender + "</p>");
                body.Append("<p><strong>Date of Birth:</strong> " + model.DateOfBirth + "</p>");
                body.Append("<p><strong>Email:</strong> " + model.Email + "</p>");
                body.Append("<p><strong>Mobile Number:</strong> " + model.MobileNumber + "</p>");
                body.Append("<p><strong>Telephone Number:</strong> " + model.TelephoneNumber + "</p>");
                body.Append("<p><strong>Door Number:</strong> " + model.D_No + "</p>");
                body.Append("<p><strong>Street:</strong> " + model.Street + "</p>");
                body.Append("<p><strong>City:</strong> " + model.City + "</p>");
                body.Append("<p><strong>Pincode:</strong> " + model.Pincode + "</p>");
                body.Append("<p><strong>Registration Date:</strong> " + model.RegDate + "</p>");

                body.Append("</body></html>");


                await _emailService.SendEmailAsync(fromEmail, toEmail, subject, body.ToString());

                // Redirect to a success page or any other appropriate page
                 return RedirectToRoute("Home");
                


            }

            return View(model);
        }
    }
}
