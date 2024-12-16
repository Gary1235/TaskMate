using Microsoft.AspNetCore.Mvc;

namespace TaskMate.Web.Areas.Weather.Controllers
{
    public class WeatherForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
