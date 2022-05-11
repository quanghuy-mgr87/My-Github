using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    // 店舗マスター表示用　エンティティ
    public class DispShop
    {
        public int ShopId { get; set; }

        [DisplayName("店舗コード")]
        public int ShopCode { get; set; }

        [DisplayName("店舗名")]
        public string ShopName { get; set; }

        [DisplayName("店舗カナ")]
        public string ShopKana { get; set; }

        [DisplayName("郵便番号")]
        public string PostCode { get; set; }

        [DisplayName("住所")]
        public string Address { get; set; }

        [DisplayName("住所カナ")]
        public string AddressKana { get; set; }

        [DisplayName("電話番号")]
        public string Phone { get; set; }

        [DisplayName("メール")]
        public string Mail { get; set; }

        [DisplayName("スタッフ")]
        public string Staff { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        [DisplayName("有効")]
        public string Status { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
