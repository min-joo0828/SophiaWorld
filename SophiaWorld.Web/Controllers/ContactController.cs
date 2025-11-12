using Microsoft.AspNetCore.Mvc;

namespace SophiaWorld.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
