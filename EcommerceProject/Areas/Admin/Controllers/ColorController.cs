using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.DAL;
using EcommerceProject.VM;
using EcommerceProject.Models;

namespace EcommerceProject.Areas.Admin.Controllers
{
    //Yasser
    public class ColorController : Controller
    {
        ColorDAL colorDAL = new ColorDAL();
        // GET: Admin/Color
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AddForm()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult PostColor(ColorVM colorVM)
        {
            string message;
            var obj = new Color()
            {
                Name = colorVM.Name,
                Code = colorVM.Code,
                CreatedBy = 2,
                CreationDate = DateTime.Now
            };
            return Json(
                new
                {
                    done = colorDAL.Add(obj, out message),
                    message
                }
                ,
                JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult ColorData()
        {
            return PartialView(colorDAL.GetAll());
        }
    }
}