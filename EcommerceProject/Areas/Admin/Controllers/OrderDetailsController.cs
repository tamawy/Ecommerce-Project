using System;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
using EcommerceProject.VM;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        Authorization authorization = new Authorization();
        OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        // GET: Admin/OrderDetails
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View(orderDetailsDAL.GetAll());
        }
        public PartialViewResult OrderDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(orderDetailsDAL.GetAll());
        }
        public PartialViewResult AddOrderDetails()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            ViewBag.FormName = "PostOrderDetails";
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostOrderDetails(OrderDetailsVM vm)
        {

            string message;
            OrderDetails orderDetails = new OrderDetails()
            {
                ID=vm.ID,
                Price=vm.Price,
                TotalPrice=vm.TotalPrice,
                Quantity=vm.Quantity,
                ProductFK=vm.ProductFK,
                OrderFK=vm.OrderFK,
                CreatedBy=(int)EcommerceProject.Common.CommonEnum.Role.Customer,
                CreationDate=DateTime.Now
            };
            
            return Json(new { done = orderDetailsDAL.Add
                (orderDetails, out message), message}
            , JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EditOrderDetails(OrderDetailsVM vm)
        {
            User currentUser = (User)Session["User"];

            OrderDetails orderDetails = new OrderDetails()
            {
                ID = vm.ID,
                Price = vm.Price,
                TotalPrice = vm.TotalPrice,
                Quantity = vm.Quantity,
                CreatedBy = vm.CreatedBy,
                CreationDate = vm.CreationDate,
                UpdatedDate = DateTime.Now,
                UpdatedBy = currentUser.ID
            };
            if (orderDetailsDAL.Edit(orderDetails))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
        public PartialViewResult EditOrderDetails(long id)
        {
            var data = orderDetailsDAL.GetOne(id);
            OrderDetailsVM obj = new OrderDetailsVM()
            {
                ID = data.ID,
                Price = data.Price,
                Product = data.Product,
                TotalPrice = data.TotalPrice,
                ProductFK = data.ProductFK,
                Quantity = data.Quantity,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "EditOrderDetails";

            return PartialView("AddOrderDetails", obj);
        }
        public PartialViewResult DetailsOrderDetails(long id)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            var data = orderDetailsDAL.GetOne(id);
            OrderDetailsVM obj = new OrderDetailsVM()
            {
                ID = data.ID,
                Price = data.Price,
                Product = data.Product,
                TotalPrice = data.TotalPrice,
                ProductFK = data.ProductFK,
                Quantity = data.Quantity,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormName = "DetailsOrderDetails";

            return PartialView("AddOrderDetails", obj);
        }
        public JsonResult DeleteOrderDetails(long id)
        {
            if (orderDetailsDAL.Delete(id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);

        }
    }
}