using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using SalesManagement.Model.ContentsManagement.Common;


namespace SalesManagement.Model.ContentsManagement
{
    // 受発注単位マスター　データ処理クラス
    class UnitContents
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
        public IEnumerable<Unit> GetUnits()
        {
            using (var db = new SalesDbContext())
            {
                List<Unit> unit = db.Units.ToList();

                // 無効のものはリストから削除
                unit.RemoveAll(m => m.Status != 0);
                return unit;
            }
        }

        // データ取得
        // in  : UnitId
        // out : Unitデータ
        public Unit GetUnit(int unitId)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.Units.Single(m => m.UnitId == unitId);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundUnit);
                // throw new Exception(_cm.GetMessage(116), ex);
            }
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<DispUnit> GetDispUnits()
        {
            using (var db = new SalesDbContext())
            {
                List<DispUnit> dispUnits = new List<DispUnit>();
                foreach (Unit Unit in db.Units)
                {
                    dispUnits.Add(new DispUnit()
                    {
                        UnitId = Unit.UnitId,
                        UnitCode = Unit.UnitCode,
                        UnitName = Unit.UnitName,
                        UnitKana = Unit.UnitKana,
                        NumberOfComponent = Unit.NumberOfComponent,
                        Comments = Unit.Comments,
                        Status = StaticCommon.ConvertToString(1, Unit.Status),
                        Timestamp = Unit.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<DispUnit> sortableDispUnit = new SortableBindingList<DispUnit>(dispUnits);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Unit",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispUnit;
            }
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<DispUnit> GetDispUnits(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<DispUnit> dispUnits = new List<DispUnit>();
                int count = 0;
                foreach (Unit Unit in db.Units)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    dispUnits.Add(new DispUnit()
                    {
                        UnitId = Unit.UnitId,
                        UnitCode = Unit.UnitCode,
                        UnitName = Unit.UnitName,
                        UnitKana = Unit.UnitKana,
                        NumberOfComponent = Unit.NumberOfComponent,
                        Comments = Unit.Comments,
                        Status = StaticCommon.ConvertToString(1, Unit.Status),
                        Timestamp = Unit.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<DispUnit> sortableDispUnit = new SortableBindingList<DispUnit>(dispUnits);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Unit",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispUnit;
            }
        }

        // データ追加
        // in   : Unitデータ
        public void PostUnit(Unit regUnit)
        {
            using (var db = new SalesDbContext())
            {
                db.Units.Add(regUnit);
                db.Entry(regUnit).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Unit",
                Command = "Post",
                Data = UnitLogData(regUnit),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ更新
        // in   : Unitデータ
        public void PutUnit(Unit regUnit)
        {
            using (var db = new SalesDbContext())
            {
                Unit Unit;
                try
                {
                    Unit = db.Units.Single(x => x.UnitId == regUnit.UnitId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundUnit, ex);
                    // throw new Exception(_cm.GetMessage(116), ex);
                }
                Unit.UnitCode = regUnit.UnitCode;
                Unit.UnitName = regUnit.UnitName;
                Unit.UnitKana = regUnit.UnitKana;
                Unit.NumberOfComponent = regUnit.NumberOfComponent;
                Unit.Comments = regUnit.Comments;
                Unit.Status = regUnit.Status;
                Unit.Timestamp = regUnit.Timestamp;

                db.Entry(Unit).State = EntityState.Modified;
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
                Table = "Unit",
                Command = "Put",
                Data = UnitLogData(regUnit),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データ削除
        // in       UnitId : 削除する受発注単位Id
        public void DeleteUnit(int UnitId)
        {
            Unit Unit;
            using (var db = new SalesDbContext())
            {
                try
                {
                    Unit = db.Units.Single(x => x.UnitId == UnitId);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundUnit, ex);
                    // throw new Exception(_cm.GetMessage(116), ex);
                }
                db.Units.Remove(Unit);
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
                Table = "Unit",
                Command = "Delete",
                Data = UnitId.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // ログデータ作成
        // in       regUnit : ログ対象データ
        // out      string  : ログ文字列
        private string UnitLogData(Unit regUnit)
        {
            return regUnit.UnitId.ToString() + ", " +
            regUnit.UnitCode.ToString() + ", " +
            regUnit.UnitName + ", " +
            regUnit.UnitKana + ", " +
            regUnit.NumberOfComponent + ", " +
            regUnit.Comments + ", " +
            StaticCommon.ConvertToString(1, regUnit.Status);
        }
    }
}
