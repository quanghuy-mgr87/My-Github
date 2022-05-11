using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 商品マスター表示用　エンティティ
    class M_DispItem
    {
        [DisplayName("商品コード")]
        public string ItemCD { get; set; }

        [DisplayName("商品名")]
        public string ItemName { get; set; }

        [DisplayName("商品名カナ名")]
        public string ItemKana { get; set; }

        [DisplayName("型番")]
        public string ModelNo { get; set; }

        [DisplayName("JAN_CD")]
        public string JanCD { get; set; }

        [DisplayName("定価")]
        public string ListPrice { get; set; }

        [DisplayName("店頭販売単価")]
        public string SellingPrice { get; set; }

        [DisplayName("メーカー")]
        public string Maker { get; set; }

        [DisplayName("カテゴリー")]
        public string Category { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
