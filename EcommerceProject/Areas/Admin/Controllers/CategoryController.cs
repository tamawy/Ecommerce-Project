using System;
using System.Linq;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        Authorization authorization = new Authorization();
        // GET: Admin/Category
        CategoryDAL CategroyDAL = new CategoryDAL();
        // GET: Admin/Category
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public PartialViewResult CategoryDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(CategroyDAL.GetAll()
                .OrderByDescending(z => z.ID).ToList());
        }
        public PartialViewResult AddCategory()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostCategory";
            return PartialView();
        }
        public PartialViewResult EditCategory(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
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
            User currentUser = (User)Session["User"];
            string message;
            Category category = new Category()
            {
                Name = vm.Name,
                CreatedBy = currentUser.ID,
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
            User currentUser = (User)Session["User"];
            string message;
            Category category = new Category()
            {
                ID = vm.ID,
                Name = vm.Name,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedDate = DateTime.Now,
                UpdatedBy = currentUser.ID,

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