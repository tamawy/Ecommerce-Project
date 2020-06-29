using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    //Yasser
    public class BrandController : Controller
    {
        BrandDAL brandDAL = new BrandDAL();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View(brandDAL.GetAll());
        }

        public PartialViewResult BrendData()
        {
            return PartialView(brandDAL.GetAll());
        }
    }
}