using DemoEntityFrameworkCore.Entities;
using DemoEntityFrameworkCore.Service;
using System;
using System.Linq;

namespace DemoEntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            IProductService productService = new ProductService();
            do
            {
                Console.WriteLine("Chon chuc nang:");
                Console.WriteLine("1. Lay danh sach san pham.");
                Console.WriteLine("2. Lay san pham theo Id.");
                Console.WriteLine("3. Tao san pham.");
                Console.WriteLine("4. Cap nhat san pham.");
                Console.WriteLine("5. Xoa san pham.");
                Console.WriteLine("6. Thoat.");
                Console.Write("Chon: ");
                var chucNang = Console.ReadLine();
                switch (chucNang)
                {
                    case "1":
                        {
                            Console.Write("Nhap tu khoa tim kiem: ");
                            var keyword = Console.ReadLine();
                            var products = productService.GetProducts(keyword);
                            int i = 1;
                            Console.WriteLine($"Danh sach san pham: {products.Count()} san pham duoc tim thay.");
                            foreach (var val in products)
                            {
                                Console.WriteLine($"{i}. Product Id: {val.Id}, product name: {val.ProductName}, price: {val.Price}, category Id: {val.CategoryId}.");
                                i++;
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Nhap Id cua san pham: ");
                            var productId = int.Parse(Console.ReadLine());
                            var product = productService.GetProductById(productId);
                            Console.WriteLine($"Product Id: {product.Id}, product name: {product.ProductName}, price: {product.Price}, category Id: {product.CategoryId}.");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Tao san pham:");
                            var productNew = new Product();
                            Console.Write("Ten san pham: ");
                            productNew.ProductName = Console.ReadLine();
                            Console.Write("Gia san pham: ");
                            productNew.Price = float.Parse(Console.ReadLine());
                            Console.Write("Category Id: ");
                            productNew.CategoryId = int.Parse(Console.ReadLine());
                            productNew = productService.CreateProduct(productNew);
                            Console.WriteLine($"Product Id: {productNew.Id}, product name: {productNew.ProductName}, price: {productNew.Price}, category Id: {productNew.CategoryId}.");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Cap nhat san pham:");
                            var productUpdate = new Product();
                            Console.Write("Nhap Id: ");
                            productUpdate.Id = int.Parse(Console.ReadLine());
                            Console.Write("Ten san pham: ");
                            productUpdate.ProductName = Console.ReadLine();
                            Console.Write("Gia san pham: ");
                            productUpdate.Price = float.Parse(Console.ReadLine());
                            Console.Write("Category Id: ");
                            productUpdate.CategoryId = int.Parse(Console.ReadLine());
                            productUpdate = productService.UpdateProduct(productUpdate, productUpdate.Id);
                            Console.WriteLine($"Product Id: {productUpdate.Id}, product name: {productUpdate.ProductName}, price: {productUpdate.Price}, category Id: {productUpdate.CategoryId}.");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Xoa san pham:");
                            Console.Write("Nhap Id san pham: ");
                            var productIdDelete = int.Parse(Console.ReadLine());
                            productService.DeleteProduct(productIdDelete);
                            Console.WriteLine($"Da xoa san pham Id: {productIdDelete}");
                            break;
                        }
                    case "6":
                        {
                            exit = true;
                            break;
                        }
                }
            } while (!exit);
            Console.ReadKey();
        }
    }
}
