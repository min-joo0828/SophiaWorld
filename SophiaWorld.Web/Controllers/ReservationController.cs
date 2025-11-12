using Microsoft.AspNetCore.Mvc;

namespace SophiaWorld.Web.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
