using SalesManagement.DataSet;
using SalesManagement.DataSet.DsStaffTableAdapters;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using SalesManagement.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static SalesManagement.DataSet.DsStaff;

namespace SalesManagement.Model.ContentsManagement
{

    // 従業員マスター　データ処理クラス
    class M_StaffContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（Salt）
        private SaltCommon _sc = new SaltCommon();

        // データベース処理モジュール（Shop）
        private M_ShopContents _sh = new M_ShopContents();

        // データベース処理モジュール（Division）
        private DivisionContents _dv = new DivisionContents();

        // メッセージ
        private readonly Messages _ms = new Messages();

        // 暗号化モジュール
        // private Cryptography _cg = new Cryptography();

        // HASH 処理
        private HashManagement _hm = new HashManagement();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // データベース接続文字列
        private readonly string connDBString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagementADO;Integrated Security=True";

        // ***** メソッド定義

        // データ取得（for ComboBox）
        // out コンボボックス用データ（配列）
        public IEnumerable<M_Staff> GetStaffs_Entity()
        {
            using (var db = new SalesDbContext())
            {
                List<M_Staff> staff = db.M_Staffs.ToList();

                // 無効のものはリストから削除
                staff.RemoveAll(m => m.DelFLG == true);
                return staff;
            }
        }

        public DsStaff GetStaffs()
        {
            // データベースのデータをデータセットに読込
            string SelectcommandText = "SELECT * FROM M_Staff WHERE(DelFLG = 0)";
            DsStaff staff = GetDataToDataSet(SelectcommandText);
            return staff;
        }

        // データ取得（for ComboBox）
        // in   shopId  : ショップを指定しメンバーリストを得る
        // out コンボボックス用データ（配列）
        public IEnumerable<M_Staff> GetStaffsByShop_Entity(int shopID)
        {
            using (var db = new SalesDbContext())
            {
                List<M_Staff> staff = db.M_Staffs.Where(m => m.ShopID == shopID).ToList();

                // 無効のものはリストから削除
                staff.RemoveAll(m => m.DelFLG != false);
                return staff;
            }
        }

        public DsStaff GetStaffsByShop(int shopID)
        {
            // ***** クエリで実行

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff WHERE(ShopID = " + shopID.ToString() + " AND DelFLG = 0)";
            DsStaff staff = GetDataToDataSet(SelectcommandText);
            return staff;
        }

        // データ取得
        // in  : staffId
        // out : staffデータ
        public M_Staff GetStaff_Entity(string staffID)
        {
            try
            {
                using (var db = new SalesDbContext()) return db.M_Staffs.Single(m => m.StaffID == staffID);
            }
            catch (Exception ex)
            {
                throw new Exception(Messages.errorNotFoundStaff, ex);
                // throw new Exception(_cm.GetMessage(114), ex);
            }
        }

        public DsStaff GetStaff(string staffID)
        {
            // ***** クエリで実行

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff WHERE(StaffID = " + staffID + ")";
            DsStaff staff = GetDataToDataSet(SelectcommandText);
            return staff;
        }

        // ユーザーID存在チェック
        // in  : userId
        // out : false = 存在
        public bool CheckUserId_Entity(string userID)
        {
            using (var db = new SalesDbContext()) if (db.M_Staffs.Where(m => m.UserID == userID).ToList().Count() != 0) return false;
            return true;
        }

        public bool CheckUserId(string userID)
        {
            // ***** クエリで実行

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff WHERE(UserID = " + userID + " AND Status = 0)";
            DsStaff staff = GetDataToDataSet(SelectcommandText);
            if (staff.M_Staff.Rows.Count != 0) return false;
            return true;
        }

        // パスワードチェック（HASH）
        // in   : userId
        //      : password
        // out  : true = パスワードOK
        //      : staff = 従業員情報
        public bool CheckPasswordHash_Entity(string userID, string password, out M_Staff staff)
        {
            // Saltの読込
            var salt = _sc.GetSalt().SaltData;

            using (var db = new SalesDbContext())
            {
                staff = null;
                M_Staff l_staff = new M_Staff();
                try
                {
                    // ユーザーIDチェック
                    l_staff = db.M_Staffs.Single(m => m.UserID == userID);
                }
                catch
                {
                    return false;
                }

                // パスワードチェック（HASH）
                if (!l_staff.Password.SequenceEqual(_hm.CreatePBKDF2PasswordHash(password, salt))) return false;

                // ユーザー情報セット
                staff = l_staff;
                return true;
            }
        }

        public bool CheckPasswordHash(string userID, string password, out DsStaff staff)
        {
            // Saltの読込
            var salt = _sc.GetSalt().SaltData;

            // ***** クエリで実行
            staff = null;               // ユーザー情報初期化

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff WHERE(UserID = " + userID + ")";
            DsStaff staffR = GetDataToDataSet(SelectcommandText);
            byte[] passwordR = staffR.M_Staff[0].Password;

            // パスワードチェック（HASH）
            if (!passwordR.SequenceEqual(_hm.CreatePBKDF2PasswordHash(password, salt))) return false;

            // ユーザー情報セット
            staff = staffR;

            return true;
        }

        // 表示データ取得
        // out 表示データ（配列）
        public IEnumerable<M_DispStaff> GetDispStaffs_Entity()
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispStaff> dispStaffs = new List<M_DispStaff>();
                foreach (M_Staff staff in db.M_Staffs)
                {
                    string shop;
                    try
                    {
                        shop = (staff.ShopID != -1) ? db.Shops.Single(m => m.ShopCode == staff.ShopID).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == staff.ShopID).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string division;
                    try
                    {
                        division = (staff.DivisionID != -1) ? db.M_Staffs.Single(m => m.StaffID == staff.DivisionID.ToString()).StaffName : string.Empty;

                        // 無効表示
                        if (db.Divisions.Single(m => m.DivisionId == staff.DivisionID).Status != 0) division = "[" + division + "]";
                    }
                    catch
                    {
                        division = string.Empty;
                    }

                    dispStaffs.Add(new M_DispStaff()
                    {
                        StaffID = staff.StaffID,
                        StaffName = staff.StaffName,
                        StaffKana = staff.StaffKana,
                        StaffPostCode = staff.StaffPostCode,
                        StaffAddress = staff.StaffAddress,
                        StaffAddressKana = staff.StaffAddressKana,
                        StaffPhone = staff.StaffPhone,
                        StaffSmartPhone = staff.StaffSmartPhone,
                        StaffMail = staff.StaffMail,
                        BirthDay = staff.BirthDay,
                        HireDate = staff.HireDay,
                        Shop = shop,
                        Division = division,
                        Position = staff.Position,
                        AccessAuth = StaticCommon.ConvertToString(0, staff.AccessAuth),
                        UserId = staff.UserID,
                        Password = "*****",
                        DelFLG = staff.DelFLG,
                        Comments = staff.Comments,
                        Timestamp = staff.Timestamp
                    });
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispStaff> sortableDispStaff = new SortableBindingList<M_DispStaff>(dispStaffs);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Staff",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispStaff;
            }
        }

        public DsStaff GetDispStaffs()
        {
            // ***** クエリで実行

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff";
            DsStaff staff = GetDataToDataSet(SelectcommandText);

            // 表示データをセット
            DsStaff staffR = SetDispStaffTable(staff, -1, -1);

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "GetAll",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return staffR;
        }

        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点
        public IEnumerable<M_DispStaff> GetDispStaffs_Entity(int startRec, int endRec)
        {
            using (var db = new SalesDbContext())
            {
                List<M_DispStaff> dispStaffs = new List<M_DispStaff>();
                int count = 0;
                foreach (M_Staff staff in db.M_Staffs)
                {
                    if (count < startRec) { count++; continue; }
                    if (endRec - 1 < count) break;

                    string shop;
                    try
                    {
                        shop = (staff.ShopID != -1) ? db.Shops.Single(m => m.ShopCode == staff.ShopID).ShopName : string.Empty;

                        // 無効表示
                        if (db.Shops.Single(m => m.ShopCode == staff.ShopID).Status != 0) shop = "[" + shop + "]";
                    }
                    catch
                    {
                        shop = string.Empty;
                    }

                    string division;
                    try
                    {
                        division = (staff.DivisionID != -1) ? db.M_Staffs.Single(m => m.StaffID == staff.DivisionID.ToString()).StaffName : string.Empty;

                        // 無効表示
                        if (db.Divisions.Single(m => m.DivisionCode == staff.DivisionID).Status != 0) division = "[" + division + "]";
                    }
                    catch
                    {
                        division = string.Empty;
                    }

                    dispStaffs.Add(new M_DispStaff()
                    {
                        StaffID = staff.StaffID,
                        StaffName = staff.StaffName,
                        StaffKana = staff.StaffKana,
                        StaffPostCode = staff.StaffPostCode,
                        StaffAddress = staff.StaffAddress,
                        StaffAddressKana = staff.StaffAddressKana,
                        StaffPhone = staff.StaffPhone,
                        StaffSmartPhone = staff.StaffSmartPhone,
                        StaffMail = staff.StaffMail,
                        BirthDay = staff.BirthDay,
                        HireDate = staff.HireDay,
                        // Shop = (staff.ShopsId != -1) ? staff.Shops.Single().ShopName : string.Empty,
                        Shop = shop,
                        Division = division,
                        Position = staff.Position,
                        AccessAuth = StaticCommon.ConvertToString(0, staff.AccessAuth),
                        UserId = staff.UserID,
                        Password = "*****",
                        DelFLG = staff.DelFLG,
                        Comments = staff.Comments,
                        Timestamp = staff.Timestamp
                    });
                    count++;
                }

                // ソータブルリスト作成
                SortableBindingList<M_DispStaff> sortableDispStaff = new SortableBindingList<M_DispStaff>(dispStaffs);

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Staff",
                    Command = "GetAll",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                return sortableDispStaff;
            }
        }

        // startRec = -1, endRec = -1 で全データ取得
        public DsStaff GetDispStaffs(int startRec, int endRec)
        {
            // ***** クエリで実行

            // 選択クエリ
            string SelectcommandText = "SELECT * FROM M_Staff";
            DsStaff staff = GetDataToDataSet(SelectcommandText);

            // 表示データをセット
            DsStaff staffR = SetDispStaffTable(staff, startRec, endRec);

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "GetAll",
                Data = string.Empty,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);

            return staffR;
        }

        // 表示データ取得共通処理
        public DsStaff SetDispStaffTable(DsStaff staff, int startRec, int endRec)
        {
            // データ格納データセット
            DsStaff staffR = GetDispStaffTable(staff);
            DataTable tableR = staffR.Tables["DispTable"];

            int count = 0;
            foreach (DataRow row in staff.M_Staff.Rows)
            {
                if (startRec != -1 && count < startRec) { count++; continue; }
                if (endRec != -1 && endRec - 1 < count) break;

                string shop;
                if (_sh.GetShop(int.Parse(row["ShopID"].ToString())).DelFLG == false)
                    shop = _sh.GetShop(int.Parse(row["ShopID"].ToString())).ShopName;
                else
                    shop = "[" + _sh.GetShop(int.Parse(row["ShopID"].ToString())).ShopName + "]";


                string division;
                if (_dv.GetDivision(int.Parse(row["DivisionID"].ToString())).Status == 0)
                    division = _dv.GetDivision(int.Parse(row["DivisionID"].ToString())).DivisionName;
                else
                    division = "[" + _dv.GetDivision(int.Parse(row["DivisionID"].ToString())).DivisionName + "]";

                DataRow disprow = tableR.NewRow();

                disprow["スタッフID"] = row["StaffID"];
                disprow["スタッフ氏名"] = row["StaffName"];
                disprow["スタッフ氏名カナ"] = row["StaffKana"];
                disprow["郵便番号"] = row["StaffPostCode"];
                disprow["スタッフ住所"] = row["StaffAddress"];
                disprow["スタッフ住所カナ"] = row["StaffAddressKana"];
                disprow["スタッフ電話番号"] = row["StaffPhone"];
                disprow["スタッフ携帯"] = row["StaffSmartPhone"];
                disprow["スタッフメール"] = row["StaffMail"];
                if ((DateTime)row["BirthDay"] == DateTime.Parse(Constants.sqlServerInitialDate)) disprow["生年月日"] = string.Empty; else disprow["生年月日"] = ((DateTime)row["BirthDay"]).ToShortDateString();
                if ((DateTime)row["HireDay"] == DateTime.Parse(Constants.sqlServerInitialDate)) disprow["入社年月日"] = string.Empty; else disprow["入社年月日"] = ((DateTime)row["HireDay"]).ToShortDateString();
                disprow["店舗"] = shop;
                disprow["部署"] = division;
                disprow["役職"] = row["PositionID"]?.ToString();
                disprow["システムアクセス権限"] = StaticCommon.ConvertToString(0, int.Parse(row["AccessAuth"].ToString()));
                disprow["システムユーザーID"] = row["UserId"];
                disprow["システムログインパス"] = "*****";
                disprow["削除フラグ"] = row["DelFLG"].ToString();
                disprow["備考"] = row["Comments"];
                // disprow["Timestamp"] = row["Timestamp"];
                // disprow["LogData"] = row["LogData"];

                staffR.Tables["DispTable"].Rows.Add(disprow);
            }

            return staffR;
        }


        // データ追加
        // in   : Staffデータ
        public void PostStaff_Entity(M_Staff regStaff)
        {
            using (var db = new SalesDbContext())
            {
                db.M_Staffs.Add(regStaff);
                db.Entry(regStaff).State = EntityState.Added;
                db.SaveChanges();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "Post",
                Data = StaffLogData(regStaff),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        public void PostStaff(DsStaff regStaff)
        {
            // データセットからスタッフIDを取得
            DataRow datarow = regStaff.M_Staff.Rows[0];
            string staffID = datarow["StaffID"].ToString();

            // ***** クエリで実行

            // 挿入クエリ
            string InsertcommandText = "INSERT INTO [M_Staff] ([StaffID], [StaffName], [StaffKana], [StaffPostCode], [StaffAddress], [StaffAddressKana], [StaffPhone], [StaffSmartPhone], [StaffMail], [BirthDay], [HireDay], [ShopID], [DivisionID], [PositionID], [AccessAuth], [UserID], [Password], [DelFLG], [Comments], [TimeStamp], [LogData]) VALUES (@StaffID, @StaffName, @StaffKana, @StaffPostCode, @StaffAddress, @StaffAddressKana, @StaffPhone, @StaffSmartPhone, @StaffMail, @BirthDay, @HireDay, @ShopID, @DivisionID, @PositionID, @AccessAuth, @UserID, @Password, @DelFLG, @Comments, @TimeStamp, @LogData); SELECT StaffID, StaffName, StaffKana, StaffPostCode, StaffAddress, StaffAddressKana, StaffPhone, StaffSmartPhone, StaffMail, BirthDay, HireDay, ShopID, DivisionID, PositionID, AccessAuth, UserID, Password, DelFLG, Comments, TimeStamp, LogData FROM M_Staff WHERE(StaffID = " + staffID + ")";

            // データベースコネクション
            SqlConnection SQLC = new SqlConnection(connDBString);

            // 挿入コマンド
            SqlCommand cmd = new SqlCommand(InsertcommandText, SQLC);

            // SQL コマンドパラメータをセット　＆　ログデータ取得
            SetParameter(regStaff, cmd, out string data);

            try
            {
                // 接続
                SQLC.Open();

                // 実行
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string err = e.ToString();
            }
            finally
            {
                // 切断
                SQLC.Close();
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "Post",
                Data = data,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }
        // データ更新
        // in   : Staffデータ
        public void PutStaff_Entity(M_Staff regStaff)
        {
            using (var db = new SalesDbContext())
            {
                M_Staff staff;
                try
                {
                    staff = db.M_Staffs.Single(x => x.StaffID == regStaff.StaffID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStaff, ex);
                    // throw new Exception(_cm.GetMessage(114), ex);
                }
                staff.StaffID = regStaff.StaffID;
                staff.StaffName = regStaff.StaffName;
                staff.StaffKana = regStaff.StaffKana;
                staff.StaffPostCode = regStaff.StaffPostCode;
                staff.StaffAddress = regStaff.StaffAddress;
                staff.StaffAddressKana = regStaff.StaffAddressKana;
                staff.StaffPhone = regStaff.StaffPhone;
                staff.StaffMail = regStaff.StaffMail;
                staff.BirthDay = regStaff.BirthDay;
                staff.HireDay = regStaff.HireDay;
                staff.ShopID = regStaff.ShopID;
                staff.DivisionID = regStaff.DivisionID;
                staff.Position = regStaff.Position;
                staff.AccessAuth = regStaff.AccessAuth;
                staff.UserID = regStaff.UserID;
                staff.Password = regStaff.Password;
                staff.DelFLG = regStaff.DelFLG;
                staff.Comments = regStaff.Comments;
                staff.Timestamp = regStaff.Timestamp;

                db.Entry(staff).State = EntityState.Modified;
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
                Table = "Staff",
                Command = "Put",
                Data = StaffLogData(regStaff),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        public void PutStaff(DsStaff regStaff)
        {
            // ***** クエリで実行

            // 更新クエリ
            string UpdatecommandText = "UPDATE M_Staff SET [StaffID] = @staffID, [StaffName] = @staffName, [StaffKana] = @staffKana, [StaffPostCode] = @staffPostCode, [StaffAddress] = @staffAddress, [StaffAddressKana] = @staffAddressKana, [StaffPhone] = @staffPhone, [StaffSmartPhone] = @staffSmartPhone, [StaffMail] = @staffMail, [BirthDay] = @birthDay, [HireDay] = @hireDay, [ShopID] = @shopID, [DivisionID] = @divisionID, [PositionID] = @positionID, [AccessAuth] = @accessAuth, [UserID] = @userID, [Password] = @password, [DelFLG] = @delFLG, [Comments] = @comments, [LogData] = @LogData WHERE([StaffID] = @staffID)";

            // データベースコネクション
            SqlConnection SQLC = new SqlConnection(connDBString);

            // 更新コマンド
            SqlCommand cmd = new SqlCommand(UpdatecommandText, SQLC);

            // コマンドパラメータをセット　＆　ログデータ取得
            SetParameter(regStaff, cmd, out string data);

            try
            {
                // 接続
                SQLC.Open();

                // 実行
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw new Exception(Messages.errorConflict, ex);
                // throw new Exception(_cm.GetMessage(100), ex);
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "Put",
                Data = data,
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // SQL コマンドパラメータをセット　＆　ログデータ取得
        private SqlCommand SetParameter (DsStaff regStaff, SqlCommand cmd, out string data)
        {
            // データセットからデータを取得
            DataRow datarow = regStaff.M_Staff.Rows[0];
            string staffID = datarow["StaffID"].ToString();
            string staffName = datarow["StaffName"].ToString();
            string staffKana = datarow["StaffKana"].ToString();
            string staffPostCode = datarow["StaffPostCode"].ToString();
            string staffAddress = datarow["StaffAddress"].ToString();
            string staffAddressKana = datarow["StaffAddressKana"].ToString();
            string staffPhone = datarow["StaffPhone"].ToString();
            string staffSmartPhone = datarow["StaffSmartPhone"].ToString();
            string staffMail = datarow["StaffMail"].ToString();
            string birthDayS = datarow["BirthDay"].ToString();
            string hireDayS = datarow["HireDay"].ToString();
            string shopIDS = datarow["ShopID"].ToString();
            string divisionIDS = datarow["DivisionID"].ToString();
            string positionIDS = datarow["PositionID"].ToString();
            string accessAuth = datarow["AccessAuth"].ToString();
            string userID = datarow["UserID"].ToString();
            string passwordS = datarow["Password"].ToString();
            string delFLGS = datarow["DelFLG"].ToString();
            string comments = datarow["Comments"].ToString();
            string timeStampS = datarow["TimeStamp"].ToString();
            string logData = datarow["LogData"].ToString();

            DateTime birthDay = DateTime.Parse(birthDayS);
            DateTime hireDay = DateTime.Parse(hireDayS);
            int shopID = int.Parse(shopIDS);
            int divisionID = int.Parse(divisionIDS);
            int positionID = int.Parse(positionIDS);
            byte[] password = (byte[])datarow["Password"];
            bool delFLG = bool.Parse(delFLGS);
            // DateTime timeStamp = DateTime.Parse(timeStampS);
            DateTime timeStamp = DateTime.Parse(Constants.sqlServerInitialDate);

            // 登録データパラメータ設定
            cmd.Parameters.Add(new SqlParameter("@StaffID", staffID));
            cmd.Parameters.Add(new SqlParameter("@StaffName", staffName));
            cmd.Parameters.Add(new SqlParameter("@StaffKana", staffKana));
            cmd.Parameters.Add(new SqlParameter("@StaffPostCode", staffPostCode));
            cmd.Parameters.Add(new SqlParameter("@StaffAddress", staffAddress));
            cmd.Parameters.Add(new SqlParameter("@StaffAddressKana", staffAddressKana));
            cmd.Parameters.Add(new SqlParameter("@StaffPhone", staffPhone));
            cmd.Parameters.Add(new SqlParameter("@StaffSmartPhone", staffSmartPhone));
            cmd.Parameters.Add(new SqlParameter("@StaffMail", staffMail));
            cmd.Parameters.Add(new SqlParameter("@BirthDay", birthDay));
            cmd.Parameters.Add(new SqlParameter("@HireDay", hireDay));
            cmd.Parameters.Add(new SqlParameter("@ShopID", shopID));
            cmd.Parameters.Add(new SqlParameter("@DivisionID", divisionID));
            cmd.Parameters.Add(new SqlParameter("@PositionID", positionID));
            cmd.Parameters.Add(new SqlParameter("@AccessAuth", accessAuth));
            cmd.Parameters.Add(new SqlParameter("@UserID", userID));
            cmd.Parameters.Add(new SqlParameter("@Password", password));
            cmd.Parameters.Add(new SqlParameter("@DelFLG", delFLG));
            cmd.Parameters.Add(new SqlParameter("@Comments", comments));
            cmd.Parameters.Add(new SqlParameter("@TimeStamp", timeStamp));
            cmd.Parameters.Add(new SqlParameter("@LogData", logData));

            // ログデータ取得
            data = staffID + ',' + staffName + ',' + staffKana + ',' + staffPostCode + ',' + staffAddress + ',' + staffAddressKana + ',' + staffPhone + ',' + staffSmartPhone + ',' + staffMail + ',' + birthDayS + ',' + hireDayS + ',' + shopIDS + ',' + divisionIDS + ',' + positionIDS + ',' + accessAuth + ',' + userID + ',' + passwordS + ',' + delFLGS + ',' + comments + ',' + timeStampS + ',' + logData;

            return cmd;
        }


        // データ削除
        // in       StaffId : 削除する従業員Id
        public void DeleteStaff_Entity(int StaffID)
        {
            using (var db = new SalesDbContext())
            {
                M_Staff staff;
                try
                {
                    staff = db.M_Staffs.Single(x => x.StaffID == StaffID.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStaff, ex);
                    // throw new Exception(_cm.GetMessage(114), ex);
                }
                if (staff != null)
                {
                    db.M_Staffs.Remove(staff);
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
            }

            // ログ出力
            var operationLog = new OperationLog()
            {
                EventRaisingTime = DateTime.Now,
                Operator = _logonUser,
                Table = "Staff",
                Command = "Delete",
                Data = StaffID.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        public void DeleteStaff(int staffID)
        {
            // 削除クエリ
            string DeletecommandText = "DELETE FROM M_Staff WHERE(StaffID = " + staffID + ")";

            // データベースコネクション
            SqlConnection SQLC = new SqlConnection(connDBString);

            // 削除コマンド
            SqlCommand cmd = new SqlCommand(DeletecommandText, SQLC);

                    try
                    {
                // 接続
                SQLC.Open();

                // 実行
                cmd.ExecuteNonQuery();
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
                Table = "Staff",
                Command = "Delete",
                Data = staffID.ToString(),
                Comments = string.Empty
            };
            StaticCommon.PostOperationLog(operationLog);
        }

        // データベースのデータをデータセットに読込
        public DsStaff GetDataToDataSet(string SelectcommandText)
        {
            // データ格納データセット
            DsStaff staff = new DsStaff();
            M_StaffDataTable table = staff.M_Staff;

            // ***** DsStaff.xsd で定義された SqlDataAdapter を使ったデータ処理
            // M_StaffTableAdapter SqlDataAdapter = new M_StaffTableAdapter();
            // try
            // {
            //     SqlDataAdapter.FillByStaffList(table);
            // }
            // catch(Exception ex)
            // {
            //     MessageBox.Show(ex.Message);
            // }

            // ***** クエリで実行

            // データベースコネクション
            SqlConnection SQLC = new SqlConnection(connDBString);

            // 選択コマンド
            SqlCommand cmd = new SqlCommand(SelectcommandText, SQLC);

            try
            {
                // 接続
                SQLC.Open();

                // パスワード一時格納
                byte[] passwordR = new byte[32];

                // 実行（１レコードずつ読み込んでデータセットにデータをセット）
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    M_StaffRow datarow = (M_StaffRow)table.NewRow();
                    datarow["StaffID"] = dr.GetString(0);
                    datarow["StaffName"] = dr.GetString(1);
                    datarow["StaffKana"] = dr.GetString(2);
                    datarow["StaffPostCode"] = dr.GetString(3);
                    datarow["StaffAddress"] = dr.GetString(4);
                    datarow["StaffAddressKana"] = dr.GetString(5);
                    datarow["StaffPhone"] = dr.GetString(6);
                    datarow["StaffSmartPhone"] = dr.GetString(7);
                    datarow["StaffMail"] = dr.GetString(8);
                    datarow["BirthDay"] = dr.GetDateTime(9);
                    datarow["HireDay"] = dr.GetDateTime(10);
                    datarow["ShopID"] = dr.GetInt32(11);
                    datarow["DivisionID"] = dr.GetInt32(12);
                    datarow["PositionID"] = dr.GetInt32(13);
                    datarow["AccessAuth"] = dr.GetString(14);
                    datarow["UserID"] = dr.GetString(15);
                    dr.GetBytes(16, 0, passwordR, 0, 32);
                    datarow["Password"] = passwordR;
                    datarow["DelFLG"] = dr.GetBoolean(17);
                    datarow["Comments"] = dr.GetString(18);
                    datarow["TimeStamp"] = dr.GetDateTime(19);
                    datarow["LogData"] = dr.GetString(20);
                    table.AddM_StaffRow(datarow);
                }
            }
            catch (Exception e)
            {
                string err = e.ToString();
            }
            finally
            {
                // 切断
                SQLC.Close();
            }
            return staff;
        }

        // 表示用データテーブル作成
        private DsStaff GetDispStaffTable(DsStaff staff)
        {
            DataTable dispDataTable = staff.Tables.Add("DispTable");
            dispDataTable.Columns.Add("スタッフID", typeof(string));
            dispDataTable.Columns.Add("スタッフ氏名", typeof(string));
            dispDataTable.Columns.Add("スタッフ氏名カナ", typeof(string));
            dispDataTable.Columns.Add("郵便番号", typeof(string));
            dispDataTable.Columns.Add("スタッフ住所", typeof(string));
            dispDataTable.Columns.Add("スタッフ住所カナ", typeof(string));
            dispDataTable.Columns.Add("スタッフ電話番号", typeof(string));
            dispDataTable.Columns.Add("スタッフ携帯", typeof(string));
            dispDataTable.Columns.Add("スタッフメール", typeof(string));
            dispDataTable.Columns.Add("生年月日", typeof(string));
            dispDataTable.Columns.Add("入社年月日", typeof(string));
            dispDataTable.Columns.Add("店舗", typeof(string));
            dispDataTable.Columns.Add("部署", typeof(string));
            dispDataTable.Columns.Add("役職", typeof(string));
            dispDataTable.Columns.Add("システムアクセス権限", typeof(string));
            dispDataTable.Columns.Add("システムユーザーID", typeof(string));
            dispDataTable.Columns.Add("システムログインパス", typeof(string));
            dispDataTable.Columns.Add("削除フラグ", typeof(string));
            dispDataTable.Columns.Add("備考", typeof(string));

            return staff;
        }




        // コードカウンター重複チェック
        // in   codeId : データベース指定
        //      id: チェックID （String）
        // out  bool   : false = 重複あり
        public bool CheckIdStringDuplication(int numDb, string id, out string errorMessage)
        {
            bool status = true;
            errorMessage = string.Empty;
            try
            {
                switch (numDb)
                {
                    case Constants.numStaff:
                        // 同じStaffIDが登録されていないかチェック
                        if (GetStaff(id).M_Staff.Rows.Count > 0)
                        {
                            status = false;
                            errorMessage = "コードが重複しています。";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                return status;
            }
            return status;
        }

        // ユーザーID重複チェック
        // in   : userId
        // out  : true = 重複無し
        //      : errorMessage = 重複エラーメッセージ
        public bool UserDuplicationCheck(string UserId, out string errorMessage)
        {
            bool status = true;
            errorMessage = string.Empty;
            var staffs = CheckUserId(UserId);
            if (!CheckUserId(UserId))
            {
                errorMessage = Messages.stDuplication;
                // errorMessage = _cm.GetMessage(75);
                status = false;
            }
            return status;
        }

        // ログデータ作成
        // in       regStaff : ログ対象データ
        // out      string  : ログ文字列
        private string StaffLogData(M_Staff regStaff)
        {
            string shop;
            string division;
            using (var db = new SalesDbContext())
            {
                try
                {
                    shop = (regStaff.ShopID != -1) ? db.Shops.Single(m => m.ShopCode == regStaff.ShopID).ShopName : string.Empty;

                    // 無効表示
                    if (db.Shops.Single(m => m.ShopCode == regStaff.ShopID).Status != 0) shop = "[" + shop + "]";
                }
                catch
                {
                    shop = string.Empty;
                }

                try
                {
                    division = (regStaff.DivisionID != -1) ? db.M_Staffs.Single(m => m.StaffID == regStaff.DivisionID.ToString()).StaffName : string.Empty;

                    // 無効表示
                    if (db.Divisions.Single(m => m.DivisionCode == regStaff.DivisionID).Status != 0) division = "[" + division + "]";
                }
                catch
                {
                    division = string.Empty;
                }
            }
            string birthDay = string.Empty;
            if (regStaff.BirthDay != null) birthDay = regStaff.BirthDay.Value.ToShortDateString();
            string hireDate = string.Empty;
            if (regStaff.HireDay != null) birthDay = regStaff.HireDay.Value.ToShortDateString();

            return regStaff.StaffID.ToString() + ", " +
            regStaff.StaffName + ", " +
            regStaff.StaffKana + ", " +
            regStaff.StaffPostCode + ", " +
            regStaff.StaffAddress + ", " +
            regStaff.StaffAddressKana + ", " +
            regStaff.StaffPhone + ", " +
            regStaff.StaffMail + ", " +
            birthDay + ", " +
            hireDate + ", " +
            shop + ", " +
            regStaff.Position + ", " +
            division + ", " +
            regStaff.AccessAuth + ", " +
            regStaff.UserID + ", " +
            regStaff.DelFLG + ", " +
            regStaff.Comments;
        }
    }
}
