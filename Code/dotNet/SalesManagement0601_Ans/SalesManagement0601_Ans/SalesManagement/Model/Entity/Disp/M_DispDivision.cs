using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Disp
{
    // 部署マスター表示用　エンティティ
    public class M_DispDivision
    {
        [DisplayName("部署ID")]
        public int DivisionID { get; set; }

        [DisplayName("部署名")]
        public string DivisionName { get; set; }

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
