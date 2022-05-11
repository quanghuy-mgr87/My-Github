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
    // 仕入先マスター　データ処理クラス
    class M_VenderContents
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
        public IEnumerable<M_Vender> GetVenders()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Vender> item = db.M_Venders.ToList();

                // 無効のものはリストから削除
                item.RemoveAll(m => m.DelFLG == true);
                return item;
            }
        }

        // データ取得
        // in  : VenderId
        // out : Venderデータ
        public M_Vender GetVender(long VenderID)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Venders.Single(m => m.VenderID == VenderID);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundVender);
                // throw new Exception(_cm.GetMessage(110), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispVender> GetDispVenders()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispVender> dispVenders = new List<M_DispVender>();
                foreach (M_Vender item in db.M_Venders)
                {
                    dispVenders.Add(new M_DispVender()
                    {
                        VenderID = item.VenderID,
                        VenderName = item.VenderName,
                        VenderKana = item.VenderKana,
                        VenderPostCode = item.VenderPostCode,
                        VenderAddress = item.VenderAddress,
                        VenderAddressKana = item.VenderAddressKana,
                        VenderPhone = item.VenderPhone,
                        VenderMail = item.VenderMail,
                        VenderStaffName = item.VenderStaffName,
                        DelFLG = item.DelFLG,
                        Comments = item.Comments,
                        Timestamp = item.Timestamp,
                        LogData =item.LogData
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispVender> sortableDispVender = new SortableBindingList<M_DispVender>(dispVenders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Vender",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispVender;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<M_DispVender> GetDispVenders(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispVender> dispVenders = new List<M_DispVender>();
                int count = 0;
                foreach (M_Vender item in db.M_Venders)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispVenders.Add(new M_DispVender()
                    {
                        VenderID = item.VenderID,
                        VenderName = item.VenderName,
                        VenderKana = item.VenderKana,
                        VenderPostCode = item.VenderPostCode,
                        VenderAddress = item.VenderAddress,
                        VenderAddressKana = item.VenderAddressKana,
                        VenderPhone = item.VenderPhone,
                        VenderMail = item.VenderMail,
                        VenderStaffName = item.VenderStaffName,
                        DelFLG = item.DelFLG,
                        Comments = item.Comments,
                        Timestamp = item.Timestamp,
                        LogData = item.LogData
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispVender> sortableDispVender = new SortableBindingList<M_DispVender>(dispVenders);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Vender",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispVender;
            }
        }

        // データ追加
        // in   : Venderデータ
        public void PostVender(M_Vender regVender)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Venders.Add(regVender);
                db.Entry(regVender).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Vender",
                Command = "Post",
                Data = VenderLogData(regVender),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Venderデータ
        public void PutVender(M_Vender regVender)
        {
            using (var db = new SalesDbContext())
            {
                M_Vender vender;
                try
                {
                    vender = db.M_Venders.Single(x => x.VenderID == regVender.VenderID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundVender, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                {
                    vender.VenderID = regVender.VenderID;
                    vender.VenderName = regVender.VenderName;
                    vender.VenderKana = regVender.VenderKana;
                    vender.VenderPostCode = regVender.VenderPostCode;
                    vender.VenderAddress = regVender.VenderAddress;
                    vender.VenderAddressKana = regVender.VenderAddressKana;
                    vender.VenderPhone = regVender.VenderPhone;
                    vender.VenderMail = regVender.VenderMail;
                    vender.VenderStaffName = regVender.VenderStaffName;
                    vender.DelFLG = regVender.DelFLG;
                    vender.Comments = regVender.Comments;
                    vender.Timestamp = regVender.Timestamp;
                    vender.LogData = regVender.LogData;

                    db.Entry(vender).State = EntityState.Modified;
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
                        Table = "Vender",
                        Command = "Put",
                        Data = VenderLogData(regVender),
                        Comments = string.Empty
                    };
                    StaticCommon.PostOperationLog(operationLog);
                }
            }
        }

        // データ削除
        // in       VenderId : 削除する商品Id
        public void DeleteVender(int VenderID)
        {
            M_Vender Vender;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Vender = db.M_Venders.Single(x => x.VenderID == VenderID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundVender, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.M_Venders.Remove(Vender);
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
                    Table = "Vender",
                    Command = "Delete",
                    Data = VenderID.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regVender : ログ対象データ
        // out      string  : ログ文字列
        private string VenderLogData(M_Vender regVender)
        {
            using (var db = new SalesDbContext())
            {
            }

            return regVender.VenderID.ToString() + ", " +
            regVender.VenderName + ", " +
            regVender.VenderKana + ", " +
            regVender.VenderAddress + ", " +
            regVender.VenderAddressKana + ", " +
            regVender.VenderPhone + ", " +
            regVender.VenderMail + ", " +
            regVender.VenderStaffName + ", " +
            regVender.DelFLG + ", " +
            regVender.Comments;
        }
    }
}
