using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 消費税マスター表示用　エンティティ
    public class M_DispTax
    {
        [DisplayName("消費税ID")]
        public int TaxID { get; set; }

        [DisplayName("消費税率")]
        public int Tax { get; set; }

        [DisplayName("変更日")]
        public DateTime? ModifyDate { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
