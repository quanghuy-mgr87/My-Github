using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Model.Entity.Db
{
    // 仕入テーブル　エンティティ
    public class T_DispPurchase
    {
        [Key]
        [DisplayName("仕入伝票番号")]
        public int PurcaseNo { get; set; }

        [DisplayName("発注伝票番号")]
        public int PlaOrderNo { get; set; }

        [DisplayName("発注明細番号")]
        public int PlaOrderListNo { get; set; }
        // public virtual T_PlaceOrderList PlaOrderList { get; set; }

        [DisplayName("店舗ID")]
        public int ShopID { get; set; }

        [DisplayName("商品CD")]
        [StringLength(8)]
        public string ItemCD { get; set; }

        [DisplayName("仕入単価")]
        public int PurchasePrice { get; set; }

        [DisplayName("仕入数")]
        public int Quantity { get; set; }

        [DisplayName("仕入先ID")]
        public int VenderID { get; set; }

        [DisplayName("消費税ID")]
        public int TaxID { get; set; }

        [DisplayName("入荷日")]
        public DateTime? ArrivalDate { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Remarks { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }

        // ナビゲーションプロパティ
        public virtual M_Vender Vender { get; set; }
        public virtual M_Item Item { get; set; }
        public virtual M_Shop Shop { get; set; }
    }
}
