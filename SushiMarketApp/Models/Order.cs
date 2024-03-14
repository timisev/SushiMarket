using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SushiMarketApp.Models
{ 
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите адрес")]
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; } 
        public string Flat { get; set; } 
        public string Floor { get; set; } 
        public string? Comment { get; set; }
    }
}
