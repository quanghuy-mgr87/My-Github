using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 受発注単位マスター表示用　エンティティ
    public class DispUnit
    {
        public int UnitId { get; set; }

        [DisplayName("受発注単位コード")]
        public int UnitCode { get; set; }

        [DisplayName("受発注単位名称")]
        public string UnitName { get; set; }

        [DisplayName("受発注単位カナ")]
        public string UnitKana { get; set; }

        [DisplayName("個数")]
        public int NumberOfComponent { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
