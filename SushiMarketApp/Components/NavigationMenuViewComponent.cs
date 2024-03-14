using Microsoft.AspNetCore.Mvc;
using SushiMarketApp.Models;

namespace SushiMarketApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            this.repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        } 
    }
}  