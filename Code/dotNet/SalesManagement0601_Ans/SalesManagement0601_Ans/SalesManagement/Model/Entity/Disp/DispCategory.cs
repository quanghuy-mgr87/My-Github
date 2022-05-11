using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // カテゴリーマスター表示用　エンティティ
    public class DispCategory
    {
        public int CategoryId { get; set; }

        [DisplayName("カテゴリーコード")]
        public long CategoryCode { get; set; }

        [DisplayName("親カテゴリー")]
        public string ParentCategory { get; set; }

        [DisplayName("カテゴリー名")]
        public string CategoryName { get; set; }

        [DisplayName("カテゴリーカナ")]
        public string CategoryKana { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
