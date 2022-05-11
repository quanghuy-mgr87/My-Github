using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // メーカーマスター表示用　エンティティ
    public class DispMaker
    {
        public int MakerId { get; set; }

        [DisplayName("メーカーコード")]
        public int MakerCode { get; set; }

        [DisplayName("メーカー名")]
        public string MakerName { get; set; }

        [DisplayName("メーカーカナ")]
        public string MakerKana { get; set; }

        [DisplayName("連絡先")]
        public string ContactNo { get; set; }

        [DisplayName("担当者")]
        public string PersonInCharge { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
