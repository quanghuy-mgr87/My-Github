using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // メーカーマスター　エンティティ
    public class M_Maker
    {
        [Key]
        [DisplayName("メーカーID")]
        //[StringLength(3)]
        public int MakerID { get; set; }

        [DisplayName("メーカー名")]
        [StringLength(50)]
        public string MakerName { get; set; }

        [DisplayName("メーカーカナ名")]
        [StringLength(25)]
        public string MakerKana { get; set; }

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
