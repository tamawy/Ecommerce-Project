using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CartItems()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AddToCart(long id, int countity) {
            if (Session["UserOrder"] == null)
            {
                Session["UserOrder"] = new List<OrderDetails>();
            }

            var p = new DAL.ProductDAL().GetOne(id);
            var list = (List<OrderDetails>)Session["UserOrder"];
            list.Add(new OrderDetails
            {
                ID = list.Count + 1,
                ProductFK = p.ID,
                Price = p.Price,
                TotalPrice = countity * p.Price,
                Product = p
            });
            Session["UserOrder"] = list;
            return Json( JsonRequestBehavior.AllowGet);
        }
    }
}