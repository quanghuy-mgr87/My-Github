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
    class PositionContents
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
        public IEnumerable<Position> GetPositions()
        {
            using (var db = new SalesDbContext())
            {
                List<Position> position = db.Positions.ToList();

                // 無効のものはリストから削除
                position.RemoveAll(m => m.Status != 0);
                return position;
            }
        }

        // データ取得
        // in  : PositionId
        // out : Positionデータ
        public Position GetPosition(int PositionId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Positions.Single(m => m.PositionId == PositionId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundPosition);
                // MessageBox.Show(Messages.errorNotFoundPosition);
                // MessageBox.Show(Messages.errorNotFoundPosition);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispPosition> GetDispPositions()
        {
            using (var db = new SalesDbContext())
            {
                List<DispPosition> dispPositions = new List<DispPosition>();
                foreach (Position Position in db.Positions)
                {
                    dispPositions.Add(new DispPosition()
                    {
                        PositionId = Position.PositionId,
                        PositionCode = Position.PositionCode,
                        PositionName = Position.PositionName,
                        PositionKana = Position.PositionKana,
                        Comments = Position.Comments,
                        Status = StaticCommon.ConvertToString(1, Position.Status),
                        Timestamp = Position.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispPosition> sortableDispPosition = new SortableBindingList<DispPosition>(dispPositions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Position",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispPosition;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispPosition> GetDispPositions(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispPosition> dispPositions = new List<DispPosition>();
                int count = 0;
                foreach (Position Position in db.Positions)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispPositions.Add(new DispPosition()
                    {
                        PositionId = Position.PositionId,
                        PositionCode = Position.PositionCode,
                        PositionName = Position.PositionName,
                        PositionKana = Position.PositionKana,
                        Comments = Position.Comments,
                        Status = StaticCommon.ConvertToString(1, Position.Status),
                        Timestamp = Position.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispPosition> sortableDispPosition = new SortableBindingList<DispPosition>(dispPositions);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Position",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispPosition;
            }
        }

        // データ追加
        // in   : Positionデータ
        public void PostPosition(Position regPosition)
        {
            using (var db = new SalesDbContext())
            {
                db.Positions.Add(regPosition);
                db.Entry(regPosition).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Position",
                Command = "Post",
                Data = PositionLogData(regPosition),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Positionデータ
        public void PutPosition(Position regPosition)
        {
            using (var db = new SalesDbContext())
            {
                Position Position;
                try
                {
                    Position = db.Positions.Single(x => x.PositionId == regPosition.PositionId);
                    Position.PositionCode = regPosition.PositionCode;
                    Position.PositionName = regPosition.PositionName;
                    Position.PositionKana = regPosition.PositionKana;
                    Position.Comments = regPosition.Comments;
                    Position.Status = regPosition.Status;
                    Position.Timestamp = regPosition.Timestamp;

                    db.Entry(Position).State = EntityState.Modified;
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundPosition, ex);
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
                    Table = "Position",
                    Command = "Put",
                    Data = PositionLogData(regPosition),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // データ削除
        // in       PositionId : 削除する部署Id
        public void DeletePosition(int PositionId)
        {
            Position Position;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Position = db.Positions.Single(x => x.PositionId == PositionId);
                    db.Positions.Remove(Position);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundPosition, ex);
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
                    Table = "Position",
                    Command = "Post",
                    Data = PositionId.ToString(),
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // ログデータ作成
        // in       regPosition : ログ対象データ
        // out      string      : ログ文字列
        private string PositionLogData(Position regPosition)
        {
            return regPosition.PositionId.ToString() + ", " +
            regPosition.PositionCode.ToString() + ", " +
            regPosition.PositionName + ", " +
            regPosition.PositionKana + ", " +
            regPosition.Comments + ", " +
            StaticCommon.ConvertToString(1, regPosition.Status);
        }
    }
}
