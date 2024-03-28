using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task<IActionResult> AddItem(int fragranceId, int qty = 1, int redirect = 0)
        {
            var cartCount = await _cartRepo.AddItem(fragranceId, qty);
            if (redirect == 0)
                return Ok();
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int fragranceId)
        {
            var cartCount = await _cartRepo.RemoveItem(fragranceId);
            return RedirectToAction("GetUserCart");
            // return View();
        }

        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepo.GetUserCart();
            return View(cart);
        }
        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }
        public async Task<IActionResult> Checkout()
        {
            bool isCheckedOut = await _cartRepo.DoCheckout();
            if (!isCheckedOut)
                throw new Exception("Something happened on server side");
            return RedirectToAction("Index", "Home");
        }



        public IActionResult UserOrders()
        {
            
            return View();
        }
    }

    internal class CartItem
    {
    }
}