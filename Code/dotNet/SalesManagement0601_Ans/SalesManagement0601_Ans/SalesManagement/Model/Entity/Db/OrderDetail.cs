using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderDetailNo { get; set; }
        public long ItemsId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int Quantity { get; set; }
        public int UnitsId { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int OrderNo { get; set; }
        public string VoucherNo { get; set; }
        public bool Stored { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
