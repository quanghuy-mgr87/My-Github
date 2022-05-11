using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    public class DispStock
    {
        public int StockId { get; set; }

        [DisplayName("トランザクション番号")]
        public long TransactionNo { get; set; }

        [DisplayName("処理")]
        public string Operation { get; set; }

        [DisplayName("入庫番号")]
        public int StorageNo { get; set; }

        [DisplayName("処理日時")]
        public DateTime? OperationDateTime { get; set; }

        [DisplayName("店舗")]
        public string Shop { get; set; }

        [DisplayName("移動先店舗")]
        public string DestinationShop { get; set; }

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

        [DisplayName("消費税")]
        public string Tax { get; set; }

        [DisplayName("伝票番号")]
        public string VoucherNo { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
