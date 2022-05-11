using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement.Model.ContentsManagement
{
    // 商品管理　データ処理クラス
    class StockDetailContents
    {
        // データ取得
        // in  : ItemId
        // out : StockDetailデータ（配列）
        public IEnumerable<StockDetail> GetStockDetail(long itemId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.StockDetails.Where(m => m.ItemsId == itemId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundStockDetail);
                // throw new Exception(_cm.GetMessage(120), ex);
            }
        }

        // データ追加
        // in   : StockListデータ
        public void PostStockDetail(StockDetail regStockDetail)
        {
            using (var db = new SalesDbContext())
            {
                db.StockDetails.Add(regStockDetail);
                db.Entry(regStockDetail).State = EntityState.Added;
                db.SaveChanges();
            }
        }


        // データ追加（商品管理用）
        // in       shopId    : 店舗Id
        //          itemId    : 商品Id
        //          storageNo : 在庫番号
        //          totalPcs  : 個数
        //          price     : 見積単価
        //          taxId     : 消費税Id
        // out  : 追加分合算値段
        public int AddStockDetail(int shopId, long itemId, int storageNo, int totalPcs, int price, int taxId, out List<StockDetail> stockDetails)
        {
            stockDetails = new List<StockDetail>();

            int totalPrice = 0;
            using (var db = new SalesDbContext())
            {
                for (int i = 0; i < totalPcs; i++)
                {
                    StockDetail stockDetail = new StockDetail()
                    {
                        ShopsId = shopId,
                        ItemsId = itemId,
                        StorageNo = storageNo,
                        Price = price,
                        TaxsId = taxId
                    };
                    stockDetails.Add(stockDetail);

                    // 追加分合算値段
                    totalPrice += stockDetail.Price;

                    // 追加
                    // db.StockDetails.Add(stockDetail);
                    // db.Entry(stockDetail).State = EntityState.Added;
                }

                // トランザクション処理のため後に実行
                // try
                // {
                //     db.SaveChanges();
                // }
                // catch (DbUpdateConcurrencyException ex)
                // {
                //     throw new Exception(Messages.errorConflict, ex);
                // throw new Exception(_cm.GetMessage(100), ex);
                // }
            }
            return totalPrice;
        }

        // データ削除
        // in       StockDetailId : 削除する商品管理Id
        // out      削除分値段
        //          List<StockDetail> stockDetails : 削除リスト
        public int DeleteStockDetailById(int StockDetailId, out List<StockDetail> stockDetails)
        {
            stockDetails = new List<StockDetail>();

            int totalPrice = 0;
            using (var db = new SalesDbContext())
            {
                var stockDetailsW = db.StockDetails.Where(m => m.StockDetailId == StockDetailId);

                foreach (var stockDetail in stockDetailsW)
                {
                    try
                    {
                        // 削除分値段合算
                        totalPrice += stockDetail.Price;

                        // 削除
                        // db.StockDetails.Remove(stockDetail);
                        stockDetails.Add(stockDetail);
                    }
                    catch
                    {
                        MessageBox.Show(Messages.notFoundItem);
                        // throw new Exception(Messages.notFoundItem, ex);
                        // throw new Exception(_cm.GetMessage(201), ex);
                    }
                }


                // トランザクション処理のため後に実行
                // try
                // {
                //     db.SaveChanges();
                // }
                // catch (DbUpdateConcurrencyException ex)
                // {
                //     throw new Exception(Messages.errorConflict, ex);
                // throw new Exception(_cm.GetMessage(100), ex);
                // }
            }
            return totalPrice;
        }

        // データ削除
        // in       shopId   : 店舗Id
        //          itemId   : 商品Id
        //          totalPcs : 個数
        // out      削除分値段
        //          List<StockDetail> stockDetails : 削除リスト
        public int DeleteStockDetail(int shopId, long itemId, int totalPcs, out List<StockDetail> stockDetails)
        {
            stockDetails = new List<StockDetail>();

            int totalPrice = 0;
            using (var db = new SalesDbContext())
            {
                List<StockDetail> stockDetailsW = db.StockDetails.Where(m => m.ShopsId == shopId && m.ItemsId == itemId).ToList();

                for (int i = 0; i < totalPcs; i++)
                {
                    try
                    {
                        StockDetail stockDetail = stockDetailsW.ElementAt(i);
                        stockDetails.Add(stockDetail);

                        // 削除分値段合算
                        totalPrice += stockDetail.Price;

                        // 削除
                        // db.StockDetails.Remove(stockDetail);
                        // db.Entry(stockDetail).State = EntityState.Deleted;
                    }
                    catch
                    {
                        MessageBox.Show(Messages.notFoundItem);
                        // throw new Exception(Messages.notFoundItem, ex);
                        // throw new Exception(_cm.GetMessage(201), ex);
                    }

                    // トランザクション処理のため後に実行
                    // try
                    // {
                    //     db.SaveChanges();
                    // }
                    // catch (DbUpdateConcurrencyException ex)
                    // {
                    //     throw new Exception(Messages.errorConflict, ex);
                        // throw new Exception(_cm.GetMessage(100), ex);
                    // }
                }
            }
            return totalPrice;
        }

        // データ削除
        // in       storageNo : 在庫番号
        // out      削除分値段
        //          List<StockDetail> stockDetails : 削除リスト
        public int RemoveStockDetailByStorageNo(int storageNo, out List<StockDetail> stockDetails)
        {
            stockDetails = new List<StockDetail>();

            int totalPrice = 0;
            using (var db = new SalesDbContext())
            {
                var stockDetailsW = db.StockDetails.Where(m => m.StorageNo == storageNo);

                foreach (var stockDetail in stockDetailsW)
                {
                    try
                    {
                        // 削除分値段合算
                        totalPrice += stockDetail.Price;

                        // 削除
                        // db.StockDetails.Remove(stockDetail);
                        stockDetails.Add(stockDetail);
                    }
                    catch
                    {
                        MessageBox.Show(Messages.notFoundItem);
                        // throw new Exception(Messages.notFoundItem, ex);
                        // throw new Exception(_cm.GetMessage(201), ex);
                    }
                }


                // トランザクション処理のため後に実行
                // try
                // {
                //     db.SaveChanges();
                // }
                // catch (DbUpdateConcurrencyException ex)
                // {
                //     throw new Exception(Messages.errorConflict, ex);
                // throw new Exception(_cm.GetMessage(100), ex);
                // }
            }
            return totalPrice;
        }
    }
}
