using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Model.Entity.Db
{
    // 発注詳細テーブル　エンティティ
    public class T_DispPlaceOrderList
    {
        [Key, Column(Order = 1)]
        [DisplayName("発注伝票番号")]
        public int PlaOrderListID { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("発注明細番号")]
        public int PlaOrderListNo { get; set; }

        [DisplayName("商品CD")]
        public string ItemCD { get; set; }

        [DisplayName("仕入単価")]
        public int PurchasePrice { get; set; }

        [DisplayName("発注数")]
        public int Quantity { get; set; }

        [DisplayName("入荷予定日")]
        public DateTime? DueInDate { get; set; }

        [DisplayName("消費税ID")]
        public string TaxID { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Remarks { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }

        // ナビゲーションプロパティ
        public virtual T_PlaceOrder PlaceOrder { get; set; }
        public virtual M_Item Item { get; set; }
        // public virtual T_Purchase Purchase { get; set; }
    }
}
