using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Models
{
    public class OrderResponse
    {
        public CustomerDto? customerDtos { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public List<ProductDto>? OrderItems { get; set; }
        public DateTime? DeliveryExpected { get; set; }


        
    }
}