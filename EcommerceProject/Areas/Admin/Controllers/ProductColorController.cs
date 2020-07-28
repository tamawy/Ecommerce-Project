using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;
using EcommerceProject.VM;
using EcommerceProject.DAL;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class ProductColorController : Controller
    {
        //Eng. Wlaa
        // GET: Admin/ProductColor

            //creation an object from DAL class 
        ProductColorDAL pcDAL = new ProductColorDAL();
        public ActionResult Index()
        {
            return View();
        }
        //partialview used to show data of database
        public PartialViewResult ProductColorDetails()
        {
            return PartialView(pcDAL.GetAll());
        }
        public PartialViewResult Add()
        {
            ViewBag.FormName = "PostData";
            return PartialView();
        }
        public JsonResult PostData(ProductColorVM pCVM)
        {
            string message;
            var obj = new ProductColor()
            {
                Image = " ",
                ProductFK = pCVM.ProductFK,
                ColorFk = pCVM.ColorFk,
                CreatedBy = 2, 
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
            string message;
            var obj = new ProductColor()
            {
                ID = pcVM.ID,
                ProductFK = pcVM.ProductFK,
                ColorFk = pcVM.ColorFk,
                Image = pcVM.Image,
                CreatedBy = pcVM.CreatedBy,
                CreationDate = pcVM.CreationDate,
                UpdatedBy = 2,
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