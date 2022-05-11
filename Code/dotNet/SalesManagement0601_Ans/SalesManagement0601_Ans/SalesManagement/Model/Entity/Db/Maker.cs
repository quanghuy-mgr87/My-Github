using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // メーカーマスター　エンティティ
    public class Maker
    {
        public int MakerId { get; set; }
        public int MakerCode { get; set; }
        public string MakerName { get; set; }
        public string MakerKana { get; set; }
        public string ContactNo { get; set; }
        public string PersonInCharge { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
