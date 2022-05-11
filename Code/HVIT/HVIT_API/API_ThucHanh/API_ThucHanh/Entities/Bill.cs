using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class Bill
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public string billName { get; set; }
        public string tradingCode { get; set; }
        public DateTime createTime { get; set; }
        public DateTime? updateTime { get; set; }
        public string note { get; set; }
        public double? totalPrice { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
        public Bill() { }
    }
}
