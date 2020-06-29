using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.Models;
using EcommerceProject.VM;

namespace EcommerceProject.Areas.Admin.Controllers
{
    public class UserAddressController : Controller
    {
        //create object from Class DAL to use functions easily.
        UserAddressDAL obj = new UserAddressDAL();
        // GET: Admin/UserAddress
        // in This View,We can render Partial Views ( Detail & Show rendered).
        public ActionResult Index()
        {
            return View();
        }
        //This PartialView used to show all Data from DataBase.
        public ActionResult Show()
        {
            return PartialView(obj.GetAll());
        }

        //This Action Used to delete data of declared id & Show result of delete in Index.
        public JsonResult Delete(long Id)
        {
            if (obj.Delete(Id))
            {
                return Json(new { done = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { done = false }, JsonRequestBehavior.AllowGet);
        }

        //This PartialView return Details for Declared id.

        public ActionResult Detail(long Id)
        {
            var data = obj.GetDetails(Id);
            UserAddressVM userAd = new UserAddressVM()
            {
                Address = data.Address,
                phone = data.phone,
                UserFK = data.UserFK,
                CreatedBy = data.CreatedBy,
                CreationDate = data.CreationDate,
                UpdatedBy = data.UpdatedBy,
                UpdatedDate = data.UpdatedDate
            };
            ViewBag.FormMethod = "Detail";
            return PartialView("form", userAd);
        }
        //Partialview for form to display details..
        public PartialViewResult form()
        {
            return PartialView();
        }
    }
}