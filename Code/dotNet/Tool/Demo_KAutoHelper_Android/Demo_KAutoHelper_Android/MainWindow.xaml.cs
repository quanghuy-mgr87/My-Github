using System;
using System.Collections.Generic;
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

namespace Demo_KAutoHelper_Android
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 74.1, 31.3);

            Thread.Sleep(TimeSpan.FromSeconds(2));

            KAutoHelper.ADBHelper.TapByPercent(deviceID, 52.4, 29.2);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
