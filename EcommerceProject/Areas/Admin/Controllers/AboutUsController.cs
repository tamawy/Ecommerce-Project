using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: Admin/AboutUs

        //creation an object from DAL class 
        AboutUsDAL aboutUsDAL = new AboutUsDAL();
        public ActionResult Index()
        {
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult AboutAUsDetails()
        {
            return PartialView(aboutUsDAL.GetAll());
        }
        public PartialViewResult Add()
        {
            ViewBag.FormName = "PostAdd";

            return PartialView();
        }

        [HttpPost]
        public JsonResult PostAdd(AboutUsVM aboutUsVM)
        {
            var obj = new AboutUs()
            {
                ID = aboutUsVM.ID,
                CreatedBy = 2,
                CreationDate = DateTime.Now,
                Mission = aboutUsVM.Mission,
                Vision = aboutUsVM.Vision,
                WhoAreWe = aboutUsVM.WhoAreWe
            };
            return Json("");
        }
        public PartialViewResult Edit(long id)
        {
            ViewBag.FormName = "PostEdit";
            var aboutUs = aboutUsDAL.GetOne(id);
            var aboutUsVM = new AboutUsVM()
            {
                ID = aboutUs.ID,
                CreatedBy = aboutUs.CreatedBy,
                CreationDate = aboutUs.CreationDate,
                UpdatedDate = aboutUs.UpdatedDate,
                UpdatedBy = aboutUs.UpdatedBy,
                Mission = aboutUs.Mission,
                Vision = aboutUs.Vision,
                WhoAreWe = aboutUs.WhoAreWe
            };
            return PartialView("Add",
                aboutUsVM);
        }

        [HttpPost]
        public JsonResult PostEdit(AboutUsVM aboutUsVM)
        {
            string message;
            var obj = new AboutUs()
            {
                ID = aboutUsVM.ID,
                CreatedBy = aboutUsVM.CreatedBy,
                CreationDate = aboutUsVM.CreationDate,
                UpdatedBy = 2,
                UpdatedDate = DateTime.Now,
                Mission = aboutUsVM.Mission,
                Vision = aboutUsVM.Vision,
                WhoAreWe = aboutUsVM.WhoAreWe
            };
            return Json(
                new { 
                    done = aboutUsDAL.Edit(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(long id)
        {
            string message;
            return Json(
                new
                {
                    done = aboutUsDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}