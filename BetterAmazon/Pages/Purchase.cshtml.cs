using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterAmazon.Infrastructure;
using BetterAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterAmazon.Pages
{
    // This model is responsible for working with the Purchase page. It allows us to interact with the repository and add and remove information on the page.
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;

        public PurchaseModel (IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookID);
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.AddItem(book, 1);
            HttpContext.Session.SetJson("Cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(b => b.Book.BookID == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
