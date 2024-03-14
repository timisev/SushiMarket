namespace SushiMarketApp.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } 
        public string CurrentCategory { get; set; }
    }
}
