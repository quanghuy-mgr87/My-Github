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
    // 仕入先マスタ　エンティティ
    public class M_Vender
    {
        [Key]
        [DisplayName("仕入先ID")]
        public int VenderID { get; set; }
        public virtual ICollection<T_PlaceOrder> PlaOrders { get; set; }
        public virtual ICollection<T_StockHistory> StocHistorys { get; set; }

        [DisplayName("仕入先名")]
        [StringLength(50)]
        public string VenderName { get; set; }

        [DisplayName("仕入先カナ名")]
        [StringLength(25)]
        public string VenderKana { get; set; }

        [DisplayName("仕入先郵便番号")]
        [StringLength(7)]
        [DisplayFormat(DataFormatString = "{0:###-####}")]
        public string VenderPostCode { get; set; }

        [DisplayName("仕入先住所")]
        [StringLength(100)]
        public string VenderAddress { get; set; }

        [DisplayName("仕入先住所カナ")]
        [StringLength(50)]
        public string VenderAddressKana { get; set; }

        [DisplayName("仕入先電話番号")]
        [StringLength(12)]
        public string VenderPhone { get; set; }

        [DisplayName("仕入先ＦＡＸ番号")]
        [StringLength(12)]
        public string VenderFax { get; set; }

        [DisplayName("仕入先メール")]
        [StringLength(30)]
        public string VenderMail { get; set; }

        [DisplayName("仕入担当者")]
        [StringLength(30)]
        public string VenderStaffName { get; set; }

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
