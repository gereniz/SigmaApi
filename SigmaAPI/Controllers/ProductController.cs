using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SigmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Bilgisayar",
                Price = 5.00
            },
            new Product
            {
                Id = 1,
                Name = "Bilgisayar",
                Price = 5.00
            },
            new Product
            {
                Id = 1,
                Name = "Bilgisayar",
                Price = 5.00
            },
            new Product
            {
                Id = 1,
                Name = "Bilgisayar",
                Price = 5.00
            },
            new Product
            {
                Id = 1,
                Name = "Bilgisayar",
                Price = 5.00
            },
        };

        //Listeleme
        [HttpGet("getall")]
        public List<Product> GetAll()
        {
            var users = products.ToList();
            return users;
        }

    }
}
