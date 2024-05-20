using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Models
{
    public class ProductDto
    {
        public string? Product { get; set; }
        public int Qty { get; set; }

        public decimal PriceEach { get; set; }

    }
}