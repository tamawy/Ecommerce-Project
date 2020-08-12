using System.Web.Mvc;
using EcommerceProject.DAL;

namespace EcommerceProject.Controllers
{
    public class ShopController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        BrandDAL brandDAL = new BrandDAL();
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult products()
        {
            return PartialView(productDAL.GetAll());
        }
        public PartialViewResult category()
        {
            return PartialView(new CategoryDAL().GetAll());
        }

        public PartialViewResult filterByCategory(long catID)
        {
            return PartialView("products",
                productDAL.FilterByCategory(catID));
        }

        public PartialViewResult brands()
        {
            return PartialView(brandDAL.GetAll());
        }
        public PartialViewResult filterByBrands(long brandID)
        {
            return PartialView("products", 
                productDAL.FilterByBrand(brandID)
                );
        }
        public PartialViewResult filterByPrice()
        {
            return PartialView();
        }
        public PartialViewResult getElementsByPrice(long price)
        {
            return PartialView("products",
                productDAL.FilterByPrice(price));
        }

        public PartialViewResult filterByColor()
        {
            return PartialView();
        }
        public PartialViewResult getElementByColor(long id)
        {
            return PartialView("products",
                productDAL.FilterByColor(id));
        }
    }
}