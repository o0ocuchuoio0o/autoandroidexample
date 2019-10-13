using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class FormWin : Form
    {
        public FormWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("How Kteam - Free Education.html");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCmdText;
            strCmdText = "/C ping -t howkteam.com";
            Process.Start("CMD.exe", strCmdText);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string strCmdText;
            strCmdText = @"/C ""How Kteam - Free Education.html""";

            Process p = new Process();

            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = strCmdText;

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();

            //p.Kill();

            /*
             
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C ""How Kteam - Free Education.html""";
            process.StartInfo = startInfo;
            process.Start();
             
             */
        }

        private void FormWin_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmdCommand = "ping howkteam.com";

            Process cmd = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            cmd.StartInfo = startInfo;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            string result = cmd.StandardOutput.ReadToEnd();

            MessageBox.Show(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            //Cursor.Position = new Point(x,y);

            AutoControl.MouseClick(x, y, mouseKey);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            //var hWnd = Process.GetProcessById(12012).MainWindowHandle;
            //var hWnd = Process.GetProcessesByName("Remote Desktop Connection")[0].MainWindowHandle; // tên prosess có thể bật nhiều cửa sổ
            IntPtr hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ theo class trong texbox1 
            var pointToClick = AutoControl.GetGlobalPoint(hWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            IntPtr hWnd = IntPtr.Zero;

            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = IntPtr.Zero;
            // Tìm ra handle con mà thỏa điều kiện text và class y chang
            //childhWnd = AutoControl.FindWindowExFromParent(hWnd, null, textBox2.Text);

            //Tìm ra handle con mà thỏa text hoặc class giống
            childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);

            // lấy ra tọa độ trên màn hình của tọa độ bên trong cửa sổ
            var pointToClick = AutoControl.GetGlobalPoint(childhWnd, x, y);

            EMouseKey mouseKey = EMouseKey.LEFT;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_RIGHT;
                }
                else
                {
                    mouseKey = EMouseKey.RIGHT;
                }
            }
            else
            {
                if (checkBox2.Checked)
                {
                    mouseKey = EMouseKey.DOUBLE_LEFT;
                }
            }

            AutoControl.BringToFront(hWnd);

            AutoControl.MouseClick(pointToClick, mouseKey);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendKeyFocus(KeyCode.ENTER);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.BringToFront(hWnd);

            AutoControl.SendMultiKeysFocus(new KeyCode[] { KeyCode.CONTROL, KeyCode.KEY_V });


        }

        private void button11_Click(object sender, EventArgs e)
        {
            // áp dụng mở nhiều cửa sổ để lấy catiop ///
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.SendText(hWnd, "Cửa sổ 1");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            //Tìm ra handle con mà thỏa text hoặc class giống
            var childhWnd = AutoControl.FindHandle(hWnd, "ComboBoxEx32",null);

            AutoControl.SendText(childhWnd, "1111111");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);

            AutoControl.SendClickOnControlByHandle(childhWnd);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            var childhWnd = AutoControl.FindHandle(hWnd, textBox2.Text, textBox2.Text);

            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;

            // Phải click vào handle con. Không thể click vào handle window
            // Không phải ứng dụng nào cũng click được.
            AutoControl.SendClickOnPosition(childhWnd, x, y);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = IntPtr.Zero;
            hWnd = AutoControl.FindWindowHandle(null, textBox1.Text);

            AutoControl.SendKeyBoardPress(hWnd, VKeys.VK_RETURN);
            //AutoControl.SendKeyBoardUp(hWnd, VKeys.VK_RETURN);
            //AutoControl.SendKeyBoardDown(hWnd, VKeys.VK_RETURN);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.PNG");

            var subBitmap = ImageScanOpenCV.GetImage("template.PNG");

            var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap);
            if (resBitmap != null)
            {
                resBitmap.Save("res.PNG");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.PNG");

            var subBitmap = ImageScanOpenCV.GetImage("template.PNG");

            var resBitmap = ImageScanOpenCV.FindOutPoint((Bitmap)screen, subBitmap);
            if (resBitmap != null)
            {
                MessageBox.Show(resBitmap.ToString());
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var handle = AutoControl.FindWindowHandle("LDMultiPlayerMainFrame" == "" ? null : "LDMultiPlayerMainFrame", "" == "" ? null : "");

            #region // khởi tạo và restore file backup


            #endregion

            #region // ấn nút bắt đầu
            var sub = (Bitmap)Bitmap.FromFile("data//data.png");
            var main = (Bitmap)CaptureHelper.CaptureWindow(handle);          
            var point = ImageScanOpenCV.FindOutPoint(main, sub);
            if (point != null)
            {
             //   AutoControl.SendClickOnPosition(handle, point.Value.X, point.Value.Y);
                var pointToClick = AutoControl.GetGlobalPoint(handle, point.Value.X+7, point.Value.Y+5);
                EMouseKey mouseKey = EMouseKey.DOUBLE_LEFT;
                AutoControl.BringToFront(handle);
                AutoControl.MouseClick(pointToClick, mouseKey);
            }
            #endregion


        }
    }
}
