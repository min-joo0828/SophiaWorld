using Microsoft.AspNetCore.Mvc;

namespace SophiaWorld.Web.Controllers
{
    public class NoticeController : Controller
    {
        public IActionResult Index()
        {
            // View만 반환 (데이터는 JS로 가져옴)
            return View();
        }
    }
}
