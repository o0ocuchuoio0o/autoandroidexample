using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Embed
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        //or
        IntPtr MenuHandle; //Defined outside of RemoveBorders, which is defined below this line, to show that MenuHandle is not local variable.
        
        private void button1_Click(object sender, EventArgs e)
        {
         
                
                 Process p = Process.Start(@"C:\Users\Workstation Z400\Desktop\LDPlayer.lnk");
                 Thread.Sleep(2000);
                 p.WaitForInputIdle();
                 
                 SetParent(p.MainWindowHandle, this.panel1.Handle);
                 SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                 MoveWindow(p.MainWindowHandle, 0, -35, 367 , 654, true);
            //p1\
            /*
            Process p1 = Process.Start(@"C:\Users\Workstation Z400\Desktop\LDPlayer-1.lnk");
            Thread.Sleep(2000);
            p1.WaitForInputIdle();
            
            SetParent(p1.MainWindowHandle, this.panel2.Handle);
            SetWindowLong(p1.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
            MoveWindow(p1.MainWindowHandle, 0, -35, 367, 654, true);

            //p2
            Process p2 = Process.Start(@"C:\Users\Workstation Z400\Desktop\LDPlayer-2.lnk");
            Thread.Sleep(2000);
            p2.WaitForInputIdle();

            SetParent(p2.MainWindowHandle, this.panel3.Handle);
            SetWindowLong(p2.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
            MoveWindow(p2.MainWindowHandle, 0, -35, 367, 654, true);
            */

        }
        ///////////////////////////
        

            /// <summary>
            /// Track if the application has been created
            /// </summary>
            bool created = false;

            /// <summary>
            /// Handle to the application Window
            /// </summary>
            IntPtr appWin;

            /// <summary>
            /// The name of the exe to launch
            /// </summary>
            private string exeName = "";

            /// <summary>
            /// Get/Set if we draw the tick marks
            /// </summary>
            [
            Category("Data"),
            Description("Name of the executable to launch"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
            ]
            public string ExeName
            {
                get
                {
                    return exeName;
                }
                set
                {
                    exeName = value;
                }
            }


            /// <summary>
            /// Constructor
            /// </summary>
            


            [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
                 CharSet = CharSet.Unicode, ExactSpelling = true,
                 CallingConvention = CallingConvention.StdCall)]
            private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", SetLastError = true)]
            

            
            private static extern long GetWindowLong(IntPtr hwnd, int nIndex);


        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        const int WS_EX_TOPMOST = 0x00000008;
        const int GWL_EXSTYLE = -20;

        [DllImport("user32.dll", SetLastError = true)]
            private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

            [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
            private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

            private const int SWP_NOOWNERZORDER = 0x200;
            private const int SWP_NOREDRAW = 0x8;
            private const int SWP_NOZORDER = 0x4;
            private const int SWP_SHOWWINDOW = 0x0040;
            private const int WS_EX_MDICHILD = 0x40;
            private const int SWP_FRAMECHANGED = 0x20;
            private const int SWP_NOACTIVATE = 0x10;
            private const int SWP_ASYNCWINDOWPOS = 0x4000;
            private const int SWP_NOMOVE = 0x2;
            private const int SWP_NOSIZE = 0x1;
            private const int GWL_STYLE = (-16);
            private const int WS_VISIBLE = 0x10000000;
            private const int WM_CLOSE = 0x10;
            private const int WS_CHILD = 0x40000000;

            /// <summary>
            /// Force redraw of control when size changes
            /// </summary>
            /// <param name="e">Not used</param>
            protected override void OnSizeChanged(EventArgs e)
            {
                this.Invalidate();
                base.OnSizeChanged(e);
            }


        /// <summary>
        /// Creeate control when visibility changes
        /// </summary>
        /// <param name="e">Not used</param>

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
            {
                // Stop the application
                if (appWin != IntPtr.Zero)
                {

                    // Post a colse message
                    PostMessage(appWin, WM_CLOSE, 0, 0);

                    // Delay for it to get the message
                    System.Threading.Thread.Sleep(1000);

                    // Clear internal handle
                    appWin = IntPtr.Zero;

                }

                base.OnHandleDestroyed(e);
            }


            /// <summary>
            /// Update display of the executable
            /// </summary>
            /// <param name="e">Not used</param>
            protected override void OnResize(EventArgs e)
            {
                if (this.appWin != IntPtr.Zero)
                {
                    MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
                }
                base.OnResize(e);
            }


        



    }
}
