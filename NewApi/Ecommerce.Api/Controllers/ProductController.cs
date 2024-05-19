using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.DataAcces;
using Ecommerce.Api.DataAcces.Interfaces;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IDataAccess _dataAccess;

        public ProductController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        [HttpPost("GetRecentOrderByCustomer")]
        public IActionResult GetRecentOrderByCustomer(GetOrderRequest orderRequest)
        {

            var result = _dataAccess.GetOrderDetailsByCustomer(orderRequest);
            return Ok(result);
        }

    }
}