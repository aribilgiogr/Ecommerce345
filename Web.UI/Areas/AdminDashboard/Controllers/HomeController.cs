using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
