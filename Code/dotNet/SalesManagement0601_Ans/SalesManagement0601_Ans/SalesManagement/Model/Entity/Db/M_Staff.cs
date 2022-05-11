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
    // スタッフマスタ　エンティティ
    public class M_Staff
    {
        [Key]
        [DisplayName("スタッフID")]
        [StringLength(3)]
        public string StaffID { get; set; }
        public virtual ICollection<T_PlaceOrder> PlaOrders { get; set; }

        [DisplayName("スタッフ氏名")]
        [StringLength(40)]
        public string StaffName { get; set; }

        [DisplayName("スタッフ氏名カナ")]
        [StringLength(20)]
        public string StaffKana { get; set; }

        [DisplayName("スタッフ郵便番号")]
        [StringLength(7)]
        [DisplayFormat(DataFormatString = "{0:###-####}")]
        public string StaffPostCode { get; set; }

        [DisplayName("スタッフ住所")]
        [StringLength(100)]
        public string StaffAddress { get; set; }

        [DisplayName("スタッフ住所カナ")]
        [StringLength(100)]
        public string StaffAddressKana { get; set; }

        [DisplayName("スタッフ電話番号")]
        [StringLength(12)]
        public string StaffPhone { get; set; }

        [DisplayName("スタッフ携帯")]
        [StringLength(12)]
        public string StaffSmartPhone { get; set; }

        [DisplayName("スタッフメール")]
        [StringLength(30)]
        public string StaffMail { get; set; }

        [DisplayName("生年月日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDay { get; set; }

        [DisplayName("入社年月日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HireDay { get; set; }

        [DisplayName("店舗ID")]
        public int ShopID { get; set; }

        [DisplayName("部署ID")]
        public int DivisionID { get; set; }

        [DisplayName("役職ID")]
        public int Position { get; set; }

        [DisplayName("システムアクセス権")]
        public int AccessAuth { get; set; }

        [DisplayName("システムユーザーID")]
        [StringLength(18)]
        public string UserID { get; set; }

        [DisplayName("システムログインパス")]
        [StringLength(18)]
        public byte[] Password { get; set; }

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

        // ナビゲーションプロパティ
        public virtual M_Shop Shop { get; set; }
    }
}
