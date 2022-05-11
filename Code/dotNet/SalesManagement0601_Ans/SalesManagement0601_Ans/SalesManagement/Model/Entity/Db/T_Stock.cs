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
    public class T_Stock
    {
        [Key, Column(Order = 1)]
        [DisplayName("店舗ID")]
        public int ShopID { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("商品CD")]
        public string ItemCD { get; set; }

        [DisplayName("在庫数")]
        public int Stock { get; set; }

        [DisplayName("安全在庫数")]
        public int MinimumStock { get; set; }

        [DisplayName("備考")]
        [StringLength(80)]
        public string Remarks { get; set; }

        [DisplayName("タイムスタンプ")]
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DisplayName("更新情報")]
        public string LogData { get; set; }
    }
}
