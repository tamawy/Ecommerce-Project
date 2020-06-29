using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    //Eng. Wlaa
    public class AboutAsController : Controller
    {
        // GET: Admin/AboutAs

        //creation an object from DAL class 
        AboutAsDAL obj = new AboutAsDAL();
        public ActionResult Index()
        {
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult AboutAsDetails()
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