using System;
using System.Collections.Generic;

namespace Closure.ECommerceShipping.Api.Controllers
{
    public class GetProductsFilter
    {
        public List<string> Ids { get; set; }
        public DateTime OrderDate { get; set; }
    }
}