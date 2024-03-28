using Microsoft.AspNetCore.Mvc;

namespace FinalProjectMVC.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
