using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // カテゴリーマスター　エンティティ
    public class M_Category
    {
        [Key]
        [DisplayName("カテゴリーCD")]
        [StringLength(3)]
        public string CategoryCD { get; set; }

        [DisplayName("親カテゴリーCD")]
        [StringLength(3)]
        public string ParentCategory { get; set; }

        [DisplayName("カテゴリー名")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [DisplayName("カテゴリーカナ名")]
        [StringLength(25)]
        public string CategoryKana { get; set; }

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
