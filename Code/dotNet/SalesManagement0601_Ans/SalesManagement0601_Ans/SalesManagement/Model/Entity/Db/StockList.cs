using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 在庫リスト　エンティティ
    public class StockList
    {
        public int StockListId { get; set; }
        public int StockNo { get; set; }
        public int ShopsId { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public long ItemsId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int Pcs { get; set; }
        public int TotalPrice { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
