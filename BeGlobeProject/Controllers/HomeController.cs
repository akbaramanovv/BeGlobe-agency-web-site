using BeGlobeProject.DAL;
using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Controllers
{
    public class HomeController : MainController
    {

        public async Task<ActionResult> RenderImage(int? id)
        {
            Logo item = await db.Logos.FindAsync(id);

            byte[] photoBack = item.Photo;

            return File(photoBack, "image/png");
        }
        public async Task<ActionResult> RenderImage2(int? id)
        {
            Work item = await db.Works.FindAsync(id);

            byte[] photoBack = item.WorkPhoto;

            return File(photoBack, "image/png");
        }
        public async Task<ActionResult> RenderImage3(int? id)
        {
            Work item = await db.Works.FindAsync(id);

            byte[] photoBack = item.WorkFullImage;

            return File(photoBack, "image/png");
        }
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Photos = db.Photos.ToList(),
                Employees = db.Employees.ToList(),
                Position = db.Positions.ToList(),
                Works = db.Works.Take(6).ToList(),
                Services = db.Services.ToList(),
                Logos = db.Logos.ToList()
            };
            return View(model);
        }
        public ActionResult About()
        {
            AboutWM model = new AboutWM()
            {
                Employees = db.Employees.ToList(),
                Positionns = db.Positions.ToList(),
                Services = db.Services.ToList(),
            };
            return View(model);
        }
        public ActionResult Contact()
        {

            ContactWM model = new ContactWM();
            model.Messages = new Message();
            model.Contacts = db.Contacts.FirstOrDefault();
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Message message)
        {
            if (message != null)
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
            try
            {
                var fromAddress = new MailAddress("beglobe.client@gmail.com");
                var fromPassword = "Ekber2018";
                //hi@beglobe.agency
                var toAddress = new MailAddress("hi@beglobe.agency");

                string subject = message.FullName + " Email Adress -  " + message.EmailAdress + "  " + ",  Phone - " + message.Phone;
                string body = message.MessageText;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var mes = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })

                    smtp.Send(mes);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex;
            }

            return RedirectToAction("Contact", "Home");
        }
    }
}