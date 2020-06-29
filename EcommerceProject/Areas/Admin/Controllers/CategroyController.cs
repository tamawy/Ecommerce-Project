using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
using EcommerceProject.VM;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class CategroyController : Controller
    {
        CategoryDAL CategroyDAL = new CategoryDAL();
        // GET: Admin/Categroy
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CategroyDetails()
        {
            return PartialView(CategroyDAL.GetAll());
        }
        public PartialViewResult AddCategory()
        {
            ViewBag.FormName = "PostCategory";
            return PartialView();
        }
        public PartialViewResult EditCategory(long id)
        {
            var data = CategroyDAL.GetOne(id);
            CategroyVM obj = new CategroyVM()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "EditCategory";

            return PartialView("AddCategory", obj);
        }
        public PartialViewResult DetailsCategory(long id)
        {
            var data = CategroyDAL.GetOne(id);
            CategroyVM obj = new CategroyVM()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "DetailsCategory";

            return PartialView("AddCategory", obj);
        }
        [HttpPost]
        public JsonResult PostCategory(CategroyVM vm)
        {
            Category category = new Category()
            {
                Name = vm.Name,
                CreatedBy = 1,
                CreationDate = DateTime.Now

            };
            if (CategroyDAL.Add(category))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditCategory(CategroyVM vm)
        {
            Category category = new Category()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,

            };
            if (CategroyDAL.Edit(category))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCategory(long id)
        {
            if (CategroyDAL.Delete(id))

            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
    }
}