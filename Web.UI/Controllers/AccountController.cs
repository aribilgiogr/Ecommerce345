using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
