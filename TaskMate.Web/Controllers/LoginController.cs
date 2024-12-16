using Microsoft.AspNetCore.Mvc;

namespace TaskMate.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
