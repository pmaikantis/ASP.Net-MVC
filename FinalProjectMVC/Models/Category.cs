using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectMVC.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? CategoryName { get; set; }
        public List<Fragrance> Fragrances { get; set; }

    }
}