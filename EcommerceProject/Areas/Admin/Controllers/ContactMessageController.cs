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
    public class ContactMessageController : Controller
    {
        ContactMessageDAL contactMessageDAL =
            new ContactMessageDAL();
        // GET: Admin/ContactMessage
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Form()
        {
            return PartialView();
        }
        public PartialViewResult ContactMessageTable()
        {
            return PartialView(contactMessageDAL.GetAll());
        }
        public PartialViewResult Details(long id)
        {
            var contactMessage = contactMessageDAL.GetOne(id);
            var obj = new ContactMessageVM()
            {
                ID = contactMessage.ID,
                Email = contactMessage.Email,
                IsAnswer = contactMessage.IsAnswer,
                CreatedBy = contactMessage.CreatedBy,
                CreationDate = contactMessage.CreationDate,
                Message = contactMessage.Message,
                Name = contactMessage.Name
            };
            return PartialView("Form", obj);
        }

        [HttpPost]
        public JsonResult Answered(long id)
        {
            var obj = contactMessageDAL.GetOne(id);
            obj.IsAnswer = true;
            string message;
            return Json(
                new {
                    done = contactMessageDAL.Edit(obj, out message),
                    message
                }
                ,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            string message;
            return Json(
                new
                {
                    done = contactMessageDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}