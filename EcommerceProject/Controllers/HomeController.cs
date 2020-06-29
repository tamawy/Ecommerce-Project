using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Controllers
{
    public class HomeController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        public ActionResult Index()
        {
            return View();
        }

       public PartialViewResult Banner()
        {
            var list = productDAL.GetAll().OrderByDescending(z => z.ID).Take(3).ToList();
            return PartialView(list);
        }

        
    }
}