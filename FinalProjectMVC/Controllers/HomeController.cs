using FinalProjectMVC.Models.DTO;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sterm = "", int categoryId = 0)
        {
            IEnumerable<Fragrance> fragrances = await _homeRepository.GetFragrances(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            FragranceDisplayModel fragranceModel = new FragranceDisplayModel
            {
                Fragrances = fragrances,
                Categories = categories,
                STerm = sterm,
                CategoryId = categoryId
            };
            return View(fragranceModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
