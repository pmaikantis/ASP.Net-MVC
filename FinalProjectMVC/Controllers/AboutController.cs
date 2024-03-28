using Microsoft.AspNetCore.Mvc;

namespace FinalProjectMVC.Controllers
{
    public class AboutController : Controller
    {
        public async Task <IActionResult> Index()
        {
            return View();
        }
    }
}
