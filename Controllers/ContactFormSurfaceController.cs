using MandatoryUmbraco.ViewModels;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MandatoryUmbraco.Controllers
{
    public class ContactFormSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

          
            MailMessage message = new MailMessage();           
            message.To.Add("zxc32test@gmail.com");

            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("zxc32test@gmail.com", "!Qwerty12");
                smtp.EnableSsl = true;

                smtp.Send(message);
            }

            TempData["success"] = true;

            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "userMessage");
            comment.SetValue("userName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);

            Services.ContentService.Save(comment); 
                     
            //Services.ContentService.SaveAndPublishWithStatus(comment);

            return RedirectToCurrentUmbracoPage();
        }

    }
}