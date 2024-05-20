using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Models
{
    public class GetOrderRequest
    {
        public string? User { get; set; }
        public string? CustomerId { get; set; }
        
    }
}