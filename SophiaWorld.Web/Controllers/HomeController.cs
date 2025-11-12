using Microsoft.AspNetCore.Mvc;

namespace SophiaWorld.Web.Controllers
{
    public class HomeController : Controller
    {
        // 기본 홈 페이지
        public IActionResult Index()
        {
            // 단순히 뷰 반환
            return View();
        }

        // 소개 페이지 (About)
        public IActionResult About()
        {
            return View();
        }

        // 에러 페이지 (기본 제공용)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
