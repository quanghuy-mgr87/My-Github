using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 発注管理　エンティティ
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public string OrderName { get; set; }
        public int PersonInChargesId { get; set; }
        public virtual ICollection<Staff> PersonInCharges { get; set; }
        public DateTime? DeliveryDateTime { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public int SuppliersId { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public int DeliveredShopsId { get; set; }
        public virtual ICollection<Shop> DeliveredShops { get; set; }
        public int TaxsId { get; set; }
        public virtual ICollection<Tax> Taxs { get; set; }
        public int PrintStatus { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
