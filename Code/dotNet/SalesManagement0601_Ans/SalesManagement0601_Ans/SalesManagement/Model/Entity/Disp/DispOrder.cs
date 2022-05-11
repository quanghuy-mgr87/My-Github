using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    public class DispOrder
    {
        public int OrderId { get; set; }

        [DisplayName("発注番号")]
        public int OrderNo { get; set; }

        [DisplayName("件名")]
        public string OrderName { get; set; }

        [DisplayName("発注担当者")]
        public string PersonInCharge { get; set; }

        [DisplayName("納期")]
        public DateTime? DeliveryDateTime { get; set; }

        [DisplayName("発注日時")]
        public DateTime? OrderDateTime { get; set; }

        [DisplayName("サプライヤー")]
        public string Supplier { get; set; }

        [DisplayName("納品店舗")]
        public string DeliveredShop { get; set; }

        [DisplayName("明細番号")]
        public int OrderDetailNo { get; set; }

        [DisplayName("商品")]
        public string Item { get; set; }

        [DisplayName("数量")]
        public string Quantity { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }

        [DisplayName("単価")]
        public string Price { get; set; }

        [DisplayName("合計金額")]
        public string TotalPrice { get; set; }

        [DisplayName("税率(%)")]
        public string Tax { get; set; }

        [DisplayName("伝票番号")]
        public string VoucherNo { get; set; }

        [DisplayName("入庫状況")]
        public bool Stored { get; set; }

        [DisplayName("印刷ステータス")]
        public int PrintStatus { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
