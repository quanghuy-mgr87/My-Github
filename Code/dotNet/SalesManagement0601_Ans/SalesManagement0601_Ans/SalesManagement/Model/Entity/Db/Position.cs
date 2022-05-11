using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 役職マスター　エンティティ
    public class Position
    {
        public int PositionId { get; set; }
        public int PositionCode { get; set; }
        public string PositionName { get; set; }
        public string PositionKana { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
