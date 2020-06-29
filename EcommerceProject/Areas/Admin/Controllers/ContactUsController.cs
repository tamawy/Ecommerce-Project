using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    // Eng. Wlaa
    public class ContactUsController : Controller
    {
        // GET: Admin/ContactUs
        ContactUsDAL obj = new ContactUsDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactUsDetails()
        {
            return PartialView(obj.GetAll());
        }
    }
}