using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 役職マスター表示用　エンティティ
    public class DispPosition
    {
        public int PositionId { get; set; }

        [DisplayName("役職コード")]
        public int PositionCode { get; set; }

        [DisplayName("役職名")]
        public string PositionName { get; set; }

        [DisplayName("役職カナ")]
        public string PositionKana { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
