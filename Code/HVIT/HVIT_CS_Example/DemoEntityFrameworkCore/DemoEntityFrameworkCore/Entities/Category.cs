using System;
using System.Collections.Generic;
using System.Text;

namespace DemoEntityFrameworkCore.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
