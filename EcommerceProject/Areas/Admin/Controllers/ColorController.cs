using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    //Yasser
    public class ColorController : Controller
    {
        ColorDAL colorDAL = new ColorDAL();
        // GET: Admin/Color
        public ActionResult Index()
        {
            return View(colorDAL.GetAll());
        }
        public PartialViewResult ColorData()
        {
            return PartialView(colorDAL.GetAll());
        }
    }
}