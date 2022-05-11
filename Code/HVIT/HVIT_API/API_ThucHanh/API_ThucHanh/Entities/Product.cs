using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class Product
    {
        public int id { get; set; }
        public int productTypeId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string describe { get; set; }
        public DateTime? expirationDate { get; set; }   //ngay het han
        public string productSign { get; set; } //ki hieu san pham
        public virtual ProductType ProductType { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
        public Product() { }
    }
}
