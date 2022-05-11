using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class BillDetail
    {
        public int id { get; set; }
        public int billId { get; set; }
        public int productId { get; set; }
        public int numberOfProduct { get; set; }
        public string unit { get; set; }
        public double? totalPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
        public BillDetail() { }
    }
}
