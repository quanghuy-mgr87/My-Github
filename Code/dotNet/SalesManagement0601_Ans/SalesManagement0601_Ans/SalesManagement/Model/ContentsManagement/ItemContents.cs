using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Disp;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.ContentsManagement.Common;

namespace SalesManagement.Model.ContentsManagement
{
    // 商品マスター　データ処理クラス
    class ItemContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<Item> GetItems()
        {
            using (var db = new SalesDbContext())
            {
                List<Item> item = db.Items.ToList();

                // 無効のものはリストから削除
                item.RemoveAll(m => m.Status != 0);
                return item;
            }
        }

        // データ取得
        // in  : ItemId
        // out : Itemデータ
        public Item GetItem(long ItemId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Items.Single(m => m.ItemId == ItemId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundItem);
                // throw new Exception(_cm.GetMessage(110), ex);
            }
        }

        // データ取得
        // in  : ItemId
        // out : UnitsId
        public int GetUnitsByItemId(long ItemId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Items.Single(m => m.ItemId == ItemId).UnitsId;
            }
            catch
            {
                return -1;
                // throw new Exception(Messages.errorNotFoundItem);
                // throw new Exception(_cm.GetMessage(110), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispItem> GetDispItems()
        {
            using (var db = new SalesDbContext())
            {
                List<DispItem> dispItems = new List<DispItem>();
                foreach (Item item in db.Items)
                {
                    string maker;
                    try
                    {
                        maker = (item.MakersId != -1) ? db.Makers.Single(m => m.MakerCode == item.MakersId).MakerName : string.Empty;

                        // 無効表示
                        if (db.Makers.Single(m => m.MakerCode == item.MakersId).Status != 0) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    string category;
                    try
                    {
                        category = (item.CategorysId != -1) ? db.Categorys.Single(m => m.CategoryCode == item.CategorysId).CategoryName : string.Empty;

                        // 無効表示
                        if (db.Categorys.Single(m => m.CategoryCode == item.CategorysId).DelFLG != 0) category = "[" +category + "]";
                    }
                    catch
                    {
                        category = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (item.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == item.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == item.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispItems.Add(new DispItem()
                    {
                        ItemId = item.ItemId,
                        ItemCode = item.ItemCode,
                        ItemName = item.ItemName,
                        ItemKana = item.ItemKana,
                        ModelNo = item.ModelNo,
                        Maker = maker,
                        ListPrice = String.Format("{0:#,0}", item.ListPrice),
                        SellingPrice = String.Format("{0:#,0}", item.SellingPrice),
                        PurchasePrice = String.Format("{0:#,0}", item.PurchasePrice),
                        Category = category,
                        MinimumStock = item.MinimumStock,
                        OrderQuantity = item.OrderQuantity,
                        Unit = unit,
                        Comments = item.Comments,
                        Status = StaticCommon.ConvertToString(1, item.Status),
                        Timestamp = item.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispItem> sortableDispItem = new SortableBindingList<DispItem>(dispItems);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Item",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispItem;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispItem> GetDispItems(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispItem> dispItems = new List<DispItem>();
                int count = 0;
                foreach (Item item in db.Items)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string maker;
                    try
                    {
                        maker = (item.MakersId != -1) ? db.Makers.Single(m => m.MakerCode == item.MakersId).MakerName : string.Empty;

                        // 無効表示
                        if (db.Makers.Single(m => m.MakerCode == item.MakersId).Status != 0) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    string category;
                    try
                    {
                        category = (item.CategorysId != -1) ? db.Categorys.Single(m => m.CategoryCode == item.CategorysId).CategoryName : string.Empty;

                        // 無効表示
                        if (db.Categorys.Single(m => m.CategoryCode == item.CategorysId).DelFLG != 0) category = "[" + category + "]";
                    }
                    catch
                    {
                        category = string.Empty;
                    }

                    string unit;
                    try
                    {
                        unit = (item.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == item.UnitsId).UnitName : string.Empty;

                        // 無効表示
                        if (db.Units.Single(m => m.UnitCode == item.UnitsId).Status != 0) unit = "[" + unit + "]";
                    }
                    catch
                    {
                        unit = string.Empty;
                    }

                    dispItems.Add(new DispItem()
                    {
                        ItemId = item.ItemId,
                        ItemCode = item.ItemCode,
                        ItemName = item.ItemName,
                        ItemKana = item.ItemKana,
                        ModelNo = item.ModelNo,
                        Maker = maker,
                        ListPrice = String.Format("{0:#,0}", item.ListPrice),
                        SellingPrice = String.Format("{0:#,0}", item.SellingPrice),
                        PurchasePrice = String.Format("{0:#,0}", item.PurchasePrice),
                        Category = category,
                        MinimumStock = item.MinimumStock,
                        OrderQuantity = item.OrderQuantity,
                        Unit = unit,
                        Comments = item.Comments,
                        Status = StaticCommon.ConvertToString(1, item.Status),
                        Timestamp = item.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispItem> sortableDispItem = new SortableBindingList<DispItem>(dispItems);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Item",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispItem;
            }
        }

        // データ追加
        // in   : Itemデータ
        public void PostItem(Item regItem)
        {
            using (var db = new SalesDbContext())
            {
                db.Items.Add(regItem);
                db.Entry(regItem).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Item",
                Command = "Post",
                Data = ItemLogData(regItem),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Itemデータ
        public void PutItem(Item regItem)
        {
            using (var db = new SalesDbContext())
            {
                Item Item;
                try
                {
                    Item = db.Items.Single(x => x.ItemId == regItem.ItemId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                Item.ItemCode = regItem.ItemCode;
                Item.ItemName = regItem.ItemName;
                Item.ItemKana = regItem.ItemKana;
                Item.ModelNo = regItem.ModelNo;
                Item.MakersId = regItem.MakersId;
                Item.ListPrice = regItem.ListPrice;
                Item.SellingPrice = regItem.SellingPrice;
                Item.PurchasePrice = regItem.PurchasePrice;
                Item.CategorysId = regItem.CategorysId;
                Item.MinimumStock = regItem.MinimumStock;
                Item.OrderQuantity = regItem.OrderQuantity;
                Item.UnitsId = regItem.UnitsId;
                Item.Comments = regItem.Comments;
                Item.Status = regItem.Status;
                Item.Timestamp = regItem.Timestamp;

                db.Entry(Item).State = EntityState.Modified;
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
                    Table = "Item",
                    Command = "Put",
                    Data = ItemLogData(regItem),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       ItemId : 削除する商品Id
        public void DeleteItem(int ItemId)
        {
            Item Item;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Item = db.Items.Single(x => x.ItemId == ItemId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.Items.Remove(Item);
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
                    Table = "Item",
                    Command = "Delete",
                    Data = ItemId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regItem : ログ対象データ
        // out      string  : ログ文字列
        private string ItemLogData(Item regItem)
        {
            string maker;
            string category;
            string unit;
            using (var db = new SalesDbContext())
            {
                try
                {
                    maker = (regItem.MakersId != -1) ? db.Makers.Single(m => m.MakerCode == regItem.MakersId).MakerName : string.Empty;

                    // 無効表示
                    if (db.Makers.Single(m => m.MakerCode == regItem.MakersId).Status != 0) maker = "[" + maker + "]";
                }
                catch
                {
                    maker = string.Empty;
                }

                try
                {
                    category = (regItem.CategorysId != -1) ? db.Categorys.Single(m => m.CategoryCode == regItem.CategorysId).CategoryName : string.Empty;

                    // 無効表示
                    if (db.Categorys.Single(m => m.CategoryCode == regItem.CategorysId).DelFLG != 0) category = "[" + category + "]";
                }
                catch
                {
                    category = string.Empty;
                }

                try
                {
                    unit = (regItem.UnitsId != -1) ? db.Units.Single(m => m.UnitCode == regItem.UnitsId).UnitName : string.Empty;

                    // 無効表示
                    if (db.Units.Single(m => m.UnitCode == regItem.UnitsId).Status != 0) unit = "[" + unit + "]";
                }
                catch
                {
                    unit = string.Empty;
                }
            }

            return regItem.ItemId.ToString() + ", " +
            regItem.ItemCode.ToString() + ", " +
            regItem.ItemName + ", " +
            regItem.ItemKana + ", " +
            regItem.ModelNo + ", " +
            maker + ", " +
            regItem.ListPrice + ", " +
            regItem.SellingPrice + ", " +
            category + ", " +
            regItem.MinimumStock + ", " +
            regItem.OrderQuantity + ", " +
            unit + ", " +
            regItem.Comments + ", " +
            StaticCommon.ConvertToString(1, regItem.Status);
        }
    }
}
