using System;
using System.Web.Mvc;
using EcommerceProject.Models;
using EcommerceProject.VM;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class ProductColorController : Controller
    {
        Authorization authorization = new Authorization();
        //Eng. Wlaa
        // GET: Admin/ProductColor

            //creation an object from DAL class 
        ProductColorDAL pcDAL = new ProductColorDAL();
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult ProductColorDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(pcDAL.GetAll());
        }
        public PartialViewResult Add()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostData";
            return PartialView();
        }
        public JsonResult PostData(ProductColorVM pCVM)
        {
            User currentUser = (User)Session["User"];

            string message;
            var obj = new ProductColor()
            {
                Image = " ",
                ProductFK = pCVM.ProductFK,
                ColorFk = pCVM.ColorFk,
                CreatedBy = currentUser.ID, 
                CreationDate = DateTime.Now
            };
            return Json(
                new 
                {
                    done = pcDAL.Add(obj, out message),
                    message
                },
                JsonRequestBehavior.AllowGet
                );
        }
        public PartialViewResult Edit(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostEdit";
            var pc = pcDAL.GetOne(id);
            var obj = new ProductColorVM()
            {
                ID = pc.ID,
                ProductFK = pc.ProductFK,
                ColorFk = pc.ColorFk, 
                Image = pc.Image,
                CreatedBy = pc.CreatedBy,
                CreationDate = pc.CreationDate
            };
            return PartialView("Add", obj);
        }
        public JsonResult PostEdit(ProductColorVM pcVM)
        {
            User currentUser = (User)Session["User"];

            string message;
            var obj = new ProductColor()
            {
                ID = pcVM.ID,
                ProductFK = pcVM.ProductFK,
                ColorFk = pcVM.ColorFk,
                Image = pcVM.Image,
                CreatedBy = pcVM.CreatedBy,
                CreationDate = pcVM.CreationDate,
                UpdatedBy = currentUser.ID,
                UpdatedDate = DateTime.Now
            };
            return Json(new
            { 
                done = pcDAL.Edit(obj, out message),
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
                    done = pcDAL.Delete(id, out message),
                    message
                },
                JsonRequestBehavior.AllowGet);
        }

    }
}