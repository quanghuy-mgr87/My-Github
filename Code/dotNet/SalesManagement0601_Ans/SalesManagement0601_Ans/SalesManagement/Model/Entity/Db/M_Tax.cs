using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 消費税マスター　エンティティ
    public class M_Tax
    {
        [Key]
        [DisplayName("消費税ID")]
        public int TaxID { get; set; }

        [DisplayName("消費税率")]
        public int Tax { get; set; }

        [DisplayName("変更日")]
        public DateTime? ModifyDate { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
