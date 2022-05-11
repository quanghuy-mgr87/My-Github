using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 店舗マスター　エンティティ
    public class Shop
    {
        public int ShopId { get; set; }
        public virtual ICollection<M_Shop> Shops { get; set; }

        public int ShopCode { get; set; }
        public string ShopName { get; set; }
        public string ShopKana { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string AddressKana { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int StaffsId { get; set; }
        public virtual ICollection<M_Staff> Staffs { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
