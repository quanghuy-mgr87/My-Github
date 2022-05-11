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
    class M_MakerContents
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
        public IEnumerable<M_Maker> GetMakers()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Maker> maker = db.M_Makers.ToList();

                // 無効のものはリストから削除
                maker.RemoveAll(m => m.DelFLG == true);
                return maker;
            }
        }

        // データ取得
        // in  : MakerID
        // out : Makerデータ
        public M_Maker GetMaker(int MakerID)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Makers.Single(m => m.MakerID == MakerID);
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
        public IEnumerable<M_DispMaker> GetDispMakers()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispMaker> m_DispMakers = new List<M_DispMaker>();
                foreach (M_Maker m_Maker in db.M_Makers)
                {
                    m_DispMakers.Add(new M_DispMaker()
                    {
                        MakerID = m_Maker.MakerID,
                        MakerName = m_Maker.MakerName,
                        MakerKana = m_Maker.MakerKana,
                        DelFLG = m_Maker.DelFLG.ToString(),
                        Comments = m_Maker.Comments,
                        Timestamp = m_Maker.Timestamp,
                        LogData = m_Maker.LogData
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispMaker> sortableDispMaker = new SortableBindingList<M_DispMaker>(m_DispMakers);

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
        public IEnumerable<M_DispMaker> GetDispMakers(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispMaker> m_DispMakers = new List<M_DispMaker>();
                int count = 0;
                foreach (M_Maker m_Maker in db.M_Makers)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    m_DispMakers.Add(new M_DispMaker()
                    {
                        MakerID = m_Maker.MakerID,
                        MakerName = m_Maker.MakerName,
                        MakerKana = m_Maker.MakerKana,
                        DelFLG = m_Maker.DelFLG.ToString(),
                        Comments = m_Maker.Comments,
                        Timestamp = m_Maker.Timestamp,
                        LogData = m_Maker.LogData
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispMaker> sortableDispMaker = new SortableBindingList<M_DispMaker>(m_DispMakers);

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
        // in   : M_Makerデータ
        public string PostMaker(M_Maker regM_Maker)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Makers.Add(regM_Maker);
                db.Entry(regM_Maker).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Maker",
                Command = "Post",
                Data = MakerLogData(regM_Maker),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ更新
        // in   : M_Makerデータ
        // out  : エラーメッセージ 
        public string PutMaker(M_Maker regM_Maker)
        {
            using (var db = new SalesDbContext())
            {
                M_Maker m_Maker;
                try
                {
                    m_Maker = db.M_Makers.Single(x => x.MakerID == regM_Maker.MakerID);
                    m_Maker.MakerName = regM_Maker.MakerName;
                    m_Maker.MakerKana = regM_Maker.MakerKana;
                    m_Maker.DelFLG = regM_Maker.DelFLG;
                    m_Maker.Comments = regM_Maker.Comments;
                    m_Maker.Timestamp = regM_Maker.Timestamp;

                    db.Entry(m_Maker).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundMaker, ex);
                    // throw new Exception(_cm.GetMessage(111), ex);
                    return _msc.GetMessage(111);
                }
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
                    Table = "Maker",
                    Command = "Put",
                    Data = MakerLogData(regM_Maker),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // データ削除
        // in       MakerID : 削除するメーカーID
        public string DeleteMaker(int MakerID)
        {
            M_Maker m_Maker;
            using (var db = new SalesDbContext())
            {
                try
                {
                    m_Maker = db.M_Makers.Single(x => x.MakerID == MakerID);
                    db.M_Makers.Remove(m_Maker);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundMaker, ex);
                    // throw new Exception(_cm.GetMessage(111), ex);
                    return _msc.GetMessage(111);
                }
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
                    Table = "Maker",
                    Command = "Delete",
                    Data = MakerID.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // ログデータ作成
        // in       regM_Maker : ログ対象データ
        // out      string     : ログ文字列
        private string MakerLogData(M_Maker regM_Maker)
        {
            return regM_Maker.MakerID.ToString() + ", " +
            regM_Maker.MakerName + ", " +
            regM_Maker.MakerKana + ", " +
            regM_Maker.DelFLG.ToString() + ", " +
            regM_Maker.Comments;
        }
    }
}
