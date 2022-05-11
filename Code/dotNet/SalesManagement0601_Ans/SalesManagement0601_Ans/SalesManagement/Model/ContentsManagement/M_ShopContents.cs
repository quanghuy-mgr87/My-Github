using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.ContentsManagement
{
    // 店舗マスター　データ処理クラス
    class M_ShopContents
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
        public IEnumerable<M_Shop> GetShops()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Shop> shop = db.M_Shops.ToList();

                // 無効のものはリストから削除
                shop.RemoveAll(m => m.DelFLG == true);
                return shop;
            }
        }

        // データ取得
        // in  : shopId
        // out : shopデータ
        public M_Shop GetShop(int shopId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Shops.Single(m => m.ShopID == shopId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundShop);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispShop> GetDispShops()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispShop> dispShops = new List<M_DispShop>();
                foreach (M_Shop shop in db.M_Shops)
                {
                    dispShops.Add(new M_DispShop()
                    {
                        ShopID = shop.ShopID,
                        ShopName = shop.ShopName,
                        ShopKana = shop.ShopKana,
                        ShopPostCode = shop.ShopPostCode,
                        ShopAddress = shop.ShopAddress,
                        ShopAddressKana = shop.ShopAddressKana,
                        ShopPhone = shop.ShopPhone,
                        ShopFaxNo = shop.ShopFaxNo,
                        ShopMail = shop.ShopMail,
                        DelFLG = shop.DelFLG,
                        Comments = shop.Comments,
                        Timestamp = shop.Timestamp,
                        LogData = shop.LogData,
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispShop> sortableDispShop = new SortableBindingList<M_DispShop>(dispShops);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Shop",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispShop;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<M_DispShop> GetDispShops(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispShop> dispShops = new List<M_DispShop>();
                int count = 0;
                foreach (M_Shop shop in db.M_Shops)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispShops.Add(new M_DispShop()
                    {
                        ShopID = shop.ShopID,
                        ShopName = shop.ShopName,
                        ShopKana = shop.ShopKana,
                        ShopPostCode = shop.ShopPostCode,
                        ShopAddress = shop.ShopAddress,
                        ShopAddressKana = shop.ShopAddressKana,
                        ShopPhone = shop.ShopPhone,
                        ShopFaxNo = shop.ShopFaxNo,
                        ShopMail = shop.ShopMail,
                        DelFLG = shop.DelFLG,
                        Comments = shop.Comments,
                        Timestamp = shop.Timestamp,
                        LogData = shop.LogData,
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispShop> sortableDispShop = new SortableBindingList<M_DispShop>(dispShops);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Shop",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispShop;
            }
        }

        // データ追加
        // in   : Shopデータ
        public void PostShop(M_Shop regShop)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Shops.Add(regShop);
                db.Entry(regShop).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Shop",
                Command = "Post",
                Data = ShopLogData(regShop),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Shopデータ
        public void PutShop(M_Shop regShop)
        {
            using (var db = new SalesDbContext())
            {
                M_Shop shop;
                try
                {
                    shop = db.M_Shops.Single(x => x.ShopID == regShop.ShopID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundShop, ex);
                    // throw new Exception(_cm.GetMessage(113), ex);
                }
                shop.ShopID = regShop.ShopID;
                shop.ShopName = regShop.ShopName;
                shop.ShopKana = regShop.ShopKana;
                shop.ShopPostCode = regShop.ShopPostCode;
                shop.ShopAddress = regShop.ShopAddress;
                shop.ShopAddressKana = regShop.ShopAddressKana;
                shop.ShopPhone = regShop.ShopPhone;
                shop.ShopMail = regShop.ShopMail;
                shop.DelFLG = regShop.DelFLG;
                shop.Comments = regShop.Comments;
                shop.Timestamp = regShop.Timestamp;
                shop.LogData = regShop.LogData;

                db.Entry(shop).State = EntityState.Modified;
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
                Table = "Shop",
                Command = "Put",
                Data = ShopLogData(regShop),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       ShopId : 削除する店舗ID
        public void DeleteShop(int M_ShopID)
        {
            M_Shop shop;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = db.M_Shops.Single(x => x.ShopID == M_ShopID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundShop, ex);
                    // throw new Exception(_cm.GetMessage(113), ex);
                }
                db.M_Shops.Remove(shop);
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
                Table = "Shop",
                Command = "Delete",
                Data = shop.ShopID.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regShop : ログ対象データ
        // out      string  : ログ文字列
        private string ShopLogData(M_Shop regShop)
        {
            using (var db = new SalesDbContext())
            {
            }
            return regShop.ShopID.ToString() + ", " +
            regShop.ShopName + ", " +
            regShop.ShopKana + ", " +
            regShop.ShopPostCode + ", " +
            regShop.ShopAddress + ", " +
            regShop.ShopAddressKana + ", " +
            regShop.ShopPhone + ", " +
            regShop.ShopFaxNo + ", " +
            regShop.ShopMail + ", " +
            regShop.Comments + ", " +
            regShop.DelFLG;
        }
    }
}
