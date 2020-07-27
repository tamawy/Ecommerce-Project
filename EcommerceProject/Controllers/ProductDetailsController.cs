using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Controllers
{
    public class ProductDetailsController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        // GET: ProductDetails
        public ActionResult Index(long id)
        {
            return View(productDAL.GetOne(id));
        }
    }
}