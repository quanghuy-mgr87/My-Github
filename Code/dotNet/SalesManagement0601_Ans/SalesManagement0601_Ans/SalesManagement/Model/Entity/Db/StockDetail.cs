using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    public class StockDetail
    {
        public int StockDetailId { get; set; }
        public int ShopsId { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public long ItemsId { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int StorageNo { get; set; }
        public int Price { get; set; }
        public int TaxsId { get; set; }
        public virtual ICollection<Tax> Taxs { get; set; }
        public bool Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
