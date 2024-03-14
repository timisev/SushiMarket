using System.ComponentModel.DataAnnotations;

namespace SushiMarketApp.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
