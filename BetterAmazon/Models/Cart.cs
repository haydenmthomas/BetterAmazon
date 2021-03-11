using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterAmazon.Models
{
    //This is our cart, so all of the information about what makes up the cart and what the cart does is stored here. This works in tandem with the repo and the purchase page model to produce the cart.
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book book, int quantity)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookID == book.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotalSum() => Lines.Sum(e => e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }

            public Book Book { get; set; }

            public int Quantity { get; set; }
        }
    }
}
