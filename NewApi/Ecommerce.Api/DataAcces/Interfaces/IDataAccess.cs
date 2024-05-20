using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.Models;

namespace Ecommerce.Api.DataAcces.Interfaces
{
    public interface IDataAccess
    {
     public OrderResponse GetOrderDetailsByCustomer (GetOrderRequest request);

    }
}