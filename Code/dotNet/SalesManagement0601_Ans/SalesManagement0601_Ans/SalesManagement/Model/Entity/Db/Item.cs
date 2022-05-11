using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 商品マスター　エンティティ
    public class Item
    {
        public int ItemId { get; set; }
        public long ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemKana { get; set; }
        public string ModelNo { get; set; }
        public int MakersId { get; set; }
        public virtual ICollection<Maker> Makers { get; set; }
        public int ListPrice { get; set; }
        public int SellingPrice { get; set; }
        public int PurchasePrice { get; set; }
        public long CategorysId { get; set; }
        public virtual ICollection<Category> Categorys { get; set; }
        public int MinimumStock { get; set; }
        public int OrderQuantity { get; set; }
        public int UnitsId { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
