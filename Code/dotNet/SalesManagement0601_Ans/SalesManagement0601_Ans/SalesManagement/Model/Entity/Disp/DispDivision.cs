using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 部署マスター表示用　エンティティ
    public class DispDivision
    {
        public int DivisionId { get; set; }

        [DisplayName("部署コード")]
        public int DivisionCode { get; set; }

        [DisplayName("部署名")]
        public string DivisionName { get; set; }

        [DisplayName("部署カナ")]
        public string DivisionKana { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
