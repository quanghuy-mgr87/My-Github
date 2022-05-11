using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 売上明細管理　エンティティ
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleDetailNo { get; set; }
        public long ItemsId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int Quantity { get; set; }
        public int UnitsId { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int SaleNo { get; set; }
        public string ReceiptNo2 { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
