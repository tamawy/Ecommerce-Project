using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            return View(
                new EcommerceProject.DAL.AboutAsDAL().GetAll().FirstOrDefault());
        }
    }
}