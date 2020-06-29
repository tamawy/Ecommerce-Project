using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;
using EcommerceProject.VM;
using EcommerceProject.DAL;

namespace EcommerceProject.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDAL = new UserDAL();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult UserDetails()
        {
            var obj = (User)Session["user"];
            if (obj == null)
            {
                return PartialView();
            }
            return PartialView(userDAL.GetOne(obj.ID));
        }

        

        public JsonResult Delete(long id)
        {
            string message = "";
            var result = userDAL.Delete(id, out message);
            // if the account is deleted, then close session
            if (result)
            {
                Session["user"] = null;
            }
            return Json(new { done = result, message}
                ,JsonRequestBehavior.AllowGet);
        }
    }
}