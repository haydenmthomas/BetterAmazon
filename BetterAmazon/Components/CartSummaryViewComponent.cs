using System;
using BetterAmazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetterAmazon.Components
{
    //Allows us to use the view cart summary view compnant on any page we want.
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent (Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
