using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderDAL orderDAL = new OrderDAL();
        OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
        UserDAL userDAL = new UserDAL();
        CustomerInfo customerInfo;


        // GET: Admin/Order
        public ViewResult Index()
        {

            return View();
        }
        public PartialViewResult Orders()
        {
            return PartialView(orderDAL.GetAll());
        }

        public PartialViewResult DetailsForm()
        {
            return PartialView();
        }
        public PartialViewResult OrderDetails(long orderID)
        {
            customerInfo = new CustomerInfo()
            {
                order = orderDAL.GetOne(orderID),
                orderDetails = orderDetailsDAL.GetAll(orderID)
            };
            customerInfo.user = userDAL.GetOne(customerInfo.order.UserFK);
            customerInfo.userAddress = new UserAddressDAL().LastAddress(customerInfo.user.ID);
            
            return PartialView("~/Areas/Admin/Views/order/DetailsForm.cshtml", customerInfo);
        }
    }
}