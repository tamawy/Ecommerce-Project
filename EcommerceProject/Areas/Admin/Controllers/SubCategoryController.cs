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
    public class SubCategoryController : Controller
    {
        SubCategroyDAL SubCategroyDAL = new SubCategroyDAL();
        // GET: Admin/Categroy
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SubCategoryDetails()
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
            return Json(
                new 
                { 
                    done = SubCategroyDAL.
                    Add(subcategory, out message),
                    message 
                }, 
                JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditSubCategory(SubCategoryVM vm)
        {
            string message;
            SubCategory sucategory = new SubCategory()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now
            };
            return Json(
                new
                {
                    done = SubCategroyDAL
                    .Edit(sucategory, out message),
                    message,
                    edit = true
                },
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSubCategory(long id)
        {
            string message;
            return Json(
                new 
                { 
                    done = SubCategroyDAL
                    .Delete(id, out message),
                    message
                }, 
                JsonRequestBehavior.AllowGet);
        }

    }
}