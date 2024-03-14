using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SushiMarketApp.Models;

namespace SushiMarketApp.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public IActionResult Edit(int productID) =>
            View(repository.Products.FirstOrDefault(w => w.ProductID == productID));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}