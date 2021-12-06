using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SigmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        static double euro=0;
        bool isEuro = true;
        //Cüzdan
        static Wallet wallets = new Wallet
        {
            SumPrice = 0
        };

        Product product = new Product();

        //Sepetteki ürünlerin listesi
        static public List<Product> productList = new List<Product>();

        //Sepet
        Basket basket = new Basket
        {
            products = productList,
            wallet = wallets
        };



        public string GetApiDate()
        {
            var apiUrl = "http://api.exchangeratesapi.io/v1/latest?access_key=bf8ef69d30c98f7d57a7d29f3a9e325d&symbols=TRY";

            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            
            string json = client.DownloadString(url);
           
            string a = json.Substring(87,json.Length-89);
            
            euro = Convert.ToDouble(a);

            return json;
        }




        //Listeleme
        [HttpGet("getall")]
        public Basket GetAll()
        {
            GetApiDate();
            if(isEuro == true)
            {
                foreach(var p in productList)
                {
                    p.Price = p.Price / euro;
                }
                wallets.SumPrice = wallets.SumPrice / euro;
            }
            return basket;
        }
        
        //Ekleme
        [HttpPost("add")]
        public Basket Add([FromBody] Product newProduct)
        {
          
            product.Id = newProduct.Id;
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            wallets.SumPrice += newProduct.Price;
            productList.Add(product);
            basket.products = productList;
            basket.wallet = wallets;
            
            return basket;
        }

       

        //Silme
        [HttpDelete("remove")]
        public Basket Delete(int id)
        {

            var item = basket.products.SingleOrDefault(b => b.Id == id);
            basket.products.Remove(item);
            basket.wallet.SumPrice -= item.Price;

      
            return basket;

        }
       
        

    }
}
