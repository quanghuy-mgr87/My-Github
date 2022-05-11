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
    // 商品仕入先テーブル　エンティティ
    public class T_StockHistory
    {
        [Key, Column(Order = 1)]
        [DisplayName("仕入先ID")]
        public string VenderID { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("商品CD")]
        [StringLength(8)]
        public string ItemID { get; set; }

        [DisplayName("仕入単価")]
        public int PurchasePrice { get; set; }

        [DisplayName("削除フラグ")]
        public bool DelFLG { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Remarks { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }

        // ナビゲーションプロパティ
        public virtual M_Vender Vender { get; set; }
        public virtual M_Item Item { get; set; }
    }
}
