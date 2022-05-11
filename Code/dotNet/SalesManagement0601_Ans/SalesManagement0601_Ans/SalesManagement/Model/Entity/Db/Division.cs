using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 部署マスター　エンティティ
    public class Division
    {
        public int DivisionId { get; set; }
        public int DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string DivisionKana { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
