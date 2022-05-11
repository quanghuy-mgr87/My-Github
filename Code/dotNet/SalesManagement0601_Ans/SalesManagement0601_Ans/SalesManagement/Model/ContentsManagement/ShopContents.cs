using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;

namespace SalesManagement.Model.ContentsManagement
{
    // 店舗マスター　データ処理クラス
    public class ShopContents
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
        public IEnumerable<Shop> GetShops()
        {
            using (var db = new SalesDbContext())
            {
                List<Shop> shop = db.Shops.ToList();

                // 無効のものはリストから削除
                shop.RemoveAll(m => m.Status != 0);
                return shop;
            }
        }

        // データ取得
        // in  : shopId
        // out : shopデータ
        public Shop GetShop(int shopId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Shops.Single(m => m.ShopId == shopId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundShop);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispShop> GetDispShops()
        {
            using (var db = new SalesDbContext())
            {
                List<DispShop> dispShops = new List<DispShop>();
                foreach (Shop shop in db.Shops)
                {
                    string staff;
                    try
                    {
                        staff = (shop.StaffsId != -1) ? db.Staffs.Single(m => m.StaffCode == shop.StaffsId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == shop.StaffsId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    dispShops.Add(new DispShop()
                    {
                        ShopId = shop.ShopId,
                        ShopCode = shop.ShopCode,
                        ShopName = shop.ShopName,
                        ShopKana = shop.ShopKana,
                        PostCode = shop.PostCode,
                        Address = shop.Address,
                        AddressKana = shop.AddressKana,
                        Phone = shop.Phone,
                        Mail = shop.Mail,
                        // Staff = (shop.StaffsId != -1) ? shop.Staffs.Single().StaffName : string.Empty,
                        Staff = staff,
                        Comments = shop.Comments,
                        Status = StaticCommon.ConvertToString(1, shop.Status),
                        Timestamp = shop.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispShop> sortableDispShop = new SortableBindingList<DispShop>(dispShops);

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
        public IEnumerable<DispShop> GetDispShops(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispShop> dispShops = new List<DispShop>();
                int count = 0;
                foreach (Shop shop in db.Shops)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string staff;
                    try
                    {
                        staff = (shop.StaffsId != -1) ? db.Staffs.Single(m => m.StaffCode == shop.StaffsId).StaffName : string.Empty;

                        // 無効表示
                        if (db.Staffs.Single(m => m.StaffCode == shop.StaffsId).Status != 0) staff = "[" + staff + "]";
                    }
                    catch
                    {
                        staff = string.Empty;
                    }

                    dispShops.Add(new DispShop()
                    {
                        ShopId = shop.ShopId,
                        ShopCode = shop.ShopCode,
                        ShopName = shop.ShopName,
                        ShopKana = shop.ShopKana,
                        PostCode = shop.PostCode,
                        Address = shop.Address,
                        AddressKana = shop.AddressKana,
                        Phone = shop.Phone,
                        Mail = shop.Mail,
                        // Staff = (shop.StaffsId != -1) ? shop.Staffs.Single().StaffName : string.Empty,
                        Staff = staff,
                        Comments = shop.Comments,
                        Status = StaticCommon.ConvertToString(1, shop.Status),
                        Timestamp = shop.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispShop> sortableDispShop = new SortableBindingList<DispShop>(dispShops);

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
        public void PostShop(Shop regShop)
        {
            using (var db = new SalesDbContext())
            {
                db.Shops.Add(regShop);
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
        public void PutShop(Shop regShop)
        {
            using (var db = new SalesDbContext())
            {
                Shop shop;
                try
                {
                    shop = db.Shops.Single(x => x.ShopId == regShop.ShopId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundShop, ex);
                    // throw new Exception(_cm.GetMessage(113), ex);
                }
                shop.ShopCode = regShop.ShopCode;
                shop.ShopName = regShop.ShopName;
                shop.ShopKana = regShop.ShopKana;
                shop.PostCode = regShop.PostCode;
                shop.Address = regShop.Address;
                shop.AddressKana = regShop.AddressKana;
                shop.Phone = regShop.Phone;
                shop.Mail = regShop.Mail;
                shop.StaffsId = regShop.StaffsId;
                shop.Comments = regShop.Comments;
                shop.Status = regShop.Status;
                shop.Timestamp = regShop.Timestamp;

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
        // in       ShopId : 削除する店舗Id
        public void DeleteShop(int ShopId)
        {
            Shop shop;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = db.Shops.Single(x => x.ShopId == ShopId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundShop, ex);
                    // throw new Exception(_cm.GetMessage(113), ex);
                }
                db.Shops.Remove(shop);
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
                Data = ShopId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regShop : ログ対象データ
        // out      string  : ログ文字列
        private string ShopLogData(Shop regShop)
        {
            string staff;
            using (var db = new SalesDbContext())
            {
                try
                {
                    staff = (regShop.StaffsId != -1) ? db.Staffs.Single(m => m.StaffCode == regShop.StaffsId).StaffName : string.Empty;

                    // 無効表示
                    if (db.Staffs.Single(m => m.StaffCode == regShop.StaffsId).Status != 0) staff = "[" + staff + "]";
                }
                catch
                {
                    staff = string.Empty;
                }
            }
            return regShop.ShopId.ToString() + ", " +
            regShop.ShopCode.ToString() + ", " +
            regShop.ShopName + ", " +
            regShop.ShopKana + ", " +
            regShop.PostCode + ", " +
            regShop.Address + ", " +
            regShop.AddressKana + ", " +
            regShop.Phone + ", " +
            regShop.Mail + ", " +
            staff + ", " +
            regShop.Comments + ", " +
            StaticCommon.ConvertToString(1, regShop.Status);
        }
    }
}
