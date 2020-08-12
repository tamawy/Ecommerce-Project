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
        CustomerInfoDAL cIDAL = new CustomerInfoDAL();
        UserAddressDAL userAddressDAL = new UserAddressDAL();
        OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        OrderDAL orderDAL = new OrderDAL();

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
            string userAddressMessage;
            UserAddress userAddress = new UserAddress()
            {
                Address = customerInfo.userAddress.Address,
                phone = customerInfo.userAddress.phone,
                CreatedBy = currentUser.ID,
                CreationDate = DateTime.Now,
                UserFK = currentUser.ID
            };
            var stored = userAddressDAL.Add(userAddress, out userAddressMessage);

            // Adding Order to Database
            string orderMessage;
            Order order = new Order() {
                UserFK = currentUser.ID,
                OrderDate = DateTime.Now,
                CreatedBy = currentUser.ID,
                CreationDate = DateTime.Now,
                OrderNumber = orderDAL.GetNextOrderNumber(),
                UserAddressFK = userAddressDAL.GetUserAddressFK(currentUser.ID),
                TotalPrice = cIDAL.TotalPrice(customerInfo)
            };
            stored = orderDAL.Add(order, out orderMessage) && stored;

            // Adding OrderDetails to DataBase
            string orderDetailsMessage = "";
            OrderDetails orderDetails;
            
            foreach (var item in customerInfo.orderDetails)
            {
                orderDetails = new OrderDetails()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderFK = orderDAL.GetOrderFK(currentUser.ID),
                    TotalPrice = item.TotalPrice,
                    ProductFK = item.ProductFK,
                    CreatedBy = currentUser.ID,
                    CreationDate = DateTime.Now
                };
                stored = stored && orderDetailsDAL.Add(orderDetails, out orderDetailsMessage);
            }

            return Json(
                new 
                {
                    stored,
                    userAddressMessage,
                    orderMessage,
                    orderDetailsMessage
                }
                ,JsonRequestBehavior.AllowGet);
        }
    }
}