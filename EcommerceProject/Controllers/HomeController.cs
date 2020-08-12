using System.Linq;
using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Controllers
{
    public class HomeController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        public ActionResult Index()
        {
            return View();
        }

        // retrieve the products that will be added at the banner in the home page
        public PartialViewResult Banner()
        {
            var list = productDAL.GetAll().OrderByDescending(z => z.ID).Take(3).ToList();
            return PartialView(list);
        }

        // retrieve the products that will be viewed in the "New Products" area in home page.
        public PartialViewResult NewProducts()
        {
            var list = productDAL.GetAll().OrderByDescending(z => z.ID).Take(5).ToList();
            return PartialView(list);
        }
        
        public PartialViewResult Brands()
        {
            return PartialView(new EcommerceProject.DAL.BrandDAL().GetAll());
        }  

        public PartialViewResult Product()
        {
            return PartialView(productDAL.GetAll().ToList());
        }

        public PartialViewResult Testmonial()
        {
            return PartialView(new ContactMessageDAL().GetAll()
                .Where(z => z.IsAnswer == true).ToList());
        }

    }
}