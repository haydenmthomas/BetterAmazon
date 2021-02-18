using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterAmazon.Models
{
    //Creates app respository which inherits the previously made repository interface
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        //Constructs the context for the class
        public EFBookRepository (BookDbContext context)
        {
            _context = context;
        }
        //Allows to query books from database
        public IQueryable<Book> Books => _context.Books;
    }
}
