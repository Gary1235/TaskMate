using Microsoft.AspNetCore.Mvc;

namespace TaskMate.Web.Areas.Schedule.Controllers
{
    [Area("Schedule")]
    public class TodoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TodoDetail()
        {
            return View();
        }
    }
}
