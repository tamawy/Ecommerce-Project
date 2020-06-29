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
        ContactMessageDAL contmsgDAL = new ContactMessageDAL();
        // GET: Admin/ContactMessage
        //Show All data
        public ActionResult ShowAll()
        {
            return View();
        }
        //patial Show
        public PartialViewResult IndexPartial()
        {
            return PartialView(contmsgDAL.GetAll());
        }
        //Add get
        public PartialViewResult AddContactMessage()
        {
            //ViewBag.FormName = "PostContactMessage";

            return PartialView();
        }

        //Details
        public PartialViewResult DetailsContactMessage(long id)
        {
            var data = contmsgDAL.GetOne(id);
            ContactMessageVM obj = new ContactMessageVM()
            {
                ID = data.ID,
                Email = data.Email,
                Name = data.Name,
                Message = data.Message,
                CreatedBy = (Int32)data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = (Int32)data.UpdatedBy,
                UpdatedDate = (DateTime)data.UpdatedDate,
                IsAnswer = data.IsAnswer


            };
            ViewBag.FormName = "DetailsContactMessage";

            return PartialView("AddContactMessage", obj);
        }

        //isanswered get
        public PartialViewResult IsAnswered(long id)
        {
            var data = contmsgDAL.GetOne(id);
            ContactMessageVM obj = new ContactMessageVM()
            {
                ID = data.ID,
                Email = data.Email,
                Name = data.Name,
                Message = data.Message,
                CreatedBy = (Int32)data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = (Int32)data.UpdatedBy,
                UpdatedDate = (DateTime)data.UpdatedDate,
                IsAnswer = data.IsAnswer



            };
            ViewBag.FormName = "IsAnswered";

            return PartialView("AddContactMessage", obj);
        }

        //edit post
        [HttpPost]
        public JsonResult IsAnswered(ContactMessageVM contactvm)
        {
            ContactMesaage contact = new ContactMesaage()
            {
                ID = contactvm.ID,
                IsAnswer = contactvm.IsAnswer


            };
            if (contmsgDAL.Edit(contact))
            {
                TempData["Edited"] = "Edited Successfully";

                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
        //delete
        public JsonResult DeleteContactMessage(long id)
        {
            if (contmsgDAL.Delete(id))
            {
                //viewbag Deleted successfully
                TempData["Deleted"] = "Deleted Successsfully";
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
                //TempData["added"] = true;
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
    }
}