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
                Price = 10000.00
            },
            new Product
            {
                Id = 2,
                Name = "Telefon",
                Price = 7000.00
            },
            new Product
            {
                Id = 3,
                Name = "Cüzdan",
                Price = 100.00
            },
            new Product
            {
                Id = 4,
                Name = "Ayakkabı",
                Price = 300.00
            },
            new Product
            {
                Id = 5,
                Name = "Pantolon",
                Price = 200.00
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
