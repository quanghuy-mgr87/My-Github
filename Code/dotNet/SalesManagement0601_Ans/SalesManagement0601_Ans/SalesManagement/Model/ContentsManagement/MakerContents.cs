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
    // メーカーマスター　データ処理クラス
    class MakerContents
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
        public IEnumerable<Maker> GetMakers()
        {
            using (var db = new SalesDbContext())
            {
                List<Maker> maker = db.Makers.ToList();

                // 無効のものはリストから削除
                maker.RemoveAll(m => m.Status != 0);
                return maker;
            }
        }

        // データ取得
        // in  : MakerId
        // out : Makerデータ
        public Maker GetMaker(int MakerId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Makers.Single(m => m.MakerId == MakerId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundMaker);
                // throw new Exception(_cm.GetMessage(111), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispMaker> GetDispMakers()
        {
            using (var db = new SalesDbContext())
            {
                List<DispMaker> dispMakers = new List<DispMaker>();
                foreach (Maker maker in db.Makers)
                {
                    dispMakers.Add(new DispMaker()
                    {
                        MakerId = maker.MakerId,
                        MakerCode = maker.MakerCode,
                        MakerName = maker.MakerName,
                        MakerKana = maker.MakerKana,
                        ContactNo = maker.ContactNo,
                        PersonInCharge = maker.PersonInCharge,
                        Comments = maker.Comments,
                        Status = StaticCommon.ConvertToString(1, maker.Status),
                        Timestamp = maker.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispMaker> sortableDispMaker = new SortableBindingList<DispMaker>(dispMakers);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Maker",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispMaker;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispMaker> GetDispMakers(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispMaker> dispMakers = new List<DispMaker>();
                int count = 0;
                foreach (Maker maker in db.Makers)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispMakers.Add(new DispMaker()
                    {
                        MakerId = maker.MakerId,
                        MakerCode = maker.MakerCode,
                        MakerName = maker.MakerName,
                        MakerKana = maker.MakerKana,
                        ContactNo = maker.ContactNo,
                        PersonInCharge = maker.PersonInCharge,
                        Comments = maker.Comments,
                        Status = StaticCommon.ConvertToString(1, maker.Status),
                        Timestamp = maker.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispMaker> sortableDispMaker = new SortableBindingList<DispMaker>(dispMakers);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Maker",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispMaker;
            }
        }

        // データ追加
        // in   : Makerデータ
        public void PostMaker(Maker regMaker)
        {
            using (var db = new SalesDbContext())
            {
                db.Makers.Add(regMaker);
                db.Entry(regMaker).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Maker",
                Command = "Post",
                Data = MakerLogData(regMaker),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Makerデータ
        public void PutMaker(Maker regMaker)
        {
            using (var db = new SalesDbContext())
            {
                Maker maker;
                try
                {
                    maker = db.Makers.Single(x => x.MakerId == regMaker.MakerId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundMaker, ex);
                    // throw new Exception(_cm.GetMessage(111), ex);
                }
                maker.MakerCode = regMaker.MakerCode;
                maker.MakerName = regMaker.MakerName;
                maker.MakerKana = regMaker.MakerKana;
                maker.ContactNo = regMaker.ContactNo;
                maker.PersonInCharge = regMaker.PersonInCharge;
                maker.Comments = regMaker.Comments;
                maker.Status = regMaker.Status;
                maker.Timestamp = regMaker.Timestamp;

                db.Entry(maker).State = EntityState.Modified;
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
                    Table = "Maker",
                    Command = "Put",
                    Data = MakerLogData(regMaker),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       MakerId : 削除するメーカーId
        public void DeleteMaker(int MakerId)
        {
            Maker maker;
            using (var db = new SalesDbContext())
            {
                try
                {
                    maker = db.Makers.Single(x => x.MakerId == MakerId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundMaker, ex);
                    // throw new Exception(_cm.GetMessage(111), ex);
                }
                db.Makers.Remove(maker);
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
                    Table = "Maker",
                    Command = "Delete",
                    Data = MakerId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regMaker : ログ対象データ
        // out      string   : ログ文字列
        private string MakerLogData(Maker regMaker)
        {
            return regMaker.MakerId.ToString() + ", " +
            regMaker.MakerCode.ToString() + ", " +
            regMaker.MakerName + ", " +
            regMaker.MakerKana + ", " +
            regMaker.ContactNo + ", " +
            regMaker.PersonInCharge + ", " +
            regMaker.Comments + ", " +
            StaticCommon.ConvertToString(1, regMaker.Status);
        }
    }
}
