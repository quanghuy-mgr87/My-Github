using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 消費税マスター表示用　エンティティ
    public class DispTax
    {
        public int TaxId { get; set; }

        [DisplayName("消費税コード")]
        public int TaxCode { get; set; }

        [DisplayName("税％")]
        public int TaxValue { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
