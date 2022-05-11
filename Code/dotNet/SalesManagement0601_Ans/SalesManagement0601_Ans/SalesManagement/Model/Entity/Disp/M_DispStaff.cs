using System;
using System.ComponentModel;

namespace SalesManagement.Model.Entity.Disp
{
    // 従業員マスター表示用　エンティティ
    public class M_DispStaff
    {
        public string StaffID { get; set; }

        [DisplayName("従業員名")]
        public string StaffName { get; set; }

        [DisplayName("従業員カナ")]
        public string StaffKana { get; set; }

        [DisplayName("郵便番号")]
        public string StaffPostCode { get; set; }

        [DisplayName("住所")]
        public string StaffAddress { get; set; }

        [DisplayName("住所カナ")]
        public string StaffAddressKana { get; set; }

        [DisplayName("電話番号")]
        public string StaffPhone { get; set; }

        [DisplayName("携帯番号")]
        public string StaffSmartPhone { get; set; }

        [DisplayName("メール")]
        public string StaffMail { get; set; }

        [DisplayName("誕生日")]
        public DateTime? BirthDay { get; set; }

        [DisplayName("入社日")]
        public DateTime? HireDate { get; set; }

        [DisplayName("所属店舗")]
        public string Shop { get; set; }

        [DisplayName("所属")]
        public string Division { get; set; }

        [DisplayName("役職")]
        public int Position { get; set; }

        [DisplayName("アクセス権")]
        public string AccessAuth { get; set; }

        [DisplayName("ユーザーID")]
        public string UserId { get; set; }

        [DisplayName("パスワード")]
        public string Password { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

        [DisplayName("備考")]
        public string Comments { get; set; }

        public Byte[] Timestamp { get; set; }
    }
}
