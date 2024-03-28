using FinalProjectMVC.Data;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectMVC.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Fragrance>> GetFragrances(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Fragrance> fragrances = await (from fragrance in _db.Fragrances
                                             join category in _db.Categories
                                             on fragrance.CategoryId equals category.Id
                                             where string.IsNullOrWhiteSpace(sTerm) || (fragrance != null && fragrance.Title.ToLower().StartsWith(sTerm))
                                             select new Fragrance
                                             {
                                                 Id = fragrance.Id,
                                                 Image = fragrance.Image,
                                                 Perfumer = fragrance.Perfumer,
                                                 Title = fragrance.Title,
                                                 CategoryId = fragrance.CategoryId,
                                                 Price = fragrance.Price,
                                                 CategoryName = category.CategoryName,

                                             }
                         ).ToListAsync();
            if (categoryId > 0)
            {
                fragrances = fragrances.Where(a => a.CategoryId == categoryId).ToList();
            }
            return fragrances;

        }
    }
}