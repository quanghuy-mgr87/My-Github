using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 消費税マスター　エンティティ
    public class Tax
    {
        public int TaxId { get; set; }
        public int TaxCode { get; set; }
        public int TaxValue { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
