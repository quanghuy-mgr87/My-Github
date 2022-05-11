using DemoEntityFrameworkCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoEntityFrameworkCore.Service
{
    public class ProductService : IProductService
    {
        private AppDbContext appDbContext { get; }
        public ProductService()
        {
            appDbContext = new AppDbContext();
        }
        public IEnumerable<Product> GetProducts(string keywords = null)
        {
            var query = appDbContext.Products.AsQueryable();
            if (!string.IsNullOrEmpty(keywords))
            {
                keywords = keywords.ToLower();
                query = query.Where(product => product.ProductName.ToLower().Contains(keywords));
            }
            return query;
        }
        public Product GetProductById(int productId)
        {
            var product = appDbContext.Products.Find(productId);
            //var product = appDbContext.Products.FirstOrDefault(product => product.Id == productId);
            return product;
        }
        public Product CreateProduct(Product product)
        {
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int productId)
        {
            if (appDbContext.Products.Any(product => product.Id == productId))
            {
                var currentProduct = GetProductById(productId);
                appDbContext.Products.Remove(currentProduct);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Product {productId} is not exist!");
            }
        }

        public Product UpdateProduct(Product product, int productId)
        {
            if (appDbContext.Products.Any(product => product.Id == productId))
            {
                var currentProduct = GetProductById(productId);
                currentProduct.ProductName = product.ProductName;
                currentProduct.Price = product.Price;
                currentProduct.CategoryId = product.CategoryId;
                appDbContext.Products.Update(currentProduct);
                appDbContext.SaveChanges();
                return currentProduct;
            }
            else
            {
                throw new Exception($"Product {productId} is not exist!");
            }
        }
    }
}
