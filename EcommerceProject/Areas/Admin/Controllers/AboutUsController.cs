using System;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class AboutUsController : Controller
    {
        Authorization authorization = new Authorization();
        // GET: Admin/AboutUs
        //creation an object from DAL class 
        AboutUsDAL aboutUsDAL = new AboutUsDAL();
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult AboutUsDetails()
        {
            return PartialView(aboutUsDAL.GetAll());
        }
        public PartialViewResult Add()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostAdd";

            return PartialView();
        }

        [HttpPost]
        public JsonResult PostAdd(AboutUsVM aboutUsVM)
        {

            User currentUser = (User)Session["User"];
            string message;
            var obj = new AboutUs()
            {
                ID = aboutUsVM.ID,
                CreatedBy = currentUser.ID,
                CreationDate = DateTime.Now,
                Mission = aboutUsVM.Mission,
                Vision = aboutUsVM.Vision,
                WhoAreWe = aboutUsVM.WhoAreWe
            };
            return Json(
                new
                {
                    done = aboutUsDAL.Add(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult Edit(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostEdit";
            var aboutUs = aboutUsDAL.GetOne(id);
            var obj = new AboutUsVM()
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
            return PartialView("Add", obj);
        }

        [HttpPost]
        public JsonResult PostEdit(AboutUsVM aboutUsVM)
        {
            User currentUser = (User)Session["User"];
            string message;
            var obj = new AboutUs()
            {
                ID = aboutUsVM.ID,
                CreatedBy = aboutUsVM.CreatedBy,
                CreationDate = aboutUsVM.CreationDate,
                UpdatedBy = currentUser.ID,
                UpdatedDate = DateTime.Now,
                Mission = aboutUsVM.Mission,
                Vision = aboutUsVM.Vision,
                WhoAreWe = aboutUsVM.WhoAreWe
            };
            return Json(
                new
                {
                    done = aboutUsDAL.Edit(obj, out message),
                    message,
                    edit = true
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