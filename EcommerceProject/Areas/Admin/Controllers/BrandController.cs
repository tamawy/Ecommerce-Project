using System;
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
        Authorization authorization = new Authorization();
        BrandDAL brandDAL = new BrandDAL();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View(brandDAL.GetAll());
        }

        public PartialViewResult BrandData()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(brandDAL.GetAll().OrderByDescending(z => z.ID).ToList());
        }

        public PartialViewResult Add()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostBrand";
            return PartialView();
        }

        [HttpPost]
        public JsonResult PostBrand(BrandVM brandVM)
        {
            User currentUser = (User)Session["User"];
            string message;
            Brand brand = new Brand()
            {
                Name = brandVM.Name,
                Image = " ",
                CreatedBy = currentUser.ID,
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
        
        public PartialViewResult Edit(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            var data = brandDAL.Getone(id);
            ViewBag.FormName = "EditBrand";
            return PartialView("Add",
                new BrandVM()
                {
                    ID = data.ID,
                    Name = data.Name,
                    CreatedBy = data.CreatedBy,
                    CreationDate = data.CreationDate,
                    UpdatedBy = data.UpdatedBy,
                    UpdatedDate = data.UpdatedDate,
                    Image = data.Image
                }
                );
        }

        [HttpPost]
        public JsonResult EditBrand(BrandVM data)
        {
            string message;
            Brand brand = new Brand()
            {
                ID = data.ID,
                Name = data.Name,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate,
                Image = data.Image
            };

            return Json(new { done = brandDAL.Edit(brand, out message),
                message , edit = true},
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
            User currentUser = (User)Session["User"];
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
                    brand.UpdatedBy = currentUser.ID;
                    brand.UpdatedDate = DateTime.Now;

                    brandDAL.Edit(brand, out message);
                }
            }

            return RedirectToAction("Index");
        }
    }
}