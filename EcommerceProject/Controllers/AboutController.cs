using System.Linq;
using System.Web.Mvc;

namespace EcommerceProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            return View(
                new DAL.AboutUsDAL().GetAll().FirstOrDefault());
        }
    }
}