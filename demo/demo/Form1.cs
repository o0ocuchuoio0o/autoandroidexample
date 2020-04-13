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
using System.Drawing.Imaging;

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
            TOP_UP_BMP = (Bitmap)Bitmap.FromFile("data//like.png");
        }
        public static Bitmap ConvertToFormat(System.Drawing.Image image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            //KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.8, 26.2);

            KAutoHelper.ADBHelper.InputText(deviceID, "youtube@gmailnguyễn.com");
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
                        //if (isStop)
                        //    return;
                        //// click vào webbrowser
                        //KAutoHelper.ADBHelper.TapByPercent(deviceID, 28.2, 8.1);
                        //Delay(5);
                        //// nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        //if (isStop)
                        //    return;
                        //// click vào webbrowser
                        //KAutoHelper.ADBHelper.TapByPercent(deviceID, 37.9, 39.1);
                        //Delay(5);
                        //// nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        //if (isStop)
                        //    return;
                        //// nhập vào text
                        //KAutoHelper.ADBHelper.InputText(deviceID, "youtube@.com");
                        //Delay(2);
                        //// nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        //if (isStop)
                        //    return;
                        //// ennter
                        //KAutoHelper.ADBHelper.Key(deviceID,KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        //Delay(2);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // so sánh ảnh và click vào ảnh
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID,true);                      
                        var imageclick = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, ConvertToFormat(TOP_UP_BMP, System.Drawing.Imaging.PixelFormat.Format24bppRgb));
                        var a= KAutoHelper.ImageScanOpenCV.Find(ConvertToFormat(screen, System.Drawing.Imaging.PixelFormat.Format24bppRgb), ConvertToFormat(TOP_UP_BMP, System.Drawing.Imaging.PixelFormat.Format24bppRgb),0.9);
                        a.Save("ba.png");
                        if (imageclick!=null) 
                        {
                           // KAutoHelper.ADBHelper.Tap(deviceID,imageclick.Value.X,imageclick.Value.Y);
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

                    #region // thực hiện fake ip
                    //KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.4, 33.4);
                    //Delay(20);
                    //try
                    //{
                    //    // thực hiện tắt quảng cáo nếu có
                    //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 7.7, 4.1);
                    //}
                    //catch { }@
                    //Delay(5);
                    //KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.9, 35.3);
                    //Delay(2);
                    //KAutoHelper.ADBHelper.TapByPercent(deviceID, 47.3, 88.3);
                    //Delay(10);
                    ////try
                    ////{
                    ////    // thực hiện tắt quảng cáo nếu có
                    ////    KAutoHelper.ADBHelper.TapByPercent(deviceID, 7.7, 4.1);
                    ////}
                    ////catch { }
                    ////Delay(5);
                    //KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                    //Delay(2);
                    //KAutoHelper.ADBHelper.Swipe(deviceID, 80, 550, 600, 550);
                    //Delay(8);
                    #endregion

                    #region // thực hiện sub
                    string cmd = "adb shell am start -a android.intent.action.VIEW '"+ link + "'";
                    KAutoHelper.ADBHelper.ExecuteCMD(cmd);
                    Delay(10);
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, true);
                    screen.Save("a.png");
                    //try {
                        
                    //    Bitmap boquangcao = (Bitmap)Bitmap.FromFile("data//boquangcao.PNG");
                    //    var imageclickboquangcao = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, boquangcao);
                    //    if (imageclickboquangcao != null)
                    //    {
                    //        KAutoHelper.ADBHelper.Tap(deviceID, imageclickboquangcao.Value.X, imageclickboquangcao.Value.Y);
                    //    }
                    //}
                    //catch { }
                    //   KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.4, 51.9);
                    Delay(3);

                    Bitmap like = (Bitmap)Bitmap.FromFile("data//ok.png");

                    var imageclicklike = KAutoHelper.ImageScanOpenCV.Find(screen, like);                                 
                    if (imageclicklike != null)
                    {
                        MessageBox.Show("OK");
                     //  KAutoHelper.ADBHelper.Tap(deviceID, imageclicklike.Value.X, imageclicklike.Value.Y);
                    }
                    else
                    {
                        MessageBox.Show("False");
                    }
                    Delay(5);
                    Bitmap sub = (Bitmap)Bitmap.FromFile("data//dangky.PNG");
                    var imageclicksub = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, sub);
                    if (imageclicksub != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, imageclicksub.Value.X, imageclicksub.Value.Y);
                    }

                    //KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.2, 61.7);
                    Delay(5);
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                    Delay(2);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 80, 550, 600, 550);
                    Delay(2);
                    #endregion
                }
                );
                t.Start();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                SUB("https://www.youtube.com/watch?v=XdCYOZaXDWk");
            }
            );
            t.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                Login("ropekf@gmail.com", "ropekf.thang2019@gmail.com", "ropekf.thang2019@gmail.com");
            }
           );
            t.Start();
        }
        void Login(string taikhoan,string matkhau,string mailkhoiphuc)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {
                    while (true)
                    {
                        if (isStop)
                            return;
                        // so sánh ảnh biểu tượng youtube
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 69.8, 19.4);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.2, 7.0);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 56.3, 59.4);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.2, 48.1);
                        Delay(20);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.8, 44.0);
                        Delay(4);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.InputText(deviceID, taikhoan);
                        // nếu có lệnh stop thì dừng toàn bộ luồng chạy
                        if (isStop)
                            return;
                        // ennter
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        Delay(8);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.4, 41.3);
                        Delay(3);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.InputText(deviceID, matkhau);
                        Delay(2);
                        if (isStop)
                            return;
                        // ennter
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        Delay(8);
                        // thực hiện kéo chuột
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1200,350,150);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 83.2, 84.7);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.2, 95.5);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.2, 95.7);
                        Delay(5);
                    }
                });
                t.Start();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
            // string deletehttp = "adb shell settings delete global http_proxy";
            //string deletehost = "adb shell settings delete global global_http_proxy_host";
            //string deleteport = "adb shell settings delete global global_http_proxy_port";
            //KAutoHelper.ADBHelper.ExecuteCMD(deletehttp);
            //KAutoHelper.ADBHelper.ExecuteCMD(deletehost);
            //KAutoHelper.ADBHelper.ExecuteCMD(deleteport);
            string proxy = "127.0.0.1:5575";
            string addproxy = "adb shell settings put global http_proxy "+proxy+"";
            KAutoHelper.ADBHelper.ExecuteCMD(addproxy);
                MessageBox.Show("ok");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                string deletehttp = "adb shell settings put global http_proxy :0";
                //string deletehost = "adb shell settings delete global global_http_proxy_host";
                //string deleteport = "adb shell settings delete global global_http_proxy_port";
                KAutoHelper.ADBHelper.ExecuteCMD(deletehttp);
                //KAutoHelper.ADBHelper.ExecuteCMD(deletehost);
                //KAutoHelper.ADBHelper.ExecuteCMD(deleteport);

                MessageBox.Show("ok");
            }
        }
    }
}
