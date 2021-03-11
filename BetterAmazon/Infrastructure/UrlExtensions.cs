using System;
using Microsoft.AspNetCore.Http;

namespace BetterAmazon.Infrastructure
{
    //Sets up the URL extensions used to route inbetween pages for adding to cart.
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
