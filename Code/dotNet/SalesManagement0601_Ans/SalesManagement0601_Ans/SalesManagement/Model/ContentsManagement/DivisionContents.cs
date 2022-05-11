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
    class DivisionContents
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
        public IEnumerable<Division> GetDivisions()
        {
            using (var db = new SalesDbContext())
            {
                List<Division> division = db.Divisions.ToList();

                // 無効のものはリストから削除
                division.RemoveAll(m => m.Status != 0);
                return division;
            }
        }

        // データ取得
        // in  : DivisionId
        // out : Divisionデータ
        public Division GetDivision(int DivisionId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Divisions.Single(m => m.DivisionId == DivisionId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundDivision);
                // MessageBox.Show(Messages.errorNotFoundDivision);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispDivision> GetDispDivisions()
        {
            using (var db = new SalesDbContext())
            {
                List<DispDivision> dispDivisions = new List<DispDivision>();
                foreach (Division Division in db.Divisions)
                {
                    dispDivisions.Add(new DispDivision()
                    {
                        DivisionId = Division.DivisionId,
                        DivisionCode = Division.DivisionCode,
                        DivisionName = Division.DivisionName,
                        DivisionKana = Division.DivisionKana,
                        Comments = Division.Comments,
                        Status = StaticCommon.ConvertToString(1, Division.Status),
                        Timestamp = Division.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispDivision> sortableDispDivision = new SortableBindingList<DispDivision>(dispDivisions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Division",
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
        public IEnumerable<DispDivision> GetDispDivisions(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispDivision> dispDivisions = new List<DispDivision>();
                int count = 0;
                foreach (Division Division in db.Divisions)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispDivisions.Add(new DispDivision()
                    {
                        DivisionId = Division.DivisionId,
                        DivisionCode = Division.DivisionCode,
                        DivisionName = Division.DivisionName,
                        DivisionKana = Division.DivisionKana,
                        Comments = Division.Comments,
                        Status = StaticCommon.ConvertToString(1, Division.Status),
                        Timestamp = Division.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispDivision> sortableDispDivision = new SortableBindingList<DispDivision>(dispDivisions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Division",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispDivision;
            }
        }

        // データ追加
        // in   : Divisionデータ
        public void PostDivision(Division regDivision)
        {
            using (var db = new SalesDbContext())
            {
                db.Divisions.Add(regDivision);
                db.Entry(regDivision).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Division",
                Command = "Post",
                Data = DivisionLogData(regDivision),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Divisionデータ
        public void PutDivision(Division regDivision)
        {
            using (var db = new SalesDbContext())
            {
                Division Division;
                try
                {
                    Division = db.Divisions.Single(x => x.DivisionId == regDivision.DivisionId);
                    Division.DivisionCode = regDivision.DivisionCode;
                    Division.DivisionName = regDivision.DivisionName;
                    Division.DivisionKana = regDivision.DivisionKana;
                    Division.Comments = regDivision.Comments;
                    Division.Status = regDivision.Status;
                    Division.Timestamp = regDivision.Timestamp;

                    db.Entry(Division).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundDivision, ex);
                    // throw new Exception(_cm.GetMessage(109), ex);
                    MessageBox.Show(_msc.GetMessage(109));
                }
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    MessageBox.Show(_msc.GetMessage(100));
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Division",
                    Command = "Put",
                    Data = DivisionLogData(regDivision),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       DivisionId : 削除する部署Id
        public void DeleteDivision(int DivisionId)
        {
            Division Division;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Division = db.Divisions.Single(x => x.DivisionId == DivisionId);
                    db.Divisions.Remove(Division);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundDivision, ex);
                    // throw new Exception(_cm.GetMessage(109), ex);
                    MessageBox.Show(_msc.GetMessage(109));
                }
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    MessageBox.Show(_msc.GetMessage(100));
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Division",
                    Command = "Post",
                    Data = DivisionId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regDivision : ログ対象データ
        // out      string      : ログ文字列
        private string DivisionLogData(Division regDivision)
        {
            return regDivision.DivisionId.ToString() + ", " +
            regDivision.DivisionCode.ToString() + ", " +
            regDivision.DivisionName + ", " +
            regDivision.DivisionKana + ", " +
            regDivision.Comments + ", " +
            StaticCommon.ConvertToString(1, regDivision.Status);
        }
    }
}
