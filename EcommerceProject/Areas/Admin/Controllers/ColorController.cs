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
    //Yasser
    public class ColorController : Controller
    {
        ColorDAL colorDAL = new ColorDAL();
        // GET: Admin/Color
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AddForm()
        {
            ViewBag.FormName = "PostColor";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostColor(ColorVM colorVM)
        {
            string message;
            var obj = new Color()
            {
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = 2,
                CreationDate = DateTime.Now
            };
            return Json(
                new
                {
                    done = colorDAL.Add(obj, out message),
                    message
                }
                ,
                JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult ColorData()
        {
            return PartialView(colorDAL.GetAll());
        }
        public PartialViewResult EditForm(long id)
        {
            ViewBag.FormName = "PostEdit";
            var color = colorDAL.Getone(id);
            var obj = new ColorVM()
            {
                ID = color.ID,
                Name = color.Name,
                Code = color.Code,
                CreatedBy = color.CreatedBy,
                CreationDate = color.CreationDate
            };
            return PartialView("AddForm", obj);
        }
        public JsonResult PostEdit(ColorVM colorVM)
        {
            string message;
            var obj = new Color()
            {
                ID = colorVM.ID,
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = colorVM.CreatedBy,
                CreationDate = colorVM.CreationDate,
                UpdatedBy = 2,
                UpdatedDate = DateTime.Now
            };

            return Json(
                new
                {
                    done = colorDAL.Edit(obj, out message),
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
                    done = colorDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}