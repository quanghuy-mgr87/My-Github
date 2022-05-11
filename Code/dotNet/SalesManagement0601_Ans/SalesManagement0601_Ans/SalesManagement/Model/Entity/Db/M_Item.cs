using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 商品マスター　エンティティ
    public class M_Item
    {
        [Key]
        [DisplayName("商品CD")]
        [StringLength(8)]
        public string ItemCD { get; set; }
        public virtual ICollection<T_Purchase> PlaOrderLists { get; set; }
        public virtual ICollection<T_Purchase> Purchases { get; set; }
        public virtual ICollection<T_StockHistory> StocHistorys { get; set; }
        public virtual ICollection<T_Inventory> Inventorys { get; set; }
        public virtual ICollection<T_MoveStock> MoveStocks { get; set; }
        [DisplayName("商品名")]
        [StringLength(50)]
        public string ItemName { get; set; }

        [DisplayName("商品カナ名")]
        [StringLength(25)]
        public string ItemKana { get; set; }

        [DisplayName("型番")]
        [StringLength(30)]
        public string ModelNo { get; set; }

        [DisplayName("JAN_CD")]
        [StringLength(13)]
        public string JanCD { get; set; }

        [DisplayName("定価")]
        // [DisplayFormat(DataFormatString = "{0:#,0}")] --- \マーク無し
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int ListPrice { get; set; }

        [DisplayName("店頭販売単価")]
        // [DisplayFormat(DataFormatString = "{0:#,0}")] --- \マーク無し
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int SellingPrice { get; set; }

        [DisplayName("メーカーID")]
        public int MakerID { get; set; }

        [DisplayName("カテゴリーCD")]
        public string CategoryCD { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
