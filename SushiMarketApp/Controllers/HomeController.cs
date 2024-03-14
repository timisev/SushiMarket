using Microsoft.AspNetCore.Mvc;
using SushiMarketApp.Models; 
using SushiMarketApp.Models.ViewModels; 

namespace SushiMarketApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository; 

        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index(string category = "Роллы")
        {
            return View(new ProductListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category == category)
                    .OrderBy(p => p.ProductID),
                CurrentCategory = category
            });
        } 
         
        // GET: HomeController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = repository.Products.FirstOrDefault(p => p.ProductID == id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
