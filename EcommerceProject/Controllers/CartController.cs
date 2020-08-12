using System.Collections.Generic;
using System.Linq;
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
        public JsonResult AddToCart(long id, int quantity, bool replace) {
            if (Session["UserOrder"] == null)
            {
                Session["UserOrder"] = new List<OrderDetails>();
            }
            
            var p = new DAL.ProductDAL().GetOne(id);
            var list = (List<OrderDetails>)Session["UserOrder"];
            var item = list.Where(z => z.ProductFK == id).FirstOrDefault();
            if (item != null)
            {
                if (replace)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    item.Quantity += quantity;
                }
                item.TotalPrice = item.Quantity * item.Price;
            }
            else
            {
                list.Add(new OrderDetails
                {
                    ID = list.Count + 1,
                    ProductFK = p.ID,
                    Price = p.Price,
                    TotalPrice = quantity * p.Price,
                    Product = p,
                    Quantity = quantity
                });
            }
            Session["UserOrder"] = list;
            return Json( JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteFromCart(long id)
        {
            var list = (List<OrderDetails>)Session["UserOrder"];
            var item = list.Where(z => z.ProductFK == id).FirstOrDefault();
            if (item != null)
            {
                list.Remove(item);
            }
            Session["UserOrder"] = list;
            return Json(PartialView("CartItems"),JsonRequestBehavior.AllowGet);
        }
    }
}