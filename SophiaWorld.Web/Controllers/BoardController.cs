using Microsoft.AspNetCore.Mvc;

namespace SophiaWorld.Web.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
