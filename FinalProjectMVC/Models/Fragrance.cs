using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//using Humanizer.Localisation;

namespace FinalProjectMVC.Models
{
    [Table("Fragrance")]
    public class Fragrance
    { 
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Perfumer { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartDetail> CartDetails { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

    }
}