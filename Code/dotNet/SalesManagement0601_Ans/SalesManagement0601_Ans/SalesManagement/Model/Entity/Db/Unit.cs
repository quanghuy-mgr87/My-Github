using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 受発注単位マスター　エンティティ
    public class Unit
    {
        public int UnitId { get; set; }
        public int UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitKana { get; set; }
        public int NumberOfComponent { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
