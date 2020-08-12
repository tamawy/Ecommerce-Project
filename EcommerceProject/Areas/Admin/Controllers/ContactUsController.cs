using System;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    // Eng. Wlaa
    public class ContactUsController : Controller
    {
        Authorization authorization = new Authorization();
        // GET: Admin/ContactUs
        ContactUsDAL ContactUsDAL = new ContactUsDAL();
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public ActionResult ContactUsDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(ContactUsDAL.GetAll());
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
        public JsonResult PostAdd(ContactUsVM contactUsVM)
        {
            User currentUser = (User)Session["User"];
            string message;
            var obj = new ContactUs()
            {
                ID = contactUsVM.ID,
                address = contactUsVM.address,
                phone = contactUsVM.phone,
                facebook = contactUsVM.facebook,
                Email = contactUsVM.Email,
                CreatedBy = currentUser.ID,
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
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            User currentUser = (User)Session["User"];
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
                UpdatedBy = currentUser.ID,
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
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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