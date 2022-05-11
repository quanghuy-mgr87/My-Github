using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KAutoHelper;

namespace WPF_TEST_FIRST_TOOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region data
        Bitmap TOP_UP_BMP;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            TOP_UP_BMP = (Bitmap)Bitmap.FromFile("Data//TopUp.png");
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            Task task = new Task(() =>
            {
                isStop = false;
                Auto();
            });
            task.Start();
        }

        bool isStop = false;
        void Auto()
        {
            //Lấy ra danh sách devices gồm các id của các devices đó để dùng
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            //Chạy từng device một để thực hiện các kịch bản bên trong
            devices.ForEach(x =>
            {
                //Tạo 1 luồng xử lý riêng biệt cho các device này
                Task task = new Task(() =>
                {
                    //lặp kịch bản
                    while (true)
                    {
                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        //Click vào vị trí mong muốn
                        KAutoHelper.ADBHelper.TapByPercent(x, 10.3, 31.3);
                        //Tạm dừng 3s sau đó mới thực hiện công việc sau
                        Delay(3);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(x, 26.2, 5.7);
                        Delay(2);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.InputText(x, "https://www.howkteam.vn/");
                        Delay(2);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Key(x, ADBKeyEvent.KEYCODE_ENTER);
                        Delay(3);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(x, 51.2, 65.8);
                        Delay(4);

                        for (int i = 0; i < 2; i++)
                        {
                            //Nếu có lệnh stop thì dừng
                            if (isStop)
                                return;
                            KAutoHelper.ADBHelper.Swipe(x, 130, 1300, 130, 200);
                            Delay(2);
                        }

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(x);
                        var topUpPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, TOP_UP_BMP);
                        if (topUpPoint != null)
                        {
                            //Ép kiểu nguyên bởi hàm Tap này chỉ nhận số nguyên, chẳng may ra số thực thì ép kiểu nguyên bấm cho chuẩn
                            KAutoHelper.ADBHelper.Tap(x, (int)topUpPoint.Value.X, (int)topUpPoint.Value.Y);
                        }
                        Delay(3);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Key(x, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                        Delay(2);

                        //Nếu có lệnh stop thì dừng
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(x, 88.5, 7.1);
                        Delay(2);
                    }
                });
                task.Start();
            });
        }
        void Delay(int x)
        {
            while (x > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                x--;
                if (isStop)
                    break;
            }
        }

        private void ClickStop(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }
    }
}
