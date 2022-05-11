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
    // 棚卸テーブル　エンティティ
    public class T_Inventory
    {
        [Key, Column(Order = 1)]
        [DisplayName("入荷日")]
        public DateTime? InventirtDate { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("店舗ID")]
        public int ShopID { get; set; }

        [Key, Column(Order = 3)]
        [DisplayName("商品CD")]
        [StringLength(8)]
        public string ItemCD { get; set; }

        [DisplayName("在庫数")]
        public int RealStock { get; set; }

        [DisplayName("棚卸在庫数")]
        public int ShopStock { get; set; }

        [DisplayName("差異理由区分")]
        public String[] DifferenceFlg { get; set; }

        [DisplayName("差異理由詳細")]
        public string DifferenceReason { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }

        // ナビゲーションプロパティ
        public virtual M_Shop Shop { get; set; }
        public virtual M_Item Item { get; set; }
    }
}
