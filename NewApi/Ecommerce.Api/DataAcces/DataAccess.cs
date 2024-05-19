using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Api.DataAcces.Interfaces;
using Ecommerce.Api.Models;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Api.DataAcces
{
    public class DataAccess : IDataAccess
    {

        private readonly string _connectionString;

        public DataAccess()
        {
            _connectionString = "Datasourse:localhost;";
        }


        public OrderResponse GetOrderDetailsByCustomer(GetOrderRequest request)
        {
            try
            {
                var output = new OrderResponse();
                var customerId = request.CustomerId;
                var email = request.User;
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var checkUserQuery = $"SELECT CASE  WHEN EXISTS (SELECT 1  FROM Employee  WHERE customerid = {customerId} AND email = {email}) THEN 1  ELSE 0 END AS IsExist";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(checkUserQuery, con);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {

                        if (Convert.ToInt32(result) == 1)
                        {

                            var orderQuery = $"select Top 1  c.firstname,c.lastname c.houseno,c.street,c.townc.postcode,o.orderdate,o.orderid,o.containsgift,o.deliveryexpected from customers c join orders o on c.customerId = o.customerId where c.customerId = {customerId}  order by o.orderdate desc ";
                            cmd = new SqlCommand(orderQuery, con);
                            var orderId = 0;
                            bool isGift = false;
                            DateTime? orderDate = null;
                            DateTime? deliveryExpcted = null;

                            string? firtsName = "";
                            string? LastName = "";
                            string? houseNo = "";
                            string? street = "";
                            string? town = "";
                            string? postCode = "";

                            var reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {

                                orderId = Convert.ToInt32(reader["orderId"]);
                                orderDate = Convert.ToDateTime(reader["orderdate"]);
                                deliveryExpcted = Convert.ToDateTime(reader["deliveryexpected"]);
                                isGift = Convert.ToBoolean(reader["containsgift"]);
                                firtsName = Convert.ToString(reader["firstname"]);
                                LastName = Convert.ToString(reader["firstname"]);
                                houseNo = Convert.ToString(reader["firstname"]);
                                street = Convert.ToString(reader["firstname"]);
                                town = Convert.ToString(reader["firstname"]);
                                postCode = Convert.ToString(reader["firstname"]);

                            }

                            var dataquery = $"SELECT p.productName ,o.Price,o.Quantity FROM orderItems o JOIN products p ON p.productId = o.productId WHERE o.orderid = {orderId}";
                            if (isGift)
                            {
                                dataquery = $"SELECT Price,Quantity FROM orderItems WHERE o.orderid = {orderId}";
                            }
                            cmd = new SqlCommand(dataquery, con);
                            reader = cmd.ExecuteReader();
                            var produtcs = new List<ProductDto>();
                            while (reader.Read())
                            {
                                var prdct = new ProductDto()
                                {

                                    Product = isGift ? "Gift" : reader["ProdutcName"]?.ToString(),
                                    Qty = Convert.ToInt32(reader["Quantity"]),
                                    PriceEach = Convert.ToDecimal(reader["Price"]),
                                };
                                produtcs.Add(prdct);
                            }
                            con.Close();
                            output = new OrderResponse()
                            {
                                customerDtos = new CustomerDto()
                                {
                                    FirstName = firtsName,
                                    LastName = LastName,
                                },
                                OrderDate = orderDate,
                                DeliveryAddress = houseNo + "," + street + "," + town + "," + postCode,
                                DeliveryExpected = deliveryExpcted,
                                OrderItems = produtcs
                            };
                        }
                        else
                        {

                            throw new Exception("User Not Found With given data");
                        }
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}