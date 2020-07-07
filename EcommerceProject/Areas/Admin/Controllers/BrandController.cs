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
    public class BrandController : Controller
    {
        BrandDAL brandDAL = new BrandDAL();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            return View(brandDAL.GetAll());
        }

        public PartialViewResult BrandData()
        {
            return PartialView(brandDAL.GetAll().OrderByDescending(z => z.ID).ToList());
        }

        public PartialViewResult Add()
        {
            ViewBag.FormName = "PostBrand";
            return PartialView();
        }

        [HttpPost]
        public JsonResult PostBrand(BrandVM brandVM)
        {
            string message;
            Brand brand = new Brand()
            {
                Name = brandVM.Name,
                Image = "",
                CreatedBy = 1,
                CreationDate = DateTime.Now
            };
            return Json(new
            {
                done = brandDAL.Add(brand, out message),
                message
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(long id)
        {
            return Json(new { done = brandDAL.Delete(id) },
                JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult UploadImage(long id)
        {
            ViewBag.brandID = id;
            return View();
        }

        [HttpPost]
        public ActionResult PostBrandImage(HttpPostedFileBase file, long brandID)
        {
            string message;
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/Attachments/Brands/"), pic);
                
                file.SaveAs(path);
                string filePath = "/Attachments/Brands/" + pic;

                var brand = brandDAL.Getone(brandID);
                if (brand != null)
                {
                    brand.Image = filePath;
                    brand.UpdatedBy = 2;
                    brand.UpdatedDate = DateTime.Now;

                    brandDAL.Edit(brand, out message);
                }
            }

            return RedirectToAction("Index");
        }
    }
}