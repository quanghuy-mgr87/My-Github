using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    // 売上管理表示用　エンティティ
    public class DispSale
    {
        public int SaleId { get; set; }

        [DisplayName("売上番号")]
        public int SaleNo { get; set; }

        [DisplayName("販売店")]
        public string SaleShop { get; set; }

        [DisplayName("販売担当者")]
        public string PersonInCharge { get; set; }

        [DisplayName("レシート番号")]
        public string ReceiptNo1 { get; set; }

        [DisplayName("明細番号")]
        public int SaleDetailNo { get; set; }

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

        [DisplayName("売上日時")]
        public DateTime? SaleDateTime { get; set; }

        [DisplayName("領収書番号")]
        public string ReceiptNo2 { get; set; }

        [DisplayName("在庫処理情報")]
        public string StockManagementInfo { get; set; }

        [DisplayName("ロック情報")]
        public string LockInfo { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
