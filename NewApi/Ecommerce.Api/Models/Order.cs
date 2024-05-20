using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Models
{
    public class Order
    {
    public int OrderId { get; set; }
    public string CustomerId { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryExpected { get; set; }
    public bool ContainsGift { get; set; }

    }
}