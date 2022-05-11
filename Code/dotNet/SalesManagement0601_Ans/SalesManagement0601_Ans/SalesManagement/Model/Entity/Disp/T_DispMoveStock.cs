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
    // 店舗間移動テーブル　エンティティ
    public class T_DispMoveStock
    {
        [Key]
        [DisplayName("店舗間移動番号")]
        public string MoveNo { get; set; }

        [DisplayName("移動元ID")]
        public string MoveShopFormID { get; set; }

        [DisplayName("移動先ID")]
        public string MoveToShopID { get; set; }

        [DisplayName("商品CD")]
        [StringLength(8)]
        public string ItemID { get; set; }

        [DisplayName("移動数量")]
        public int MoveQuantity { get; set; }

        [DisplayName("移動指示日")]
        public DateTime? MoveDate { get; set; }

        [DisplayName("移動開始日")]
        public DateTime? MoveStateDate { get; set; }

        [DisplayName("移動完了日")]
        public DateTime? MoveEndDate { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Remarks { get; set; }

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
