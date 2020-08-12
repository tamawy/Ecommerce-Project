using System;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    //Yasser
    public class ColorController : Controller
    {
        Authorization authorization = new Authorization();
        ColorDAL colorDAL = new ColorDAL();
        // GET: Admin/Color
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public PartialViewResult AddForm()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostColor";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostColor(ColorVM colorVM)
        {
            User currentUser = (User)Session["User"];
            string message;
            var obj = new Color()
            {
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = currentUser.ID,
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
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(colorDAL.GetAll());
        }
        public PartialViewResult EditForm(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            User currentUser = (User)Session["User"];
            string message;
            var obj = new Color()
            {
                ID = colorVM.ID,
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = colorVM.CreatedBy,
                CreationDate = colorVM.CreationDate,
                UpdatedBy = currentUser.ID,
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