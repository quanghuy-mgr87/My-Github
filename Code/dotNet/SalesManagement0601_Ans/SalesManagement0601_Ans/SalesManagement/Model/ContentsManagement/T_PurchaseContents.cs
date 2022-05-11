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
    // 仕入管理　データ処理クラス
    public class T_PurchaseContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser { get; set; }

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<T_Purchase> GetInventorys()
        {
            using (var db = new SalesDbContext()) return db.T_Purchases.ToList();
        }

        // データ取得（inventory）
        // in  : inventory
        // out : inventoryデータ
        public T_Purchase GetInventory(DateTime arrivalDate, int shopID, string itemCD)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.T_Purchases.Single(m => m.ArrivalDate == arrivalDate && m.ShopID == shopID && m.ItemCD == itemCD);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundInventory);
            }
        }

        // データ追加
        // in   : Inventoryデータ
        public void PostInventory(T_Purchase regInventory)
        {
            using (var db = new SalesDbContext())
            {
                db.T_Purchases.Add(regInventory);
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
                Data = PurchaseLogData(regInventory),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Purchaseデータ
        public void PutPurchase(T_Purchase regPurchase)
        {
            using (var db = new SalesDbContext())
            {
                T_Purchase purchase;
                try
                {
                    purchase = db.T_Purchases.Single(m => m.ArrivalDate == regPurchase.ArrivalDate && m.ShopID == regPurchase.ShopID && m.ItemCD == regPurchase.ItemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundPurchase, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                purchase.PurchaseNo = regPurchase.PurchaseNo;
                purchase.PlaOrderNo = regPurchase.PlaOrderNo;
                purchase.PlaOrderListNo = regPurchase.PlaOrderListNo;
                purchase.ShopID = regPurchase.ShopID;
                purchase.ItemCD = regPurchase.ItemCD;
                purchase.PurchasePrice = regPurchase.PurchasePrice;
                purchase.Quantity = regPurchase.Quantity;
                purchase.VenderID = regPurchase.VenderID;
                purchase.TaxID = regPurchase.TaxID;
                purchase.ArrivalDate = regPurchase.ArrivalDate;
                purchase.Remarks = regPurchase.Remarks;
                purchase.Timestamp = regPurchase.Timestamp;
                purchase.LogData = regPurchase.LogData;

                db.Entry(purchase).State = EntityState.Modified;
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
                Table = "Purchase",
                Command = "Put",
                Data = PurchaseLogData(regPurchase),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       venderID : 削除する仕入先ID、shopID : 店舗ID、itemCD : 商品ID
        public void DeletePurchase(int venderID, int shopID, string itemCD)
        {
            T_Purchase purchase;
            using (var db = new SalesDbContext())
            {
                try
                {
                    purchase = db.T_Purchases.Single(m => m.VenderID == venderID && m.ShopID == shopID && m.ItemCD == itemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundInventirt, ex);
                    // throw new Exception(_cm.GetMessage(121), ex);
                }
                db.T_Purchases.Remove(purchase);
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
                Table = "Purchase",
                Command = "Delete",
                Data = venderID.ToString() + ":" + shopID.ToString() + ":" + itemCD.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

        }

        // ログデータ作成
        // in       regInventory : ログ対象データ
        // out      string  : ログ文字列
        private string PurchaseLogData(T_Purchase regPurchase)
        {
            string arrivalDate = string.Empty;
            if (regPurchase.ArrivalDate != null) arrivalDate = regPurchase.ArrivalDate.Value.ToShortDateString();

            string vender;
            string shop;
            string item;
            int tax;
            using (var db = new SalesDbContext())
            {
                try
                {
                    vender = (regPurchase.ShopID != -1) ? db.M_Venders.Single(m => m.VenderID == regPurchase.VenderID).VenderName : string.Empty;

                    // 無効表示
                    // if (db.M_Vender.Single(m => m.VenderID == regPurchase.VenderID).Status != 0) vender = "[" + vender + "]";
                }
                catch
                {
                    vender = string.Empty;
                }

                try
                {
                    shop = (regPurchase.ShopID != -1) ? db.M_Shops.Single(m => m.ShopID == regPurchase.ShopID).ShopName : string.Empty;

                    // 無効表示
                    // if (db.M_Shops.Single(m => m.ShopID == regInventory.ShopID).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    item = (regPurchase.ItemCD != "") ? db.M_Items.Single(m => m.ItemCD == regPurchase.ItemCD).ItemName : string.Empty;

                    // 無効表示
                    // if (db.M_Items.Single(m => m.ItemCD == regInventory.ItemCD).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }

                try
                {
                    tax = (regPurchase.TaxID != 0) ? db.Taxs.Single(m => m.TaxId == regPurchase.TaxID).TaxValue : 0;

                    // 無効表示
                    // if (db.Taxs.Single(m => m.TaxId == regPurchase.TaxID).Status != 0) tax = "[" + tax + "]";
                }
                catch
                {
                    tax = 0;
                }
            }

            return regPurchase.ArrivalDate.ToString() + ", " +
            vender + ", " +
            shop + ", " +
            item + ", " +
            tax + ", " +
            regPurchase.PurchasePrice + ", " +
            regPurchase.Quantity + ", " +
            regPurchase.Remarks + ", ";
        }
    }
}
