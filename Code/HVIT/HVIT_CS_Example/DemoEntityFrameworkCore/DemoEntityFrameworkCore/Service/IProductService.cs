using DemoEntityFrameworkCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEntityFrameworkCore.Service
{
    interface IProductService
    {
        IEnumerable<Product> GetProducts(string keywords = null);
        Product GetProductById(int productId);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product, int productId);
        void DeleteProduct(int productId);
    }
}
