using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 売上管理　エンティティ
    public class Sale
    {
        public int SaleId { get; set; }
        public int SaleNo { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        public int SaleShopsId { get; set; }
        public virtual ICollection<Shop> SaleShops { get; set; }
        public int PersonInChargesId { get; set; }
        public virtual ICollection<Staff> PersonInCharges { get; set; }
        public string ReceiptNo1 { get; set; }
        public int TaxsId { get; set; }
        public virtual ICollection<Tax> Taxs { get; set; }
        public DateTime? SaleDateTime { get; set; }
        public int StockManagementInfo { get; set; }
        public int LockInfo { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
