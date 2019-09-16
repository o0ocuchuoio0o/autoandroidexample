using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAutoHelper;
using System.Threading;

namespace demo
{
    public partial class Form1 : Form
    {
        #region data
        Bitmap TOP_UP_BMP;
        #endregion
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            TOP_UP_BMP = (Bitmap)Bitmap.FromFile("data//TopUp.png");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.8, 26.2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task t = new Task(()=> {
                isStop = false;
                Auto();
            }
            
            );
            t.Start();
        }
        bool isStop = false;
        void Auto()
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {
                    while (true)
                    {
                       
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // click vào webbrowser
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.8, 26.2);
                        Delay(5);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // click vào webbrowser
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 67.9, 18.3);
                        Delay(5);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // nhập vào text
                        KAutoHelper.ADBHelper.InputText(deviceID, "youtube.com");
                        Delay(2);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // ennter
                        KAutoHelper.ADBHelper.Key(deviceID,KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        Delay(2);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // so sánh ảnh và click vào ảnh
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID,true);
                        var imageclick = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen,TOP_UP_BMP);
                        if(imageclick!=null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID,imageclick.Value.X,imageclick.Value.Y);
                        }
                    }
                });
                t.Start();
            }
        }
        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isStop = true;
        }


        void SUB(string link)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {
                    string cmd = "adb shell am start -a android.intent.action.VIEW '"+ link + "'";
                    KAutoHelper.ADBHelper.ExecuteCMD(cmd);
                }
                );
                t.Start();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                SUB("https://www.youtube.com/watch?v=TleC_wPdjdk");
            }
            );
            t.Start();
        }
    }
}
