
namespace FinalProjectMVC.Models.DTO
{
    public class FragranceDisplayModel
    {
        public IEnumerable<Fragrance> Fragrances { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;

    }
}