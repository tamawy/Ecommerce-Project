using System;
using System.Linq;
using System.Collections.Generic;
using EcommerceProject.VM;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
namespace EcommerceProject.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BillingDetails() 
        {
            return PartialView();
        }

        public PartialViewResult CustomerInfo() 
        {
            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.user = (User)Session["User"];
            return PartialView(customerInfo);
        }

        [HttpPost]
        public JsonResult PostCustomerInfo(CustomerInfo customerInfo) 
        {
            
            var currentUser = (User)Session["User"];
            customerInfo.orderDetails = (List<OrderDetails>)Session["UserOrder"];
           
            // Adding UserAddress to Database
            UserAddressDAL userAddressDAL = new UserAddressDAL();
            string userAddressMessage;
            UserAddress userAddress = customerInfo.userAddress;
            userAddress.CreatedBy = currentUser.ID;
            userAddress.CreationDate = DateTime.Now;
            userAddress.UserFK = currentUser.ID;
            userAddressDAL.Add(userAddress, out userAddressMessage);

            // Adding Order to Database
            OrderDAL orderDAL = new OrderDAL();
            string orderMessage;
            Order order = new Order();
            order.UserFK = currentUser.ID;
            order.OrderDate = DateTime.Now;
            order.CreatedBy = currentUser.ID;
            order.CreationDate = DateTime.Now;
            order.OrderNumber = orderDAL.GetAll().Count + 1;
            order.UserAddressFK = userAddressDAL.GetAll().
                Where(z => z.UserFK == currentUser.ID).Select(z => z.ID).FirstOrDefault();
            var totalPrice = currentUser.OrderDetails.Select(z => z.Price).Sum();
            order.TotalPrice = totalPrice;
            orderDAL.Add(order, out orderMessage);

            // Adding OrderDetails to DataBase
            OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
            string orderDetailsMessage = "";
            foreach (var item in customerInfo.orderDetails)
            {
                item.OrderFK = orderDAL.GetAll().
                    Where(z => z.UserFK == currentUser.ID).
                    Select(z => z.ID).FirstOrDefault();
                item.CreatedBy = currentUser.ID;
                item.CreationDate = DateTime.Now;
                orderDetailsDAL.Add(item, out orderDetailsMessage);
            }

            return Json(
                new 
                {
                    userAddressMessage,
                    orderMessage,
                    orderDetailsMessage
                }
                ,JsonRequestBehavior.AllowGet);
        }
    }
}