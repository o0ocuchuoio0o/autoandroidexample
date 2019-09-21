using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace WindowSpy
{
    /// <summary>
    /// For use with ChildWindowFromPointEx 
    /// </summary>
    [Flags]
    public enum WindowFromPointFlags : uint
    {
        /// <summary>
        /// Does not skip any child windows
        /// </summary>
        CWP_ALL = 0x0000,
        /// <summary>
        /// Skips invisible child windows
        /// </summary>
        CWP_SKIPINVISIBLE = 0x0001,
        /// <summary>
        /// Skips disabled child windows
        /// </summary>
        CWP_SKIPDISABLED = 0x0002,
        /// <summary>
        /// Skips transparent child windows
        /// </summary>
        CWP_SKIPTRANSPARENT = 0x0004
    }

    /// <summary>
    ///     Specifies a raster-operation code. These codes define how the color data for the
    ///     source rectangle is to be combined with the color data for the destination
    ///     rectangle to achieve the final color.
    /// </summary>
    public enum TernaryRasterOperations : uint
    {
        /// <summary>dest = source</summary>
        SRCCOPY = 0x00CC0020,
        /// <summary>dest = source OR dest</summary>
        SRCPAINT = 0x00EE0086,
        /// <summary>dest = source AND dest</summary>
        SRCAND = 0x008800C6,
        /// <summary>dest = source XOR dest</summary>
        SRCINVERT = 0x00660046,
        /// <summary>dest = source AND (NOT dest)</summary>
        SRCERASE = 0x00440328,
        /// <summary>dest = (NOT source)</summary>
        NOTSRCCOPY = 0x00330008,
        /// <summary>dest = (NOT src) AND (NOT dest)</summary>
        NOTSRCERASE = 0x001100A6,
        /// <summary>dest = (source AND pattern)</summary>
        MERGECOPY = 0x00C000CA,
        /// <summary>dest = (NOT source) OR dest</summary>
        MERGEPAINT = 0x00BB0226,
        /// <summary>dest = pattern</summary>
        PATCOPY = 0x00F00021,
        /// <summary>dest = DPSnoo</summary>
        PATPAINT = 0x00FB0A09,
        /// <summary>dest = pattern XOR dest</summary>
        PATINVERT = 0x005A0049,
        /// <summary>dest = (NOT dest)</summary>
        DSTINVERT = 0x00550009,
        /// <summary>dest = BLACK</summary>
        BLACKNESS = 0x00000042,
        /// <summary>dest = WHITE</summary>
        WHITENESS = 0x00FF0062,
        /// <summary>
        /// Capture window as seen on screen.  This includes layered windows 
        /// such as WPF windows with AllowsTransparency="true"
        /// </summary>
        CAPTUREBLT = 0x40000000
    }

    public enum GetWindow_Cmd : uint
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6
    }

    public enum GetAncestor_Flags
    {
        GetParent = 1,
        GetRoot = 2,
        GetRootOwner = 3
    }

    public static class NativeMethods
    {
        public const int GWL_EXSTYLE = -20;
        public const int GWL_STYLE = -16;
        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_ID = -12;
        public const int GWL_USERDATA = -21;
        public const int DWL_DLGPROC = 4;
        public const int DWL_MSGRESULT = 0;
        public const int DWL_USER = 8;

        // Window Styles 
        const UInt32 WS_OVERLAPPED = 0;
        const UInt32 WS_POPUP = 0x80000000;
        const UInt32 WS_CHILD = 0x40000000;
        const UInt32 WS_MINIMIZE = 0x20000000;
        const UInt32 WS_VISIBLE = 0x10000000;
        const UInt32 WS_DISABLED = 0x8000000;
        const UInt32 WS_CLIPSIBLINGS = 0x4000000;
        const UInt32 WS_CLIPCHILDREN = 0x2000000;
        const UInt32 WS_MAXIMIZE = 0x1000000;
        const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
        const UInt32 WS_BORDER = 0x800000;
        const UInt32 WS_DLGFRAME = 0x400000;
        const UInt32 WS_VSCROLL = 0x200000;
        const UInt32 WS_HSCROLL = 0x100000;
        const UInt32 WS_SYSMENU = 0x80000;
        const UInt32 WS_THICKFRAME = 0x40000;
        const UInt32 WS_GROUP = 0x20000;
        const UInt32 WS_TABSTOP = 0x10000;
        const UInt32 WS_MINIMIZEBOX = 0x20000;
        const UInt32 WS_MAXIMIZEBOX = 0x10000;
        const UInt32 WS_TILED = WS_OVERLAPPED;
        const UInt32 WS_ICONIC = WS_MINIMIZE;
        const UInt32 WS_SIZEBOX = WS_THICKFRAME;

        // Extended Window Styles 
        const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
        const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
        const UInt32 WS_EX_TOPMOST = 0x0008;
        const UInt32 WS_EX_ACCEPTFILES = 0x0010;
        const UInt32 WS_EX_TRANSPARENT = 0x0020;
        const UInt32 WS_EX_MDICHILD = 0x0040;
        const UInt32 WS_EX_TOOLWINDOW = 0x0080;
        const UInt32 WS_EX_WINDOWEDGE = 0x0100;
        const UInt32 WS_EX_CLIENTEDGE = 0x0200;
        const UInt32 WS_EX_CONTEXTHELP = 0x0400;
        const UInt32 WS_EX_RIGHT = 0x1000;
        const UInt32 WS_EX_LEFT = 0x0000;
        const UInt32 WS_EX_RTLREADING = 0x2000;
        const UInt32 WS_EX_LTRREADING = 0x0000;
        const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
        const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
        const UInt32 WS_EX_CONTROLPARENT = 0x10000;
        const UInt32 WS_EX_STATICEDGE = 0x20000;
        const UInt32 WS_EX_APPWINDOW = 0x40000;
        const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        const UInt32 WS_EX_LAYERED = 0x00080000;
        const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
        const UInt32 WS_EX_COMPOSITED = 0x02000000;
        const UInt32 WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr WindowFromPhysicalPoint(Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr WindowFromPoint(Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hWndParent, Point pt, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr RealChildWindowFromPoint(IntPtr hWndParent, Point ptParentClientCoords);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int ScreenToClient(IntPtr hWnd, out Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

        public static IntPtr GetWindowUnderCursor()
        {
            Point ptCursor;
            if (!GetCursorPos(out ptCursor))
            {
                return IntPtr.Zero;
            }
            IntPtr hWnd = WindowFromPoint(ptCursor);

            // Them phan tim kiem cac Widnow nam phia trong.
            hChildFound = IntPtr.Zero;
            SeekDumpWindow(hWnd, ptCursor);

            if (hChildFound != IntPtr.Zero)
            {
                hWnd = hChildFound;
            }
            return hWnd;
        }

        static IntPtr GetInnerWindow(IntPtr hWnd, Point point)
        {
            IntPtr hWndOut = IntPtr.Zero;

            Rectangle hWndCurrentRec;
            GetWindowRect(hWnd, out hWndCurrentRec);

            IntPtr hWndChild = GetWindow(hWnd, GetWindow_Cmd.GW_CHILD);
            Rectangle hWndChildRec;

            if (IsWindow(hWndChild))
            {
                while (IsWindow(hWndChild))
                {
                    GetWindowRect(hWndChild, out hWndChildRec);

                    if (hWndChildRec.Left < point.X && hWndChildRec.Top < point.Y &&
                        hWndChildRec.Width > point.X && hWndChildRec.Height > point.Y)
                    {
                        if (hWndChildRec.Width - hWndChildRec.Left < hWndCurrentRec.Width - hWndCurrentRec.Left &&
                            hWndChildRec.Height - hWndChildRec.Top < hWndCurrentRec.Height - hWndCurrentRec.Top)
                        {
                            hWndCurrentRec = hWndChildRec;
                            hWndOut = hWndChild;
                        }
                    }
                    hWndChild = GetWindow(hWndChild, GetWindow_Cmd.GW_HWNDNEXT);
                    if (GetParent(hWndChild) == (IntPtr)0) break;
                }
            }
            return hWndOut;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public static string GetWindowClassName(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(128);
            GetClassName(hWnd, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);
        public static string GetWindowText(IntPtr hWnd)
        {
            StringBuilder buffer = new StringBuilder(128);
            GetWindowText(hWnd, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetModuleFileName(int hModule, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpFilename, int nSize);
        public static string GetModuleFileName(IntPtr hWnd)
        {
            int instance = GetWindowLong(hWnd, NativeMethods.GWL_HINSTANCE);
            StringBuilder builder = new StringBuilder(128);
            GetModuleFileName(instance, builder, builder.Capacity);
            return builder.ToString();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool OffsetRect(ref Rectangle lprc, int dx, int dy);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetWindow(IntPtr hwnd, GetWindow_Cmd wFlag);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestor_Flags gaFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindow(IntPtr hWnd);

        #region DumpWindow
        static IntPtr hChildFound = IntPtr.Zero;
        static long dx, dy, _dx, _dy;

        //---------------------------------------------------------------------------
        static void DumpIntoChildWindow(IntPtr hWnd, Point point)
        {
            if (!IsWindow(hWnd)) return;
            Rectangle wndRect;
            GetWindowRect(hWnd, out wndRect);
            if ((wndRect.Left < point.X) && (point.X < wndRect.Width) &&
               (wndRect.Top < point.Y) && (point.Y < wndRect.Height)
               )
            {
                if ((IsWindow(hWnd)) && (hWnd != IntPtr.Zero))
                {
                    dx = wndRect.Width - wndRect.Left;
                    dy = wndRect.Height - wndRect.Top;
                    if ((_dx > dx) && (_dy > dy))
                    {
                        hChildFound = hWnd;
                        _dx = dx;
                        _dy = dy;
                    }
                    DumpChildWindowLocal(hWnd, point);
                }
            }
        }

        //---------------------------------------------------------------------------
        static void DumpChildWindowLocal(IntPtr hWnd, Point point)
        {
            // check if there is at least one child
            IntPtr hChild;
            hChild = GetWindow(hWnd, GetWindow_Cmd.GW_CHILD);
            Rectangle wndRect;
            GetWindowRect(hChild, out wndRect);
            if (IsWindow(hChild))
            {
                while (IsWindow(hChild))
                {
                    GetWindowRect(hChild, out wndRect);
                    if ((wndRect.Left < point.X) && (point.X < wndRect.Width) &&
                       (wndRect.Top < point.Y) && (point.Y < wndRect.Height))
                    {
                        DumpIntoChildWindow(hChild, point);
                    }
                    hChild = GetWindow(hChild, GetWindow_Cmd.GW_HWNDNEXT);
                    if (GetParent(hChild) == IntPtr.Zero) break;
                }
            }
        }

        //---------------------------------------------------------------------------
        static void DumpIntoParentWindow(IntPtr hWnd, Point point)
        {
            if (!IsWindow(hWnd)) return;
            Rectangle wndRect;
            GetWindowRect(hWnd, out wndRect);
            if ((wndRect.Left < point.X) && (point.X < wndRect.Width) &&
               (wndRect.Top < point.Y) && (point.Y < wndRect.Height)
               )
            {
                if ((IsWindow(hWnd)) && (hWnd != IntPtr.Zero))
                {
                    dx = wndRect.Width - wndRect.Left;
                    dy = wndRect.Height - wndRect.Top;
                    if ((_dx > dx) && (_dy > dy))
                    {
                        hChildFound = hWnd;
                        _dx = dx;
                        _dy = dy;
                    }
                    DumpChildWindowLocal(hWnd, point);
                }
            }
        }

        //---------------------------------------------------------------------------
        static void DumpParentWindowLocal(IntPtr hWnd, Point point)
        {
            IntPtr hParent;
            // retrieve its parent
            hParent = GetParent(hWnd);
            // check if it and its parent is a window dialog frame
            if (((GetWindowLong(hWnd, GWL_STYLE) & WS_DLGFRAME) == WS_DLGFRAME) &&
               ((GetWindowLong(hParent, GWL_STYLE) & WS_DLGFRAME) == WS_DLGFRAME))
            {
                return;
            }
            if ((IsWindow(hParent)) && (hParent != IntPtr.Zero))
            {
                DumpChildWindowLocal(hParent, point);
                DumpParentWindowLocal(hParent, point);
            }
        }

        //---------------------------------------------------------------------------
        static void SeekDumpWindow(IntPtr hWnd, Point point)
        {
            _dx = 99999;
            _dy = 99999;
            DumpChildWindowLocal(hWnd, point);
            DumpParentWindowLocal(hWnd, point);
        }
        //---------------------------------------------------------------------------
        #endregion
    }
}
