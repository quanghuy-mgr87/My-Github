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
    // 在庫管理　データ処理クラス
    public class T_StockContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser { get; set; }

        // ***** メソッド定義

        // データ取得（配列）
        public IEnumerable<T_Stock> GetStocks()
        {
            using (var db = new SalesDbContext()) return db.T_Stocks.ToList();
        }

        // データ取得（配列）：安全在庫数を下回る商品リスト
        public IEnumerable<T_Stock> GetStocksToOrder()
        {
            try
            {
                using (var db = new SalesDbContext())
                {
                    List<T_Stock> tst = db.T_Stocks.Where(m => m.Stock < m.MinimumStock).ToList();
                    return tst;
                }
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundInventory);
            }
        }

        // データ取得（stock）
        // in  : stock
        // out : stockデータ
        public T_Stock GetStock(int shopID, string itemCD)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.T_Stocks.Single(m => m.ShopID == shopID && m.ItemCD == itemCD);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundInventory);
            }
        }

        // データ追加
        // in   : Stockデータ
        public void PostStock(T_Stock regStock)
        {
            using (var db = new SalesDbContext())
            {
                db.T_Stocks.Add(regStock);
                db.Entry(regStock).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Stock",
                Command = "Post",
                Data = StockLogData(regStock),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Stockデータ
        public void PutStock(T_Stock regStock)
        {
            using (var db = new SalesDbContext())
            {
                T_Stock stock;
                try
                {
                    stock = db.T_Stocks.Single(m => m.ShopID == regStock.ShopID && m.ItemCD == regStock.ItemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStock, ex);
                    // throw new Exception(_cm.GetMessage(118), ex);
                }
                stock.ShopID = regStock.ShopID;
                stock.ItemCD = regStock.ItemCD;
                stock.Stock = regStock.Stock;
                stock.MinimumStock = regStock.MinimumStock;
                stock.Remarks = regStock.Remarks;
                stock.Timestamp = regStock.Timestamp;
                stock.LogData = regStock.LogData;

                db.Entry(stock).State = EntityState.Modified;
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
                Table = "Stock",
                Command = "Put",
                Data = StockLogData(regStock),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       shopID : 店舗ID、itemCD : 商品ID
        public void DeleteStock(int shopID, string itemCD)
        {
            T_Stock stock;
            using (var db = new SalesDbContext())
            {
                try
                {
                    stock = db.T_Stocks.Single(m => m.ShopID == shopID && m.ItemCD == itemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStock, ex);
                    // throw new Exception(_cm.GetMessage(118), ex);
                }
                db.T_Stocks.Remove(stock);
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
                Table = "Stock",
                Command = "Delete",
                Data = shopID.ToString() + ":" + itemCD.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

        }

        // ログデータ作成
        // in       regInventory : ログ対象データ
        // out      string  : ログ文字列
        private string StockLogData(T_Stock regStock)
        {
            string shop;
            string item;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regStock.ShopID != -1) ? db.M_Shops.Single(m => m.ShopID == regStock.ShopID).ShopName : string.Empty;

                    // 無効表示
                    // if (db.M_Shops.Single(m => m.ShopID == regStock.ShopID).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    item = (regStock.ItemCD != "") ? db.M_Items.Single(m => m.ItemCD == regStock.ItemCD).ItemName : string.Empty;

                    // 無効表示
                    // if (db.M_Items.Single(m => m.ItemCD == regStock.ItemCD).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }
            }

            return shop + ", " +
            item + ", " +
            regStock.Stock + ", " +
            regStock.MinimumStock + ", " +
            regStock.Remarks + ", ";
        }
    }
}
