using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 在庫管理　エンティティ
    public class Stock
    {
        public int StockId { get; set; }
        public long TransactionNo { get; set; }
        public int Operation { get; set; }
        public int StorageNo { get; set; }
        public DateTime? OperationDateTime { get; set; }
        public int ShopsId { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public int DestinationShopsId { get; set; }
        public virtual ICollection<Shop> DestinationShops { get; set; }
        public long ItemsId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int Quantity { get; set; }
        public int UnitsId { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int TaxsId { get; set; }
        public virtual ICollection<Tax> Taxs { get; set; }
        public string VoucherNo { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
