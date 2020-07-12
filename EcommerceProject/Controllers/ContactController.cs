using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
using EcommerceProject.VM;

namespace EcommerceProject.Controllers
{
    public class ContactController : Controller
    {
        ContactMessageDAL contactMessageDAL =
            new ContactMessageDAL();

        // GET: CustomerContactUs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactMessage()
        {
            return PartialView();
        }

        public ActionResult ContactUs()
        {

            return PartialView(new ContactUsDAL().GetOne(1));
        }


        public JsonResult AddContactMessage(string Name, string Email, string Message)
        {
            string message;
            var obj = new ContactMesaage()
            {
                CreatedBy = 2,
                CreationDate = DateTime.Now,
                Email = Email,
                Message = Message,
                Name = Name,
                IsAnswer = false
            };
            return Json(
                new
                {
                    done = contactMessageDAL.Add(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Map()
        {
            return PartialView();
        }
    }
}