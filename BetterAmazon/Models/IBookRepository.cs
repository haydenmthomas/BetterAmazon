using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterAmazon.Models
{
    //Sets repository interface
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
