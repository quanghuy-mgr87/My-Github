using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity.Db
{
    // 従業員マスター　エンティティ
    public class Staff
    {
        public int StaffId { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public int StaffCode { get; set; }
        public string StaffName { get; set; }
        public string StaffKana { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string AddressKana { get; set; }
        public string Phone { get; set; }
        public string SmartPhone { get; set; }
        public string Mail { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? HireDate { get; set; }
        public int ShopsId { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public int DivisionsId { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
        public int Position { get; set; }
        public int AccessAuth { get; set; }
        public string UserId { get; set; }
        public byte[] Password { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
