

namespace SushiMarketApp.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> Products => context.Products;

        public void AddProduct(Product product)
        {
            if(product != null)
            {
                context.Add(product);
                context.SaveChanges();
            }
        }

        public Product DeleteProduct(int productID)
        {
            var dbEntry = context.Products.FirstOrDefault(p => p.ProductID == productID);

            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
