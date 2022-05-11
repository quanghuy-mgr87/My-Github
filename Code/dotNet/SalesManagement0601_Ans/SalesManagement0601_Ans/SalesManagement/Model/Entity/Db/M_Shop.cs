using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entity.Db
{
    // 店舗マスタ　エンティティ
    public class M_Shop
    {
        [Key]
        [DisplayName("店舗ID")]
        public int ShopID { get; set; }
        public virtual ICollection<T_PlaceOrder> PlaOrders { get; set; }
        public virtual ICollection<M_Staff> Staffs { get; set; }
        public virtual ICollection<T_Purchase> Purchases { get; set; }
        public virtual ICollection<T_Inventory> Inventorys { get; set; }
        public virtual ICollection<T_MoveStock> MoveStocks { get; set; }

        [DisplayName("店舗名")]
        [StringLength(50)]
        public string ShopName { get; set; }

        [DisplayName("店舗カナ")]
        [StringLength(25)]
        public string ShopKana { get; set; }

        [DisplayName("店舗郵便番号")]
        [StringLength(7)]
        [DisplayFormat(DataFormatString = "{0:###-####}")]
        public string ShopPostCode { get; set; }

        [DisplayName("店舗住所")]
        [StringLength(100)]
        public string ShopAddress { get; set; }

        [DisplayName("店舗住所カナ")]
        [StringLength(50)]
        public string ShopAddressKana { get; set; }

        [DisplayName("店舗電話番号")]
        [StringLength(12)]
        public string ShopPhone { get; set; }

        [DisplayName("店舗FAX番号")]
        [StringLength(12)]
        public string ShopFaxNo { get; set; }

        [DisplayName("店舗メール")]
        [StringLength(30)]
        public string ShopMail { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Comments { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
