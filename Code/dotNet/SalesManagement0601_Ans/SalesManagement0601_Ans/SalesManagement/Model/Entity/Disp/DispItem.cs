using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 商品マスター表示用　エンティティ
    class DispItem
    {
        public int ItemId { get; set; }

        [DisplayName("商品コード")]
        public long ItemCode { get; set; }

        [DisplayName("商品名")]
        public string ItemName { get; set; }

        [DisplayName("商品名カナ")]
        public string ItemKana { get; set; }

        [DisplayName("型番")]
        public string ModelNo { get; set; }

        [DisplayName("メーカー")]
        public string Maker { get; set; }

        [DisplayName("定価")]
        public string ListPrice { get; set; }

        [DisplayName("販売価格")]
        public string SellingPrice { get; set; }

        [DisplayName("仕入価格")]
        public string PurchasePrice { get; set; }

        [DisplayName("カテゴリー")]
        public string Category { get; set; }

        [DisplayName("最低在庫数")]
        public int MinimumStock { get; set; }

        [DisplayName("発注数")]
        public int OrderQuantity { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
