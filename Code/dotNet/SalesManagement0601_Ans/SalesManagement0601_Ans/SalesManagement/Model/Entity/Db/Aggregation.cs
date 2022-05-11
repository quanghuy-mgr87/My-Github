using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 集計　エンティティ
    public class Aggregation
    {
        public int AggregationId { get; set; }
        public int AggregationCode { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int TotalPrice { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
