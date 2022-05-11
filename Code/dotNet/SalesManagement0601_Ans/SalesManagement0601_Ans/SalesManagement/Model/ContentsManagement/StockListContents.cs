using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.ContentsManagement.Common;


namespace SalesManagement.Model.ContentsManagement
{
    // 在庫リスト　データ処理クラス
    class StockListContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<StockList> GetStockLists()
        {
            using (var db = new SalesDbContext())
            {
                List<StockList> stockList = db.StockLists.ToList();

                // 無効のものはリストから削除
                stockList.RemoveAll(m => m.Status != 0);
                return stockList;
            }
        }

        // データ取得
        // in  : StockListId
        // out : StockListデータ
        public StockList GetStockList(int StockListId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.StockLists.Single(m => m.StockListId == StockListId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundStockList);
                // throw new Exception(_cm.GetMessage(117), ex);
            }
        }

        // データ取得
        // in  : shopId
        //     : ItemId
        // out : StockListデータ
        public StockList GetStockList(int shopId, long itemId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.StockLists.Single(m => m.ShopsId == shopId && m.ItemsId == itemId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundStockList);
                // throw new Exception(_cm.GetMessage(117), ex);
            }
        }

        // データ取得
        // in  : shopId
        //     : ItemId
        // out : StockList Id
        public int GetStockListId(int shopId, long itemId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.StockLists.Single(m => m.ShopsId == shopId && m.ItemsId == itemId).StockListId;
            }
            catch
            {
                return -1;
                // throw new Exception(Messages.errorNotFoundStockList);
                // throw new Exception(_cm.GetMessage(117), ex);
            }
        }

        // 表示データ取得
        // in  shopId : -1 = 店舗未指定
        // out 表示データ（配列）
        public IEnumerable<DispStockList> GetDispStockLists(int shopId)
        {
            List<DispStockList> dispStockLists = new List<DispStockList>();

            using (var db = new SalesDbContext())
            {
                List<StockList> stocklistShop;
                if (shopId == -1) stocklistShop = db.StockLists.ToList();
                else stocklistShop = db.StockLists.Where(m => m.ShopsId == shopId).ToList();

                foreach (StockList stockList in stocklistShop)
                {
                    string shop;
                    try
                    {
                        shop = (stockList.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stockList.ShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stockList.ShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (stockList.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stockList.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == stockList.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    dispStockLists.Add(new DispStockList()
                    {
                        StockListId = stockList.StockListId,
                        StockNo = stockList.StockNo,
                        Shop = shop,
                        Item = item,
                        Pcs = stockList.Pcs.ToString(),
                        TotalPrice = String.Format("{0:#,0}", stockList.TotalPrice),
                        Comments = stockList.Comments,
                        Status = StaticCommon.ConvertToString(1, stockList.Status),
                        Timestamp = stockList.Timestamp
                    });
                }
            }

            // ソータブルリスト作成
            SortableBindingList<DispStockList> sortableDispStockList = new SortableBindingList<DispStockList>(dispStockLists);

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "StockList",
                Command = "GetAll",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return sortableDispStockList;
        }

        // 表示データ取得（始点・終点指定）
        // in   shopId   : -1 = 店舗未指定
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispStockList> GetDispStockLists(int shopId, int startRec, int endRec)
        {
            List<DispStockList> dispStockLists = new List<DispStockList>();

            using (var db = new SalesDbContext())
            {
                List<StockList> stocklistShop;
                if (shopId == -1) stocklistShop = db.StockLists.ToList();
                else stocklistShop = db.StockLists.Where(m => m.ShopsId == shopId).ToList();

                int count = 0;
                foreach (StockList stockList in stocklistShop)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string shop;
                    try
                    {
                        shop = (stockList.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == stockList.ShopsId).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == stockList.ShopsId).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string item;
                    try
                    {
                        item = (stockList.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == stockList.ItemsId).ItemName : string.Empty;

                        // 無効表示
                        if (db.Items.Single(m => m.ItemCode == stockList.ItemsId).Status != 0) item = "[" + item + "]";
                    }
                    catch
                    {
                        item = string.Empty;
                    }

                    dispStockLists.Add(new DispStockList()
                    {
                        StockListId = stockList.StockListId,
                        StockNo = stockList.StockNo,
                        Shop = shop,
                        Item = item,
                        Pcs = stockList.Pcs.ToString(),
                        TotalPrice = String.Format("{0:#,0}", stockList.TotalPrice),
                        Comments = stockList.Comments,
                        Status = StaticCommon.ConvertToString(1, stockList.Status),
                        Timestamp = stockList.Timestamp
                    });
                    count++;
                }
            }

            // ソータブルリスト作成
            SortableBindingList<DispStockList> sortableDispStockList = new SortableBindingList<DispStockList>(dispStockLists);

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "StockList",
                Command = "GetAll",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return sortableDispStockList;
        }

        // データ追加
        // in   : StockListデータ
        public void PostStockList(StockList regStockList)
        {
            using (var db = new SalesDbContext())
            {
                db.StockLists.Add(regStockList);
                db.Entry(regStockList).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "StockList",
                Command = "Post",
                Data = StockListLogData(regStockList),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : StockListデータ
        public void PutStockList(StockList regStockList)
        {
            using (var db = new SalesDbContext())
            {
                StockList stockList;
                try
                {
                    stockList = db.StockLists.Single(x => x.StockListId == regStockList.StockListId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStockList, ex);
                    // throw new Exception(_cm.GetMessage(119), ex);
                }
                stockList.StockNo = regStockList.StockNo;
                stockList.ShopsId = regStockList.ShopsId;
                stockList.ItemsId = regStockList.ItemsId;
                stockList.Pcs = regStockList.Pcs;
                stockList.TotalPrice = regStockList.TotalPrice;
                stockList.Comments = regStockList.Comments;
                stockList.Status = regStockList.Status;
                stockList.Timestamp = regStockList.Timestamp;

                db.Entry(stockList).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "StockList",
                    Command = "Put",
                    Data = StockListLogData(regStockList),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       StockListId : 削除するStockListId
        public void DeleteStockList(int StockListId)
        {
            StockList stockList;
            using (var db = new SalesDbContext())
            {
                try
                {
                    stockList = db.StockLists.Single(x => x.StockListId == StockListId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStockList, ex);
                    // throw new Exception(_cm.GetMessage(118), ex);
                }
                db.StockLists.Remove(stockList);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "StockList",
                    Command = "Delete",
                    Data = StockListId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regStockList : ログ対象データ
        // out      string   : ログ文字列
        private string StockListLogData(StockList regStockList)
        {
            string shop;
            string item;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regStockList.ShopsId != -1) ? db.Shops.Single(m => m.ShopCode == regStockList.ShopsId).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regStockList.ShopsId).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    item = (regStockList.ItemsId != -1) ? db.Items.Single(m => m.ItemCode == regStockList.ItemsId).ItemName : string.Empty;

                    // 無効表示
                    if (db.Items.Single(m => m.ItemCode == regStockList.ItemsId).Status != 0) item = "[" + item + "]";
                }
                catch
                {
                    item = string.Empty;
                }
            }

            return regStockList.StockListId.ToString() + ", " +
            regStockList.StockNo.ToString() + ", " +
            shop + ", " +
            item + ", " +
            regStockList.Pcs.ToString() + ", " +
            regStockList.TotalPrice + ", " +
            regStockList.Comments + ", " +
            StaticCommon.ConvertToString(1, regStockList.Status);
        }
    }
}
