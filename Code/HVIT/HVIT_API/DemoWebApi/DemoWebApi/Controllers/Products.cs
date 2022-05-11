using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product{Id=1, price = 1000, productName="Product 1"},
            new Product{Id=2, price = 2000, productName="Product 2"},
            new Product{Id=3, price = 3000, productName="Product 3"}
        };


        [Route("")] // /api/Product
        //dùng phương thức get để hiển thị danh sách products
        [HttpGet]
        public IActionResult GetProducts()
        {
            //Ok là trả về mã 200
            return Ok(_products);
        }

        [Route("{productId}")] // /api/Product/1
        [HttpGet]
        public IActionResult GetProductsById(int productId)
        {
            var product = _products.Find(x => x.Id == productId);
            if (product == null)
            {
                return BadRequest($"Product {productId} is not exist!");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var maxId = _products.Max(x => x.Id);
            product.Id = maxId + 1;
            _products.Add(product);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var currentProduct = _products.Find(x => x.Id == product.Id);
            if (currentProduct == null)
                return BadRequest($"Product {product.Id} is not exist!");
            currentProduct.productName = product.productName;
            currentProduct.price = product.price;
            return Ok(currentProduct);
        }

        [Route("{productId}")]  // /api/Product/1
        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            var index = _products.FindIndex(x => x.Id == productId);
            if (index == -1)
            {
                return BadRequest($"Product {productId} is not exist!");
            }
            _products.RemoveAt(index);
            return Ok();
        }
    }
}
