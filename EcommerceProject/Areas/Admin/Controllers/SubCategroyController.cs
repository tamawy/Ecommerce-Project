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
    public class SubCategroyController : Controller
    {
        SubCategroyDAL SubCategroyDAL = new SubCategroyDAL();
        // GET: Admin/Categroy
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SubCategroyDetails()
        {
            return PartialView(SubCategroyDAL.GetAll());
        }
        public PartialViewResult AddSubCategory()
        {
            ViewBag.FormName = "PostSubCategory";
            return PartialView();
        }
        public PartialViewResult EditSubCategory(long id)
        {
            var data = SubCategroyDAL.GetOne(id);
            SubCategoryVM obj = new SubCategoryVM()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "EditSubCategory";
            return PartialView("AddSubCategory", obj);
        }
        public PartialViewResult DetailsSubCategory(long id)
        {
            var data = SubCategroyDAL.GetOne(id);
            SubCategoryVM obj = new SubCategoryVM()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "DetailsSubCategory";
            return PartialView("AddSubCategory", obj);
        }
        [HttpPost]
        public JsonResult PostSubCategory(SubCategoryVM vm)
        {
            string message = "";

            SubCategory subcategory = new SubCategory()
            {
                Name = vm.Name,
                CategoryFK = vm.CategoryFK,
                CreatedBy = 1,
                CreationDate = DateTime.Now
            };
            if (SubCategroyDAL.Add(subcategory, out message))
            {
                return Json(new { done = true, message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false, message }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditSubCategory(SubCategoryVM vm)
        {
            SubCategory sucategory = new SubCategory()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now
            };
            if (SubCategroyDAL.Edit(sucategory))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSubCategory(long id)
        {
            if (SubCategroyDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }

    }
}