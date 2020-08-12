using System;
using System.Web.Mvc;
using EcommerceProject.Models;
using EcommerceProject.VM;
using EcommerceProject.DAL;
using EcommerceProject.Common;

namespace EcommerceProject.Controllers
{
    public class RegisterController : Controller
    {
        UserDAL userDAL = new UserDAL();
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.User = Session["user"];
            return View();
        }

        // Get
        public PartialViewResult Register()
        {
            ViewBag.User = Session["user"];
            ViewBag.Action = "PostUser";
            return PartialView();
        }
        public JsonResult PostUser(UserVM userVM)
        {
            string message = "";
            var user = new User()
            {
                Name = userVM.Name,
                Email = userVM.Email,
                Password = userVM.Password,
                Address = userVM.Address,
                Phone = userVM.Phone,
                RoleFK = (int)CommonEnum.Role.Customer,
                CreationDate = DateTime.Now,
                IsActive = true
            };
            bool result = userDAL.Add(user, out message);
            if (result)
            {
                Session["user"] = user;
            }
            return Json(new { done = result, 
                message},
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult EmailExists(string email)
        {
            return Json(!(userDAL.getByEmail(email) == null),
                JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Login()
        {

            return PartialView();
        }

        [HttpPost]
        public JsonResult Login(UserVM userVM)
        {
            var user = new User()
            {
                Email = userVM.Email,
                Password = userVM.Password
            };

            string message = "";
            bool result;
            if (Session["user"] != null)
            {
                message = "Aready Logined";
                result = false;
            }
            else
            {
                result = userDAL.Login(ref user, out message);
                if (result)
                {
                    Session["user"] = user;
                }
            }
            return Json(new { done = result, message, name = user.Name },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Edit()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index","Home");
            }
            UserVM obj = new UserVM()
            {
                ID = user.ID,
                IsActive = user.IsActive,
                Name = user.Name,
                Password = user.Password,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
                UpdatedBy = user.UpdatedBy,
                CreationDate = user.CreationDate
            };
            ViewBag.Action = "PostEdit";
            return PartialView("Register",obj);
        }

        [HttpPost]
        public JsonResult PostEdit(UserVM userVM)
        {
            string message = "";
            var obj = new User()
            {
                IsActive = userVM.IsActive,
                ID = userVM.ID,
                Name = userVM.Name,
                Password = userVM.Password,
                Address = userVM.Address,
                Phone = userVM.Phone,
                Email = userVM.Email,
                UpdatedBy = ((User)Session["User"]).ID,
                UpdatedDate = DateTime.Now,
                CreationDate = userVM.CreationDate
            };
            var result = userDAL.Edit(obj, out message);
            if (result)
            {
                Session["user"] = userDAL.GetOne(userVM.ID);
            }
            return Json(
                new { done = result, message },
                JsonRequestBehavior.AllowGet);
        }
    }
}