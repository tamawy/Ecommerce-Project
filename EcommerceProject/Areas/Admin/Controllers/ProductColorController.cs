using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class ProductColorController : Controller
    {
        //Eng. Wlaa
        // GET: Admin/ProductColor

            //creation an object from DAL class 
        ProductColorDAL obj = new ProductColorDAL();
        public ActionResult Index()
        {
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult ProductColorDetails()
        {
            return PartialView(obj.GetAll());
        }
        public PartialViewResult Add()
        {
            return PartialView();
        }
        public PartialViewResult Edit()
        {
            return PartialView();
        }
        public PartialViewResult Delete()
        {
            return PartialView();
        }

    }
}