using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEntityFrameworkCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
