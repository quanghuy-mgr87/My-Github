using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;

namespace SalesManagement.Model.ContentsManagement
{
    // 部署マスター　データ処理クラス
    class M_DivisionContents
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
        public IEnumerable<M_Division> GetM_Divisions()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Division> division = db.M_Divisions.ToList();

                // 無効のものはリストから削除
                division.RemoveAll(m => m.DelFLG == true);
                return division;
            }
        }

        // データ取得
        // in  : M_DivisionID
        // out : M_Divisionデータ
        public M_Division GetM_Division(int m_DivisionID)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Divisions.Single(m => m.DivisionID == m_DivisionID);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundM_Division);
                // MessageBox.Show(Messages.errorNotFoundM_Division);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispDivision> GetM_DispDivisions()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispDivision> m_DispDivisions = new List<M_DispDivision>();
                foreach (M_Division m_Division in db.M_Divisions)
                {
                    m_DispDivisions.Add(new M_DispDivision()
                    {
                        DivisionID = m_Division.DivisionID,
                        DivisionName = m_Division.DivisionName,
                        DelFLG = m_Division.DelFLG.ToString(),
                        Comments = m_Division.Comments,
                        Timestamp = m_Division.Timestamp,
                        LogData = m_Division.LogData
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispDivision> sortableDispDivision = new SortableBindingList<M_DispDivision>(m_DispDivisions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "M_Division",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispDivision;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<M_DispDivision> GetDispDivisions(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispDivision> m_DispDivisions = new List<M_DispDivision>();
                int count = 0;
                foreach (M_Division m_Division in db.M_Divisions)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    m_DispDivisions.Add(new M_DispDivision()
                    {
                        DivisionID=m_Division.DivisionID,
                        DivisionName = m_Division.DivisionName,
                        DelFLG = m_Division.DelFLG.ToString(),
                        Comments = m_Division.Comments,
                        Timestamp = m_Division.Timestamp,
                        LogData = m_Division.LogData
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispDivision> sortableM_DispDivision = new SortableBindingList<M_DispDivision>(m_DispDivisions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "M_Division",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableM_DispDivision;
            }
        }

        // データ追加
        // in   : M_Divisionデータ
        public string PostM_Division(M_Division regM_Division)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Divisions.Add(regM_Division);
                db.Entry(regM_Division).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    // MessageBox.Show(_msc.GetMessage(100));
                    return _msc.GetMessage(100);
                }
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "M_Division",
                Command = "Post",
                Data = M_DivisionLogData(regM_Division),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }

        // データ更新
        // in   : M_Divisionデータ
        // out  : エラーメッセージ 
        public string PutM_Division(M_Division regM_Division)
        {
            using (var db = new SalesDbContext())
            {
                M_Division m_Division;
                try
                {
                    m_Division = db.M_Divisions.Single(x => x.DivisionID == regM_Division.DivisionID);
                    m_Division.DivisionName = regM_Division.DivisionName;
                    m_Division.DelFLG = regM_Division.DelFLG;
                    m_Division.Comments = regM_Division.Comments;
                    m_Division.Timestamp = regM_Division.Timestamp;

                    db.Entry(m_Division).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundM_Division, ex);
                    // throw new Exception(_cm.GetMessage(109), ex);
                    // MessageBox.Show(_msc.GetMessage(109));
                    return _msc.GetMessage(109);
                }
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    // MessageBox.Show(_msc.GetMessage(100));
                    return _msc.GetMessage(100);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "M_Division",
                    Command = "Put",
                    Data = M_DivisionLogData(regM_Division),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // データ削除
        // in       M_DivisionID : 削除する部署ID
        public string DeleteM_Division(int DivisionID)
        {
            M_Division m_Division;
            using (var db = new SalesDbContext())
            {
                try
                {
                    m_Division = db.M_Divisions.Single(x => x.DivisionID == DivisionID);
                    db.M_Divisions.Remove(m_Division);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundM_Division, ex);
                    // throw new Exception(_cm.GetMessage(109), ex);
                    // MessageBox.Show(_msc.GetMessage(109));
                    return _msc.GetMessage(109);
                }
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    // MessageBox.Show(_msc.GetMessage(100));
                    return _msc.GetMessage(100);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "M_Division",
                    Command = "Post",
                    Data = DivisionID.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string M_DivisionLogData(M_Division regM_Division)
        {
            return regM_Division.DivisionID.ToString() + ", " +
            regM_Division.DivisionID.ToString() + ", " +
            regM_Division.DivisionName + ", " +
            regM_Division.DelFLG.ToString() + ", " +
            regM_Division.Comments;
        }
    }
}
