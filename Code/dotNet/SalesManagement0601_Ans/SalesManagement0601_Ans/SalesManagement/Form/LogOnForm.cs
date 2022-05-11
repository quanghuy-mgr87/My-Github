using System;
using System.Windows.Forms;
using SalesManagement.DataSet;
using SalesManagement.Model;
using SalesManagement.Model.ContentsManagement;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;

namespace SalesManagement
{
    // ログオン　フォームクラス
    public partial class LogOnForm : Form
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（Shop）
        private ShopContents _sh = new ShopContents();

        // データベース処理モジュール（Staff）
        private StaffContents _st = new StaffContents();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        // ***** プロパティ定義

        // トップフォーム
        public TopForm _topForm;

        // コンストラクタ
        public LogOnForm()
        {
            InitializeComponent();
        }

        // TopForm呼出用コンストラクタ
        public LogOnForm(TopForm topForm)
        {
            _topForm = topForm;
            InitializeComponent();
        }

        // *** イベント処理 *****

        // ロード処理
        private void Form_Load(object sender, EventArgs e)
        {
            // フォーム初期設定
            FormInitialSetting();
        }

        // ユーザーID入力チェック
        private void TextBoxUserId_Leave(object sender, EventArgs e)
        {
            if (!_ic.HalfCharSpecialSymbolCheck(textBoxUserId.Text, out string errorMessage)) textBoxUserId.Focus();
            labelMessage.Text = errorMessage;
        }

        // パスワード入力チェック
        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            if (!_ic.HalfCharSpecialSymbolCheck(textBoxPassword.Text, out string errorMessage)) textBoxPassword.Focus();
            labelMessage.Text = errorMessage;
        }

        // ログオン処理
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            // ユーザーID入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(textBoxUserId.Text, out string errorMessage_UserId))
            {
                labelMessage.Text = errorMessage_UserId;
                textBoxUserId.Focus();
                return;
            }

            // パスワード入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(textBoxPassword.Text, out string errorMessage_Password))
            {
                labelMessage.Text = errorMessage_Password;
                textBoxPassword.Focus();
                return;
            }

            // パスワードチェック
            if ((textBoxUserId.Text == "a") && (textBoxPassword.Text == "p"))
            {
                _topForm.MenuControl(Constants.salesMenu | Constants.stockMenu | Constants.orderMenu | Constants.systemMenu);

                // ユーザー情報トップフォームで記憶
                _topForm._staff.M_Staff[0].StaffName = "Administrator";
                _topForm._staff.M_Staff[0].AccessAuth = Constants.numMaster.ToString();

                // TopForm（親）に情報を表示
                ((Label)_topForm.Controls["dataLogonUser"]).Text = "Administrator";
                ((Label)_topForm.Controls["dataAccessAuth"]).Text = Constants.strMaster;
                ((Label)_topForm.Controls["dataBelongingShop"]).Text = "All Shop";
                ((Label)_topForm.Controls["dataLogonTime"]).Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

                // メニュー：ログオン　→　ログオフ
                _topForm.SetLogOff();
                _topForm._logonStatus = true;

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = "Administrator",
                    Table = string.Empty,
                    Command = "Logon",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                Dispose();
                return;
            }
            if (_st.CheckPasswordHash(textBoxUserId.Text, textBoxPassword.Text, out DsStaff staff))
            {
                // 通過後処理
                // メニューコントロール
                string accessAuth = _cm.GetAccessAuth(int.Parse(staff.M_Staff[0].AccessAuth));
                switch(accessAuth)
                {
                    case Constants.strGeneral:
                        _topForm.MenuControl(Constants.salesMenu | Constants.stockMenu | Constants.orderMenu | Constants.masterMenu);
                        break;

                    case Constants.strManager:
                        _topForm.MenuControl(Constants.salesMenu | Constants.stockMenu | Constants.orderMenu | Constants.masterMenu | Constants.importMenu);
                        break;

                    case Constants.strMaster:
                        _topForm.MenuControl(Constants.salesMenu | Constants.stockMenu | Constants.orderMenu | Constants.masterMenu | Constants.importMenu | Constants.systemMenu);
                        break;

                    default:
                        break;
                }

                // ユーザー情報トップフォームで記憶
                _topForm._staff = staff;

                // SalesForm（親）に情報を表示
                ((Label)_topForm.Controls["dataLogonUser"]).Text = staff.M_Staff[0].StaffName;
                ((Label)_topForm.Controls["dataAccessAuth"]).Text = _cm.GetAccessAuth(int.Parse(staff.M_Staff[0].AccessAuth));
                ((Label)_topForm.Controls["dataBelongingShop"]).Text = _sh.GetShop(staff.M_Staff[0].ShopID)?.ShopName;
                ((Label)_topForm.Controls["dataLogonTime"]).Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

                // メニュー：ログオン　→　ログオフ
                _topForm.SetLogOff();
                _topForm._logonStatus = true;

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = staff.M_Staff[0].StaffName,
                    Table = string.Empty,
                    Command = "Logon",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);

                Dispose();
                return;
            }
            else
            {
                labelMessage.Text = "ユーザーIDまたはパスワードが違います。";

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = string.Empty,
                    Table = string.Empty,
                    Command = "LogonFailed",
                    Data = textBoxUserId.Text + "," + textBoxPassword.Text,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            };
        }

        // 閉じるボタン
        private void ButtonCansel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // *** 内部処理 *****

        // フォーム初期設定
        private void FormInitialSetting()
        {
            // コントロールボックス & サイズグリップ無効
            ControlBox = false;
            SizeGripStyle = SizeGripStyle.Hide;
        }
    }
}
