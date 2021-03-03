using System;
using System.Linq;
using BetterAmazon.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetterAmazon.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository _repo;

        public NavigationMenuViewComponent(IBookRepository repo)
        {
            _repo = repo;
        }

        //Creates the class to work with the category to build the filter menu
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_repo.Books
                   .Select(x => x.Category)
                   .Distinct()
                   .OrderBy(x => x));
        }
    }
}