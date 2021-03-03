using System;
using System.Collections.Generic;

//Allows us to use multiple models on the page
namespace BetterAmazon.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Category { get; set; }

    }
}
