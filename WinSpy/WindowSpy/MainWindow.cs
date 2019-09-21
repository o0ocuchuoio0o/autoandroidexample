using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;

namespace WindowSpy
{
    public partial class MainWindow : Form
    {
        private AboutBox aboutBox;

        public MainWindow()
        {
            InitializeComponent();
            this.finderBox1.FindWindow += new FindWindowEventHandler(finderBox1_FindWindow);
        }

        private void finderBox1_FindWindow(IntPtr hWnd)
        {
            ShowDetail(hWnd);
            GenerateGetWindowCodeManager(hWnd);
        }

        public void ShowDetail(IntPtr hWnd)
        {
            this.handleLabel.Text = hWnd.ToString("X");
            this.textLabel.Text = NativeMethods.GetWindowText(hWnd);
            this.classLabel.Text = NativeMethods.GetWindowClassName(hWnd);
            this.styleLabel.Text = NativeMethods.GetWindowLong(hWnd, NativeMethods.GWL_STYLE).ToString("X");

            Rectangle rec;
            NativeMethods.GetWindowRect(hWnd, out rec);
            this.rectangleLabel.Text = string.Format("Upper-Left: ({0}, {1}) Bottom-Right: ({2}, {3}) Size: ({4}, {5})",
                rec.X,
                rec.Y,
                rec.Width,
                rec.Height,
                rec.Width - rec.X,
                rec.Height - rec.Y);

            this.moduleFileNameLabel.Text = NativeMethods.GetModuleFileName(hWnd);

            int processId;
            int threadId = NativeMethods.GetWindowThreadProcessId(hWnd, out processId);
            this.threadIDLabel.Text = threadId.ToString("X");
            this.processIDLabel.Text = processId.ToString("X");
        }

        private void GenerateGetWindowCodeManager(IntPtr hWnd)
        {
            if (this.getWindowRadioButton.Checked)
            {
                this.getWindowHandleCodeTextBox.Text = GenerateGetWindowCode(hWnd);
            }
            else
            {
                this.getWindowHandleCodeTextBox.Text = GenerateFindWindowCode(hWnd);
            }
        }

        private string GenerateGetWindowCode(IntPtr hWnd)
        {
            string template =
                "[DllImport(\"user32.dll\", CharSet = CharSet.Auto, SetLastError = true)]" + Environment.NewLine +
                "public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);" + Environment.NewLine + Environment.NewLine +
                "[DllImport(\"user32.dll\", CharSet = CharSet.Auto, SetLastError = true)]" + Environment.NewLine +
                "public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);" + Environment.NewLine + Environment.NewLine +
                "public static IntPtr GetWindow()" + Environment.NewLine +
                "{{" + Environment.NewLine +
                "{0}" +
                "return hWnd;" + Environment.NewLine +
                "}}";

            string code = GenerateGetWindowCodeInternal(hWnd);

            return string.Format(template, code);
        }

        private string GenerateGetWindowCodeInternal(IntPtr hWnd)
        {
            StringBuilder builder = new StringBuilder();
            IntPtr hWndParent = NativeMethods.GetParent(hWnd);

            if (hWndParent != IntPtr.Zero) // Neu cua so bo me khong phai la Desktop
            {
                hWnd = NativeMethods.GetWindow(hWnd, GetWindow_Cmd.GW_HWNDPREV);

                // Duyet qua tat ca cac window cung cap.
                while (NativeMethods.IsWindow(hWnd))
                {
                    builder.Insert(0, string.Format("hWnd = GetWindow(hWnd, 2);{0}", Environment.NewLine));
                    hWnd = NativeMethods.GetWindow(hWnd, GetWindow_Cmd.GW_HWNDPREV);
                }

                // Nang len 1 cap de tien hanh duyet tiep.
                builder.Insert(0, string.Format("hWnd = GetWindow(hWnd, 5);{0}", Environment.NewLine));
                builder.Insert(0, GenerateGetWindowCodeInternal(hWndParent));
            }
            else
            {
                builder.Insert(0, string.Format("IntPtr hWnd = FindWindow(\"{0}\", null);{1}",
                    NativeMethods.GetWindowClassName(hWnd),
                    Environment.NewLine));
            }

            return builder.ToString();
        }

        private string GenerateFindWindowCode(IntPtr hWnd)
        {
            string template =
                "[DllImport(\"user32.dll\", CharSet = CharSet.Auto, SetLastError = true)]" + Environment.NewLine +
                "public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);" + Environment.NewLine + Environment.NewLine +
                "[DllImport(\"user32.dll\", CharSet = CharSet.Auto, SetLastError = true)]" + Environment.NewLine +
                "public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);" + Environment.NewLine + Environment.NewLine +
                "public static IntPtr FindWindow()" + Environment.NewLine +
                "{{" + Environment.NewLine +
                "{0}" +
                "return hWnd;" + Environment.NewLine +
                "}}";

            StringBuilder builder = new StringBuilder();
            IntPtr hWndParent = NativeMethods.GetParent(hWnd);

            while (hWndParent != IntPtr.Zero) // Neu cua so bo me khong phai la Desktop
            {
                builder.Insert(0, string.Format("hWnd = FindWindowEx(hWnd, IntPtr.Zero, \"{0}\", null);{1}",
                    NativeMethods.GetWindowClassName(hWnd),
                    Environment.NewLine));

                hWnd = hWndParent;
                hWndParent = NativeMethods.GetParent(hWnd);
            }

            builder.Insert(0, string.Format("IntPtr hWnd = FindWindow(\"{0}\", null);{1}",
                NativeMethods.GetWindowClassName(hWnd),
                Environment.NewLine));

            return string.Format(template, builder.ToString());
        }

        private void CopyFindWindowCode()
        {
            try
            {
                Clipboard.SetDataObject(this.getWindowHandleCodeTextBox.Text);
            }
            catch (Exception)
            {
                try
                {
                    Clipboard.SetDataObject(this.getWindowHandleCodeTextBox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not copy to clipboard!", "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.UserAppDataRegistry.SetValue("Bounds", this.Bounds);
            Application.UserAppDataRegistry.SetValue("WindowState", this.WindowState);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            object value;
            value = Application.UserAppDataRegistry.GetValue("Bounds");

            if (value != null)
            {
                string pattern = @"\{X=(?<X>\d+),Y=(?<Y>\d+),Width=(?<Width>\d+),Height=(?<Height>\d+)\}";
                Match match = Regex.Match((string)value, pattern);
                if (match.Success)
                {
                    this.Bounds = new Rectangle(int.Parse(match.Groups["X"].Value),
                        int.Parse(match.Groups["Y"].Value),
                        int.Parse(match.Groups["Width"].Value),
                        int.Parse(match.Groups["Height"].Value));
                }
            }

            value = Application.UserAppDataRegistry.GetValue("WindowState");
            if (value != null)
            {
                FormWindowState state = (FormWindowState)Enum.Parse(typeof(FormWindowState), (string)value);
                this.WindowState = (state == FormWindowState.Minimized) ? FormWindowState.Normal : state;
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            CopyFindWindowCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            if (this.aboutBox == null || this.aboutBox.IsDisposed)
            {
                this.aboutBox = new AboutBox();
            }
            this.aboutBox.ShowDialog();
        }
    }
}
