using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement.Model.Entity.Db
{
    // 発注テーブル　エンティティ
    public class T_DispPlaceOrder
    {
        [Key]
        [Column("PlaOrderID")]
        [DisplayName("発注伝票番号")]
        public int PlaOrderID { get; set; }
        public virtual ICollection<T_Purchase> PlaOrderLists { get; set; }

        [DisplayName("店舗CD")]
        public int ShopID { get; set; }

        [DisplayName("仕入先CD")]
        public int VenderID { get; set; }

        [DisplayName("発注日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PlaOrderDateTime { get; set; }

        [DisplayName("スタッフID")]
        [StringLength(3)]
        public string StaffID { get; set; }

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
        public virtual M_Staff Staff { get; set; }
        public virtual M_Vender Vender { get; set; }
    }
}
