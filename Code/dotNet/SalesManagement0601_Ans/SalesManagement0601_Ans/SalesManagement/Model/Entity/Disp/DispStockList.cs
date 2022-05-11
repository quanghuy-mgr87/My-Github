using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    public class DispStockList
    {
        public int StockListId { get; set; }

        [DisplayName("在庫番号")]
        public int StockNo { get; set; }

        [DisplayName("店舗")]
        public string Shop { get; set; }

        [DisplayName("商品")]
        public string Item { get; set; }

        [DisplayName("数量")]
        public string Pcs { get; set; }

        [DisplayName("合計金額")]
        public string TotalPrice { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
