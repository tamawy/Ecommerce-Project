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
    // Eng. Wlaa
    public class ContactUsController : Controller
    {
        // GET: Admin/ContactUs
        ContactUsDAL ContactUsDAL = new ContactUsDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactUsDetails()
        {
            return PartialView(ContactUsDAL.GetAll());
        }

        public PartialViewResult Add()
        {
            ViewBag.FormName = "PostAdd";
            return PartialView();
        }

        [HttpPost]
        public JsonResult PostAdd(ContactUsVM contactUsVM)
        {
            string message;
            var obj = new ContactUs()
            {
                ID = contactUsVM.ID,
                address = contactUsVM.address,
                phone = contactUsVM.phone,
                facebook = contactUsVM.facebook,
                Email = contactUsVM.Email,
                CreatedBy = 2,
                CreationDate = DateTime.Now
            };

            return Json(
                new
                {
                    done = ContactUsDAL.Add(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Edit(long id)
        {
            ViewBag.FormName = "PostEdit";
            var contactUs = ContactUsDAL.GetOne(id);
            var obj = new ContactUsVM()
            {
                ID = contactUs.ID,
                address = contactUs.address,
                phone = contactUs.phone,
                facebook = contactUs.facebook,
                Email = contactUs.Email,
                CreatedBy = contactUs.CreatedBy,
                CreationDate = contactUs.CreationDate
            };
            return PartialView("Add", obj);
        }

        [HttpPost]
        public JsonResult PostEdit(ContactUsVM contactUsVM)
        {
            string message;
            var obj = new ContactUs()
            {
                ID = contactUsVM.ID,
                address = contactUsVM.address,
                phone = contactUsVM.phone,
                facebook = contactUsVM.facebook,
                Email = contactUsVM.Email,
                CreatedBy = contactUsVM.CreatedBy,
                CreationDate = contactUsVM.CreationDate,
                UpdatedBy = 2,
                UpdatedDate = DateTime.Now
            };

            return Json(
                new
                {
                    done = ContactUsDAL.Edit(obj, out message),
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
                    done = ContactUsDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Details(long id)
        {
            var contactUs = ContactUsDAL.GetOne(id);
            var obj = new ContactUsVM()
            {
                address = contactUs.address,
                Email = contactUs.Email,
                facebook = contactUs.facebook,
                phone = contactUs.phone
            };

            return PartialView("Add",obj);
        }
    }
}