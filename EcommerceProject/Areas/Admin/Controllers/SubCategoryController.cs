using System;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
using EcommerceProject.VM;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        Authorization authorization = new Authorization();
        SubCategroyDAL SubCategroyDAL = new SubCategroyDAL();
        // GET: Admin/Categroy
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public PartialViewResult SubCategoryDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(SubCategroyDAL.GetAll());
        }
        public PartialViewResult AddSubCategory()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostSubCategory";
            return PartialView();
        }
        public PartialViewResult EditSubCategory(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            User currentUser = (User)Session["User"];
            string message = "";

            SubCategory subcategory = new SubCategory()
            {
                Name = vm.Name,
                CategoryFK = vm.CategoryFK,
                CreatedBy = currentUser.ID,
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
            User currentUser = (User)Session["User"];
            string message;
            SubCategory sucategory = new SubCategory()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedBy = currentUser.ID,
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