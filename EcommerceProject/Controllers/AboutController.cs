using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            return View(
                new EcommerceProject.DAL.AboutUsDAL().GetAll().FirstOrDefault());
        }
    }
}