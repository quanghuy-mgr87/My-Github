using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    class DispOrderDetail
    {
        public int OrderDetailId { get; set; }

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

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
