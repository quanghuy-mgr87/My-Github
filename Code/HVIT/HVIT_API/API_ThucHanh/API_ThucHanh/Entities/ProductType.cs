using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class ProductType
    {
        public int id { get; set; }
        public string typeName { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public ProductType() { }
    }
}
