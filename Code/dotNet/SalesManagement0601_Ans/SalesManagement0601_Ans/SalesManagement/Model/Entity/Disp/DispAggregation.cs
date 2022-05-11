using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    // 集計表示用　エンティティ
    public class DispAggregation
    {
        public int AggregationId { get; set; }

        [DisplayName("集計コード")]
        public int AggregationCode { get; set; }

        [DisplayName("年")]
        public string Year { get; set; }

        [DisplayName("月")]
        public string Month { get; set; }

        [DisplayName("日")]
        public string Day { get; set; }

        [DisplayName("合計金額")]
        public string TotalPrice { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
