using SalesManagement.DataSet;
using SalesManagement.Model;
using SalesManagement.Model.ContentsManagement;
using SalesManagement.Model.ContentsManagement.Common;
using SalesManagement.Model.Entity;
using SalesManagement.Model.Entity.Db;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SalesManagement.DataSet.DsStaff;

namespace SalesManagement
{
    public partial class TopForm : Form
    {
        // ***** モジュール実装

        // データベース処理
        private CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（Salt）
        private SaltCommon _sc = new SaltCommon();

        // データベース処理モジュール（コントロールパネル）
        private ControlPanelCommon _cpc = new ControlPanelCommon();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // データベース処理モジュール（コードカウンター）
        private CodeCounterCommon _cc = new CodeCounterCommon();

        // HASH 処理
        private HashManagement _hm = new HashManagement();

        // メッセージ
        private Messages _ms = new Messages();

        // ***** プロパティ定義

        // ログオンステータス ＆ ログオンユーザー情報
        public bool _logonStatus = false;
        public DsStaff _staff = new DsStaff();

        public TopForm()
        {
            InitializeComponent();
        }

        // *** イベント処理 *****

        // ロード処理
        private void From_Load(object sender, EventArgs e)
        {
            // コントロールパネル初期化
            ControlPanelInitialize();

            // Salt初期化
            SaltInitialize();

            // メッセージ登録
            if (_msc.CheckMessage()) _msc.PostMessage(_ms.GenerateMessage().ToList());
            // if (_cm.CheckMessage()) _ms.GenerateMessage();

            // コードカウンター初期化
            CodeCounterInitialize();

            // フォーム初期設定
            FormInitialSetting();

            // ログオンユーザー情報保存行作成
            _staff = GetInitializedDataSet();

            // メニュー無効
            MenuControl(0);
        }

        // ***** メニュー起動

        // 売上管理
        private void ToolStripSideMenuItemSales_Click(object sender, EventArgs e)
        {
            //SalesForm _saf = new SalesForm(this);
            //_saf.ShowDialog();
        }

        // 在庫管理
        private void ToolStripSideMenuItemStock_Click(object sender, EventArgs e)
        {
            //StockForm _skf = new StockForm(this);
            //_skf.ShowDialog();
        }

        // 発注管理
        private void ToolStripSideMenuItemOrder_Click(object sender, EventArgs e)
        {
            // OrderForm _orf = new OrderForm(this);
            //FormPlaceOrder _orf = new FormPlaceOrder(this);
            //_orf.ShowDialog();
        }

        // 店舗マスター
        private void ToolStripSideMenuItemShop_Click(object sender, EventArgs e)
        {
            //ShopForm _shf = new ShopForm(this);
            //_shf.ShowDialog();
        }

        // 部署マスター
        private void ToolStripSideMenuItemDivision_Click(object sender, EventArgs e)
        {
            //FormDivision _dvf = new FormDivision(this);
            //_dvf.ShowDialog();
        }

        // 従業員マスター
        private void ToolStripSideMenuItemStaff_Click(object sender, EventArgs e)
        {
            //StaffForm _stf = new StaffForm(this);
            //_stf.ShowDialog();
        }

        // カテゴリーマスター
        private void ToolStripSideMenuItemCategory_Click(object sender, EventArgs e)
        {
            FormCategory _ctf = new FormCategory(this);
            _ctf.ShowDialog();
        }

        // メーカーマスター
        private void ToolStripSideMenuItemMaker_Click(object sender, EventArgs e)
        {
            FormMaker _mkf = new FormMaker(this);
            _mkf.ShowDialog();
        }

        // 消費税マスター
        private void ToolStripSideMenuItemTax_Click(object sender, EventArgs e)
        {
            FormTax _txf = new FormTax(this);
            _txf.ShowDialog();
        }

        // 受発注単位マスター
        private void ToolStripSideMenuItemUnit_Click(object sender, EventArgs e)
        {
            //UnitForm _utf = new UnitForm(this);
            //_utf.ShowDialog();
        }

        // 商品マスター
        private void ToolStripSideMenuItemItem_Click(object sender, EventArgs e)
        {
            FormItem _itf = new FormItem(this);
            _itf.ShowDialog();
        }

        // サプライヤー
        private void ToolStripSideMenuItemSupplier_Click(object sender, EventArgs e)
        {
            //SupplierForm _suf = new SupplierForm(this);
            //_suf.ShowDialog();
        }

        // 登録カウンター管理
        private void ToolStripSideMenuItemCodeCounter_Click(object sender, EventArgs e)
        {
            //CodeCounterForm _ccf = new CodeCounterForm();
            //_ccf.ShowDialog();
        }

        // Salt管理
        private void ToolStripSideMenuItemSaltManagement_Click(object sender, EventArgs e)
        {
            //SaltManagementForm _smf = new SaltManagementForm(this);
            //_smf.ShowDialog();
        }

        // コントロールパネル
        private void ToolStripSideMenuItemControlPanel_Click(object sender, EventArgs e)
        {
            //ControlPanelForm _cpf = new ControlPanelForm(this);
            //_cpf.ShowDialog();
        }

        // ログオン処理
        private void ToolStripSideMenuItemLogon_Click(object sender, EventArgs e)
        {
            Logon();
        }

        // 終了
        private void ToolStripSideMenuItemClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // 売上管理
        private void ToolStripTopMenuItemSales_Click(object sender, EventArgs e)
        {
            //SalesForm _saf = new SalesForm(this);
            //_saf.ShowDialog();
        }

        // 在庫管理
        private void ToolStripTopMenuItemStock_Click(object sender, EventArgs e)
        {
            //StockForm _skf = new StockForm(this);
            //_skf.ShowDialog();
        }

        // 発注管理
        private void ToolStripTopMenuItemOrder_Click(object sender, EventArgs e)
        {
            // OrderForm _orf = new OrderForm(this);
            //FormPlaceOrder _orf = new FormPlaceOrder(this);
            //_orf.ShowDialog();
        }

        // 仕入管理
        private void ToolStripTopMenuItemPurchase_Click(object sender, EventArgs e)
        {
            //FormPurchase _pcf = new FormPurchase(this);
            //_pcf.ShowDialog();
        }

        // 店舗マスター
        private void ToolStripTopMenuItemShop_Click(object sender, EventArgs e)
        {
            //FormShop _shf = new FormShop(this);
            //_shf.ShowDialog();
        }

        // 部署マスター
        private void ToolStripTopMenuItemDivision_Click(object sender, EventArgs e)
        {
            FormDivision _dvf = new FormDivision(this);
            _dvf.ShowDialog();
        }

        // 役職マスター
        private void ToolStripTopMenuItemPosition_Click(object sender, EventArgs e)
        {
            //FormPosition _fps = new FormPosition(this);
            //_fps.ShowDialog();
        }

        // 従業員マスター
        private void ToolStripTopMenuItemStaff_Click(object sender, EventArgs e)
        {
            //FormStaff _fst = new FormStaff(this);
            //_fst.ShowDialog();
        }

        // カテゴリーマスター
        private void ToolStripTopMenuItemCategory_Click(object sender, EventArgs e)
        {
            FormCategory _ctf = new FormCategory(this);
            _ctf.ShowDialog();
        }

        // メーカーマスター
        private void ToolStripTopMenuItemMaker_Click(object sender, EventArgs e)
        {
            FormMaker _mkf = new FormMaker(this);
            _mkf.ShowDialog();
        }

        // 消費税マスター
        private void ToolStripTopMenuItemTax_Click(object sender, EventArgs e)
        {
            FormTax _txf = new FormTax(this);
            _txf.ShowDialog();
        }

        // 受発注単位マスター
        private void ToolStripTopMenuItemUnit_Click(object sender, EventArgs e)
        {
            //UnitForm _utf = new UnitForm(this);
            //_utf.ShowDialog();
        }

        // 商品マスター
        private void ToolStripTopMenuItemItem_Click(object sender, EventArgs e)
        {
            FormItem _itf = new FormItem(this);
            _itf.ShowDialog();
        }

        // 仕入先
        private void ToolStripTopMenuItemSupplier_Click(object sender, EventArgs e)
        {
            //FormVender _vdf = new FormVender(this);
            //_vdf.ShowDialog();
        }

        // 登録カウンター管理
        private void ToolStripTopMenuItemCodeCounter_Click(object sender, EventArgs e)
        {
            //CodeCounterForm _ccf = new CodeCounterForm();
            //_ccf.ShowDialog();
        }

        // Salt管理
        private void ToolStripTopMenuItemSalt_Click(object sender, EventArgs e)
        {
            //SaltManagementForm _smf = new SaltManagementForm(this);
            //_smf.ShowDialog();
        }

        // コントロールパネル
        private void ToolStripTopMenuItemControlPanel_Click(object sender, EventArgs e)
        {
            //ControlPanelForm _cpf = new ControlPanelForm(this);
            //_cpf.ShowDialog();
        }

        // ログオン処理
        private void ToolStripTopMenuItemLogon_Click(object sender, EventArgs e)
        {
            Logon();
        }

        // 終了
        private void ToolStripTopMenuItemClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // ログオン処理
        private void ButtonLogon_Click(object sender, EventArgs e)
        {
            Logon();
        }

        // 売上管理
        private void ButtonSales_Click(object sender, EventArgs e)
        {
            //SalesForm _saf = new SalesForm(this);
            //_saf.ShowDialog();
        }

        // 在庫管理
        private void ButtonStock_Click(object sender, EventArgs e)
        {
            //StockForm _skf = new StockForm(this);
            //_skf.ShowDialog();
        }

        // 発注管理
        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            // OrderForm _orf = new OrderForm(this);
            //FormPlaceOrder _orf = new FormPlaceOrder(this);
            //_orf.ShowDialog();
        }

        // *** 内部処理 *****

        // メニューコントロール
        public void MenuControl(int level)
        {
            // 売上管理メニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemSales"].Enabled = false;
            buttonSales.Enabled = false;

            // 在庫管理メニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemStock"].Enabled = false;
            buttonStock.Enabled = false;

            // 発注管理メニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemOrder"].Enabled = false;
            buttonOrder.Enabled = false;

            // 仕入管理メニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemPurchase"].Enabled = false;

            // マスターメニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemMaster"].Enabled = false;

            // システムメニュー無効
            menuStripTopMain.Items["toolStripTopMenuItemSystem"].Enabled = false;

            // 売上管理メニュー有効
            if ((level & Constants.salesMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemSales"].Enabled = true;
                buttonSales.Enabled = true;
            }

            // 在庫管理メニュー有効
            if ((level & Constants.salesMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemStock"].Enabled = true;
                buttonStock.Enabled = true;
            }

            // 発注管理メニュー有効
            if ((level & Constants.salesMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemOrder"].Enabled = true;
                buttonOrder.Enabled = true;
            }

            // 仕入管理メニュー有効
            if ((level & Constants.salesMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemPurchase"].Enabled = true;
            }

            // マスターメニュー有効
            if ((level & Constants.masterMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemMaster"].Enabled = true;
            }

            // システムメニュー有効
            if ((level & Constants.systemMenu) != 0)
            {
                menuStripTopMain.Items["toolStripTopMenuItemSystem"].Enabled = true;
            }
        }

        // ログオン処理
        public void Logon()
        {
            if (_logonStatus == false)
            {
                LogOnForm _lf = new LogOnForm(this);
                _lf.ShowDialog();
            }
            else
            {
                // メニュー無効
                MenuControl(0);

                // メニュー表示をログオンにする
                menuStripTopMain.Items["ToolStripTopMenuItemLogon"].Image = SalesManagement.Properties.Resources.logon;
                buttonLogon.Text = "ログオン";
                _logonStatus = false;

                // 表示情報を消去
                dataLogonUser.Text = "";
                dataBelongingShop.Text = "";
                dataAccessAuth.Text = "";
                dataLogonTime.Text = "";

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _staff.M_Staff[0].StaffName,
                    Table = string.Empty,
                    Command = "Logoff",
                    Data = string.Empty,
                    Comments = string.Empty
                };
                StaticCommon.PostOperationLog(operationLog);
            }
        }

        // メニュー表示をログオフにする
        public void SetLogOff()
        {
            menuStripTopMain.Items["ToolStripTopMenuItemLogon"].Image = SalesManagement.Properties.Resources.logoff;
            buttonLogon.Text = "ログオフ";
        }

        // Saltイニシャライズ
        private void SaltInitialize()
        {
            if (_sc.GetSalt() == null)
            {
                Salt salt = new Salt()
                {
                    SaltCode = 1,
                    SaltData = _hm.GenerateSalt(),
                    Status = 0
                };
                _sc.PostSalt(salt);
            }
        }

        // CodeCounterイニシャライズ
        private void CodeCounterInitialize()
        {
            if (_cc.GetCodeCounters().Count() == 0)
            {
                for (int i = 0; i < Constants.codeCounts; i++)
                {
                    CodeCounter regCodeCounter = new CodeCounter()
                    {
                        CodeId = i,
                        Counter = 0
                    };
                    _cc.PostCodeCounter(regCodeCounter);
                }
            }
        }

        // ControlPanelイニシャライズ
        private void ControlPanelInitialize()
        {
            // カレントログディレクトリー取得
            string defaultLogDirectory = System.Environment.CurrentDirectory + Constants.defaultPath;

            if (!Directory.Exists(defaultLogDirectory))
            {
                // ログフォルダ作成メッセージ
                MessageBox.Show(Messages.logDirectoryHead + defaultLogDirectory + Messages.logDirectoryTail);
                // MessageBox.Show(_cm.GetMessage(27) + defaultLogDirectory + _cm.GetMessage(28));

                Directory.CreateDirectory(defaultLogDirectory);
            }

            // コントロール情報更新
            string fileName = defaultLogDirectory + Constants.defaultFileHead + DateTime.Now.ToShortDateString().Replace('/', '_') + Constants.defaultFileExtent;
            ControlPanel controlPanel = _cpc.GetInitialControlPanel();
            if (controlPanel == null)
            {
                controlPanel = new ControlPanel()
                {
                    FileName = fileName,
                    PageSize = Constants.pageSizeLogging,
                    LockSttRecord = 0,
                    LockEndRecord = 0,
                    Status = 0
                };
                _cpc.PostControlPanel(controlPanel);
            }
            else if (controlPanel.FileName != fileName)
            {
                controlPanel.FileName = fileName;
                _cpc.PutControlPanel(controlPanel);
            }
        }

        // フォーム初期設定
        private void FormInitialSetting()
        {
            // コントロールボックス & サイズグリップ無効
            ControlBox = false;
            SizeGripStyle = SizeGripStyle.Hide;

            // 初期表示サイズ設定
            this.Width = Constants.salesFormWidth;
            this.Height = Constants.salesFormHeight;
        }

        // ユーザー情報イニシャライズ
        private DsStaff GetInitializedDataSet()
        {
            // データ格納データセット
            DsStaff staff = new DsStaff();
            M_StaffDataTable table = staff.M_Staff;

            // パスワード一時格納
            byte[] passwordR = new byte[32];

            M_StaffRow datarow = (M_StaffRow)table.NewRow();
            datarow["StaffID"] = "";
            datarow["StaffName"] = "";
            datarow["StaffKana"] = "";
            datarow["StaffPostCode"] = "";
            datarow["StaffAddress"] = "";
            datarow["StaffAddressKana"] = "";
            datarow["StaffPhone"] = "";
            datarow["StaffSmartPhone"] = "";
            datarow["StaffMail"] = "";
            datarow["BirthDay"] = DateTime.Parse(Constants.sqlServerInitialDate);
            datarow["HireDay"] = DateTime.Parse(Constants.sqlServerInitialDate);
            datarow["ShopID"] = 0;
            datarow["DivisionID"] = 0;
            datarow["PositionID"] = 0;
            datarow["AccessAuth"] = "";
            datarow["UserID"] = "";
            datarow["Password"] = passwordR;
            datarow["DelFLG"] = 0;
            datarow["Comments"] = "";
            datarow["TimeStamp"] = DateTime.Parse(Constants.sqlServerInitialDate);
            datarow["LogData"] = "";
            table.AddM_StaffRow(datarow);
            return staff;
        }
    }
}
