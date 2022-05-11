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
    class M_ItemContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<M_Item> GetItems()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Item> item = db.M_Items.ToList();

                // 無効のものはリストから削除
                item.RemoveAll(m => m.DelFLG == true);
                return item;
            }
        }

        // データ取得
        // in  : ItemId
        // out : Itemデータ
        public M_Item GetItem(string itemCD)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Items.Single(m => m.ItemCD == itemCD);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundItem);
                // throw new Exception(_cm.GetMessage(110), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispItem> GetDispItems()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispItem> dispItems = new List<M_DispItem>();
                foreach (M_Item item in db.M_Items)
                {
                    string maker;
                    try
                    {
                        maker = (item.MakerID != -1) ? db.Makers.Single(m => m.MakerCode == item.MakerID).MakerName : string.Empty;

                        // 無効表示
                        if (db.M_Makers.Single(m => m.MakerID == int.Parse(item.MakerID.ToString())).DelFLG == true) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    string category;
                    try
                    {
                        category = (item.CategoryCD != string.Empty) ? db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).CategoryName : string.Empty;

                        // 無効表示
                        if (db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).DelFLG == true) category = "[" +category + "]";
                    }
                    catch
                    {
                        category = string.Empty;
                    }

                    dispItems.Add(new M_DispItem()
                    {
                        ItemCD = item.ItemCD,
                        ItemName = item.ItemName,
                        ItemKana = item.ItemKana,
                        ModelNo = item.ModelNo,
                        JanCD = item.JanCD,
                        ListPrice = String.Format("{0:#,0}", item.ListPrice),
                        SellingPrice = String.Format("{0:#,0}", item.SellingPrice),
                        Maker = maker,
                        Category = category,
                        Comments = item.Comments,
                        Timestamp = item.Timestamp,
                        LogData = item.LogData,
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispItem> sortableDispItem = new SortableBindingList<M_DispItem>(dispItems);

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
        public IEnumerable<M_DispItem> GetDispItems(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispItem> dispItems = new List<M_DispItem>();
                int count = 0;
                foreach (M_Item item in db.M_Items)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string maker;
                    try
                    {
                        maker = (item.MakerID != -1) ? db.Makers.Single(m => m.MakerId == item.MakerID).MakerName : string.Empty;

                        // 無効表示
                        if (db.Makers.Single(m => m.MakerId == item.MakerID).Status != 0) maker = "[" + maker + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    string category;
                    try
                    {
                        category = (item.CategoryCD != string.Empty) ? db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).CategoryName : string.Empty;

                        // 無効表示
                        if (db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).DelFLG == true) category = "[" + category + "]";
                    }
                    catch
                    {
                        category = string.Empty;
                    }

                    dispItems.Add(new M_DispItem()
                    {
                        ItemCD = item.ItemCD,
                        ItemName = item.ItemName,
                        ItemKana = item.ItemKana,
                        ModelNo = item.ModelNo,
                        JanCD = item.JanCD,
                        ListPrice = String.Format("{0:#,0}", item.ListPrice),
                        SellingPrice = String.Format("{0:#,0}", item.SellingPrice),
                        Maker = maker,
                        Category = category,
                        DelFLG = item.DelFLG,
                        Comments = item.Comments,
                        Timestamp = item.Timestamp,
                        LogData = item.LogData,
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispItem> sortableDispItem = new SortableBindingList<M_DispItem>(dispItems);

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
        // in   : M_Itemデータ
        public string PostItem(M_Item regItem)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Items.Add(regItem);
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
                Data = M_ItemLogData(regItem),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ更新
        // in   : M_Itemデータ
        // out  : エラーメッセージ 
        public string PutItem(M_Item regItem)
        {
            using (var db = new SalesDbContext())
            {
                M_Item Item;
                try
                {
                    Item = db.M_Items.Single(x => x.ItemCD == regItem.ItemCD);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                Item.ItemCD = regItem.ItemCD;
                Item.ItemName = regItem.ItemName;
                Item.ItemKana = regItem.ItemKana;
                Item.ModelNo = regItem.ModelNo;
                Item.JanCD = regItem.JanCD;
                Item.ListPrice = regItem.ListPrice;
                Item.SellingPrice = regItem.SellingPrice;
                Item.MakerID = regItem.MakerID;
                Item.CategoryCD = regItem.CategoryCD;
                Item.DelFLG = regItem.DelFLG;
                Item.Comments = regItem.Comments;
                Item.Timestamp = regItem.Timestamp;
                Item.LogData = regItem.LogData;

                db.Entry(Item).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
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

                return string.Empty;
            }
        }

        // データ削除
        // in       ItemId : 削除する商品ID
        public void DeleteItem(string M_ItemCD)
        {
            M_Item item;
            using (var db = new SalesDbContext())
            {
                try
                {
                    item = db.M_Items.Single(x => x.ItemCD == M_ItemCD);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.M_Items.Remove(item);
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
                    Data = item.ItemCD.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regItem : ログ対象データ
        // out      string  : ログ文字列
        private string ItemLogData(M_Item regItem)
        {
            string maker;
            string category;
            using (var db = new SalesDbContext())
            {
                try
                {
                    maker = (regItem.MakerID != -1) ? db.Makers.Single(m => m.MakerCode == regItem.MakerID).MakerName : string.Empty;

                    // 無効表示
                    if (db.M_Makers.Single(m => m.MakerID == int.Parse(regItem.MakerID.ToString())).DelFLG == true) maker = "[" + maker + "]";
                }
                catch
                {
                    maker = string.Empty;
                }

                try
                {
                    category = (regItem.CategoryCD != string.Empty) ? db.M_Categorys.Single(m => m.CategoryCD == regItem.CategoryCD).CategoryName : string.Empty;

                    // 無効表示
                    if (db.M_Categorys.Single(m => m.CategoryCD == regItem.CategoryCD).DelFLG == true) category = "[" + category + "]";
                }
                catch
                {
                    category = string.Empty;
                }
            }

            return regItem.ItemCD.ToString() + ", " +
            regItem.ItemName + ", " +
            regItem.ItemKana + ", " +
            regItem.ModelNo + ", " +
            regItem.JanCD + ", " +
            maker + ", " +
            regItem.ListPrice + ", " +
            regItem.SellingPrice + ", " +
            category + ", " +
            regItem.Comments + ", " +
            regItem.DelFLG;
        }

        private string M_ItemLogData(M_Item regItem)
        {
            string maker;
            string category;
            using (var db = new SalesDbContext())
            {
                try
                {
                    maker = (regItem.MakerID != -1) ? db.Makers.Single(m => m.MakerCode == regItem.MakerID).MakerName : string.Empty;

                    // 無効表示
                    if (db.M_Makers.Single(m => m.MakerID == int.Parse(regItem.MakerID.ToString())).DelFLG == true) maker = "[" + maker + "]";
                }
                catch
                {
                    maker = string.Empty;
                }

                try
                {
                    category = (regItem.CategoryCD != string.Empty) ? db.M_Categorys.Single(m => m.CategoryCD == regItem.CategoryCD).CategoryName : string.Empty;

                    // 無効表示
                    if (db.M_Categorys.Single(m => m.CategoryCD == regItem.CategoryCD).DelFLG == true) category = "[" + category + "]";
                }
                catch
                {
                    category = string.Empty;
                }

            }

            int delflg = 0;
            if (regItem.DelFLG == true) delflg = 1;

            return regItem.ItemCD.ToString() + ", " +
            regItem.ItemName + ", " +
            regItem.ItemKana + ", " +
            regItem.ModelNo + ", " +
            maker + ", " +
            regItem.ListPrice + ", " +
            regItem.SellingPrice + ", " +
            category + ", " +
            regItem.Comments + ", " +
            StaticCommon.ConvertToString(1, int.Parse(delflg.ToString()));
        }
    }
}
