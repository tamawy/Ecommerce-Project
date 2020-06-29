using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Vm;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderDAL obj = new OrderDAL();
        // GET: Admin/Order
        public ActionResult Index()
        {

            return View(obj.GetAll());
        }
        public ActionResult OrderDet()
        {
            return View(obj.GetAll());

        }
    }
}