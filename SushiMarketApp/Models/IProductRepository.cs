namespace SushiMarketApp.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void AddProduct(Product product);
        Product DeleteProduct(int ID);
    }
}
