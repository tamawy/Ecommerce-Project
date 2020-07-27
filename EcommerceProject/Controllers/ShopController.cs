using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;
using EcommerceProject.DAL;
using EcommerceProject.VM;

namespace EcommerceProject.Controllers
{
    public class ShopController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult products()
        {
            return PartialView(productDAL.GetAll());
        }
        public PartialViewResult category()
        {
            return PartialView(new CategoryDAL().GetAll());
        }

        public PartialViewResult brands()
        {
            return PartialView(new BrandDAL().GetAll());
        }
        
        public PartialViewResult filterByPrice()
        {
            return PartialView();
        }

        public PartialViewResult filterByColor()
        {
            return PartialView();
        }
    }
}