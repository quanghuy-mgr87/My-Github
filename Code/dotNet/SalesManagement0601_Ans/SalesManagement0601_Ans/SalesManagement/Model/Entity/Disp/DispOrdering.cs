using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    public class DispOrdering
    {
        public int OrderId { get; set; }

        [DisplayName("明細番号")]
        public int OrderDetailNo { get; set; }

        [DisplayName("商品")]
        public string Item { get; set; }

        [DisplayName("型番")]
        public string ModelNo { get; set; }

        [DisplayName("メーカー")]
        public string Maker { get; set; }

        [DisplayName("数量")]
        public string Quantity { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }

        [DisplayName("単価")]
        public string Price { get; set; }

        [DisplayName("合計金額")]
        public string TotalPrice { get; set; }
    }
}
