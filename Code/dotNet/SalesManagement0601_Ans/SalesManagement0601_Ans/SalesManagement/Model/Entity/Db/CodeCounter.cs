using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // コードカウンター　エンティティ
    public class CodeCounter
    {
        public int CodeCounterId { get; set; }
        public int CodeId { get; set; }
        public long Counter { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
