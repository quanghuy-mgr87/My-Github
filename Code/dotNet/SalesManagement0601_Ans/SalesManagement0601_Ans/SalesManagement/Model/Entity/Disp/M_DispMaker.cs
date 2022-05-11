using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // メーカーマスター表示用　エンティティ
    public class M_DispMaker
    {
        [DisplayName("メーカーID")]
        public int MakerID { get; set; }

        [DisplayName("メーカー名")]
        public string MakerName { get; set; }

        [DisplayName("メーカーカナ名")]
        public string MakerKana { get; set; }

        [DisplayName("削除フラグ")]
        public string DelFLG { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
