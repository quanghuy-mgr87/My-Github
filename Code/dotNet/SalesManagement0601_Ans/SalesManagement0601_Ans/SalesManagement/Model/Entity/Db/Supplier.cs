using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // サプライヤーマスター　エンティティ
    public class Supplier
    {
        public int SupplierId { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierKana { get; set; }
        public string OfficeName { get; set; }
        public string OfficeKana { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string AddressKana { get; set; }
        public string ContactNo { get; set; }
        public string Mail { get; set; }
        public string Division { get; set; }
        public string PersonInCharge { get; set; }
        public string Phone { get; set; }
        public string SmartPhone { get; set; }
        public string PersonalMail { get; set; }
        public string PaymentTerms { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
