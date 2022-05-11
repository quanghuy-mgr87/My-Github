using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;

namespace SalesManagement.Model.ContentsManagement
{
    // 棚卸管理　データ処理クラス
    public class T_InventoryContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser { get; set; }

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<T_Inventory> GetInventorys()
        {
            using (var db = new SalesDbContext()) return db.T_Inventorys.ToList();
        }

        // データ取得（inventory）
        // in  : inventory
        // out : inventoryデータ
        public T_Inventory GetInventory(DateTime inventrirtDate, int shopID, string itemCD)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.T_Inventorys.Single(m => m.InventirtDate == inventrirtDate && m.ShopID == shopID && m.ItemCD == itemCD);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundInventory);
            }
        }

        // データ追加
        // in   : Inventoryデータ
        public void PostInventory(T_Inventory regInventory)
        {
            using (var db = new SalesDbContext())
            {
                db.T_Inventorys.Add(regInventory);
                db.Entry(regInventory).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Inventory",
                Command = "Post",
                Data = InventoryLogData(regInventory),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Inventoryデータ
        public void PutInventory(T_Inventory regInventory)
        {
            using (var db = new SalesDbContext())
            {
                T_Inventory inventory;
                try
                {
                    inventory = db.T_Inventorys.Single(m => m.InventirtDate == regInventory.InventirtDate && m.ShopID == regInventory.ShopID && m.ItemCD == regInventory.ItemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundInventirt, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                inventory.InventirtDate = regInventory.InventirtDate;
                inventory.ShopID = regInventory.ShopID;
                inventory.ItemCD = regInventory.ItemCD;
                inventory.RealStock = regInventory.RealStock;
                inventory.ShopStock = regInventory.ShopStock;
                inventory.DifferenceFlg = regInventory.DifferenceFlg;
                inventory.DifferenceReason = regInventory.DifferenceReason;
                inventory.Timestamp = regInventory.Timestamp;
                inventory.LogData = regInventory.LogData;

                db.Entry(inventory).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Inventory",
                Command = "Put",
                Data = InventoryLogData(regInventory),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       InventoryId : 削除する売上Id
        public void DeleteInventory(DateTime inventrirtDate, int shopID, string itemCD)
        {
            T_Inventory inventory;
            using (var db = new SalesDbContext())
            {
                try
                {
                    inventory = db.T_Inventorys.Single(m => m.InventirtDate == inventrirtDate && m.ShopID == shopID && m.ItemCD == itemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundInventirt, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                db.T_Inventorys.Remove(inventory);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Inventory",
                Command = "Delete",
                Data = inventrirtDate.ToString() + ":" + shopID.ToString() + ":" + itemCD.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

        }

        // ログデータ作成
        // in       regInventory : ログ対象データ
        // out      string  : ログ文字列
        private string InventoryLogData(T_Inventory regInventory)
        {
            string inventoryDateTime = string.Empty;
            if (regInventory.InventirtDate != null) inventoryDateTime = regInventory.InventirtDate.Value.ToShortDateString();

            string shop;
            string item;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regInventory.ShopID != -1) ? db.M_Shops.Single(m => m.ShopID == regInventory.ShopID).ShopName : string.Empty;

                    // 無効表示
                    // if (db.M_Shops.Single(m => m.ShopID == regInventory.ShopID).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    item = (regInventory.ItemCD != "") ? db.M_Items.Single(m => m.ItemCD == regInventory.ItemCD).ItemName : string.Empty;

                    // 無効表示
                    // if (db.M_Items.Single(m => m.ItemCD == regInventory.ItemCD).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }
            }

            return regInventory.InventirtDate.ToString() + ", " +
            shop + ", " +
            item + ", " +
            regInventory.RealStock + ", " +
            regInventory.ShopStock + ", ";
        }
    }
}
