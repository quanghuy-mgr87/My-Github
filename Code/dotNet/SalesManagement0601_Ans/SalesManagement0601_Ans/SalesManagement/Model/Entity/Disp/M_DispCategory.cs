using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // カテゴリーマスター表示用　エンティティ
    public class M_DispCategory
    {
        [DisplayName("カテゴリーCD")]
        public string CategoryCD { get; set; }

        [DisplayName("親カテゴリーCD")]
        public string ParentCategory { get; set; }

        [DisplayName("カテゴリー名")]
        public string CategoryName { get; set; }

        [DisplayName("カテゴリーカナ名")]
        public string CategoryKana { get; set; }

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
