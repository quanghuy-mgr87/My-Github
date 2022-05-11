using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    public class DispSupplier
    {
        public int SupplierId { get; set; }

        [DisplayName("サプライヤーコード")]
        public int SupplierCode { get; set; }

        [DisplayName("サプライヤー名")]
        public string SupplierName { get; set; }

        [DisplayName("サプライヤーカナ")]
        public string SupplierKana { get; set; }

        [DisplayName("営業所名")]
        public string OfficeName { get; set; }

        [DisplayName("営業所カナ")]
        public string OfficeKana { get; set; }

        [DisplayName("郵便番号")]
        public string PostCode { get; set; }

        [DisplayName("住所")]
        public string Address { get; set; }

        [DisplayName("住所カナ")]
        public string AddressKana { get; set; }

        [DisplayName("連絡先")]
        public string ContactNo { get; set; }

        [DisplayName("メール")]
        public string Mail { get; set; }

        [DisplayName("所属")]
        public string Division { get; set; }

        [DisplayName("担当者")]
        public string PersonInCharge { get; set; }

        [DisplayName("電話番号")]
        public string Phone { get; set; }

        [DisplayName("携帯番号")]
        public string SmartPhone { get; set; }

        [DisplayName("個人メール")]
        public string PersonalMail { get; set; }

        [DisplayName("支払条件")]
        public string PaymentTerms { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
