using Microsoft.AspNetCore.Mvc;
using SushiMarketApp.Infrastructure;
using SushiMarketApp.Models;
using SushiMarketApp.Models.ViewModels;

namespace SushiMarketApp.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart) 
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
