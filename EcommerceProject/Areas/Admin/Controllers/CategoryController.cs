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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryDAL CategroyDAL = new CategoryDAL();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CategoryDetails()
        {
            return PartialView(CategroyDAL.GetAll()
                .OrderByDescending(z => z.ID).ToList());
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
            string message;
            Category category = new Category()
            {
                Name = vm.Name,
                CreatedBy = 1,
                CreationDate = DateTime.Now

            };
            return Json(new 
            { 
                done = CategroyDAL.Add(category, out message),
                message, 
                add = true
            }, 
                JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditCategory(CategroyVM vm)
        {
            string message;
            Category category = new Category()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,

            };
            return Json(new 
            { 
                done = CategroyDAL.Edit(category, out message) ,
                message, 
                edit = true
            },
                JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteCategory(long id)
        {
            string message;
            return Json(new
            {
                done = CategroyDAL.Delete(id, out message),
                message
            }, 
            JsonRequestBehavior.AllowGet) ;
        }
    }
}