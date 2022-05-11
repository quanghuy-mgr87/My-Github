using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Model.Entity.Db
{
    // 部署マスター　エンティティ
    public class M_Division
    {
        [Key]
        [DisplayName("部署ID")]
        public int DivisionID { get; set; }

        [DisplayName("部署名")]
        [StringLength(50)]
        public string DivisionName { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

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
