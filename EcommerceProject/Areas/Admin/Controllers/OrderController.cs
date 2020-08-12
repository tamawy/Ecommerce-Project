using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        Authorization authorization = new Authorization();
        OrderDAL orderDAL = new OrderDAL();
        OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        UserDAL userDAL = new UserDAL();
        CustomerInfo customerInfo;


        // GET: Admin/Order
        public ActionResult Index()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return View();
        }
        public PartialViewResult Orders()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView(orderDAL.GetAll());
        }

        public PartialViewResult DetailsForm()
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            return PartialView();
        }
        public PartialViewResult OrderDetails(long orderID)
        {
            if (!authorization.Admin((User)Session["User"]))
            {
                return PartialView("ErrorView");
            }
            customerInfo = new CustomerInfo()
            {
                order = orderDAL.GetOne(orderID),
                orderDetails = orderDetailsDAL.GetAll(orderID)
            };
            customerInfo.user = userDAL.GetOne(customerInfo.order.UserFK);
            customerInfo.userAddress = new UserAddressDAL().LastAddress(customerInfo.user.ID);
            
            return PartialView("~/Areas/Admin/Views/order/DetailsForm.cshtml", customerInfo);
        }

        [HttpPost]
        public JsonResult Delete(long orderID) {
            orderDetailsDAL.DeleteAll(orderID);
            orderDAL.Delete(orderID);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}