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
    // Ibrahim Elsayed Selim
    public class ProductController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProductDetails()
        {
            return PartialView(productDAL.GetAll());
        }

        public PartialViewResult AddProduct()
        {
            ViewBag.FormName = "PostProduct";
            return PartialView();
        }

        [HttpPost]
        public JsonResult PostProduct(ProductVM productVM)
        {
            string message;
            Product obj = new Product()
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Decription = productVM.Decription,
                Image = "",
                BrandFK = productVM.BrandFK,
                CatFK = productVM.CatFK,
                SubCatFK = productVM.SubCatFK,
                CreatedBy = 1,
                CreationDate = DateTime.Now,
                IsBestSeller = productVM.IsBestSeller
            };
            ViewBag.FormName = "PostProduct";
            return Json(
                new 
                { 
                    done = productDAL.Add(obj, out message), 
                    message, 
                    add = true 
                }, 
                JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult Delete(long id)
        {
            return Json(new { done = productDAL.Delete(id) },
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Edit(long id)
        {
            var data = productDAL.GetOne(id);
            ViewBag.FormName = "EditProduct";
            return PartialView("AddProduct",
                new ProductVM()
                {
                    Name = data.Name,
                    Price = data.Price,
                    Image = data.Image,
                    Decription = data.Decription,
                    BrandFK = data.BrandFK,
                    CatFK = data.CatFK,
                    SubCatFK = data.SubCatFK,
                    CreatedBy = data.CreatedBy,
                    CreationDate = data.CreationDate,
                    IsBestSeller = data.IsBestSeller
                });
        }

        [HttpPost]
        public JsonResult EditProduct(ProductVM data)
        {
            string message;
            var obj = new Product()
            {
                ID = data.ID,
                Name = data.Name,
                Price = data.Price,
                Image = productDAL.GetOne(data.ID).Image,
                Decription = data.Decription,
                BrandFK = data.BrandFK,
                CatFK = data.CatFK,
                SubCatFK = data.SubCatFK,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = 1,
                UpdatedDate = DateTime.Now,
                IsBestSeller = data.IsBestSeller
            };
            return Json(new { done = productDAL.Edit(obj, out message), message, edit = true },
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult DetailsProduct(long id)
        {
            var data = productDAL.GetOne(id);
            var obj = new ProductVM()
            {
                Name = data.Name,
                Price = data.Price,
                Image = data.Image,
                Decription = data.Decription,
                Brand = data.Brand,
                BrandFK = data.BrandFK,
                Category = data.Category,
                SubCategory = data.SubCategory,
                CatFK = data.CatFK,
                UserCreated = data.User.Name,
                CreationDate = data.CreationDate,
                UserUpdated = data.User1?.Name, // to be viewed
                UpdatedDate = data.UpdatedDate,
                IsBestSeller = data.IsBestSeller
            };
            ViewBag.FormName = "DetailsProduct";
            return PartialView("AddProduct", obj);
        }

        public JsonResult GetSubCats(long id)
        {
            return Json(
                new SubCategroyDAL().GetAll().Where(z => z.CategoryFK == id).
                Select(z => new
                {
                    z.ID,
                    z.Name
                }).ToList()
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadImage(long id)
        {
            ViewBag.productID = id;
            return View();
        }

        [HttpPost]
        public ActionResult PostProductImage(HttpPostedFileBase file, long productID)
        {
            string message;
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Attachments/Products"), pic);

                // file is uploaded
                file.SaveAs(path);
                string filePath = "/Attachments/Products/" + pic;


                var product = productDAL.GetOne(productID);
                if (product != null)
                {
                    product.Image = filePath;
                    product.UpdatedBy = 2;
                    product.UpdatedDate = DateTime.Now;
                    productDAL.Edit(product, out message);
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }
    }
}