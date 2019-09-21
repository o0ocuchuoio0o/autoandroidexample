using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace WindowSpy
{
    public class FinderBox : Panel
    {
        private IntPtr hWndCurrent;
        private Icon finder_normal;
        private Icon finder_work;
        private int flag;
        private bool isFinderWork;
        private Cursor currentCursor;
        private Cursor finderWorkCursor;
        public event EventHandler StartFindWindow;
        public event FindWindowEventHandler FindWindow;
        public event EventHandler FinishFindWindow;

        public FinderBox()
        {
            this.flag = 0;
            this.finder_normal = Properties.Resources.finder_normal;
            this.finder_work = Properties.Resources.finder_work;
            this.hWndCurrent = IntPtr.Zero;
            MemoryStream cursorStream = new MemoryStream(Properties.Resources.finder);
            this.finderWorkCursor = new Cursor(cursorStream);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Icon icon = (this.flag == 0) ? this.finder_normal : this.finder_work;
            e.Graphics.DrawIcon(icon, 0, 0);
        }

        public void ShowNomal()
        {
            this.flag = 0;
            base.Invalidate();
        }

        public void ShowWork()
        {
            this.flag = 1;
            base.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.isFinderWork = true;
            this.ShowWork();
            this.currentCursor = Cursor.Current;
            Cursor.Current = this.finderWorkCursor;
            if (this.StartFindWindow != null && this.StartFindWindow.GetInvocationList().Length > 0)
            {
                this.StartFindWindow(this, null);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.isFinderWork)
            {
                IntPtr hWnd = NativeMethods.GetWindowUnderCursor();

                if (hWnd != this.hWndCurrent)
                {
                    if (NativeMethods.GetAncestor(hWnd, GetAncestor_Flags.GetRoot) != NativeMethods.GetAncestor(this.Handle, GetAncestor_Flags.GetRoot))
                    {
                        DrawRevFrame(this.hWndCurrent);
                        this.hWndCurrent = hWnd;
                        DrawRevFrame(hWnd);

                        // Raise event.
                        if (this.FindWindow != null && this.FindWindow.GetInvocationList().Length > 0)
                        {
                            this.FindWindow(hWnd);
                        }
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.isFinderWork)
            {
                this.ShowNomal();
                Cursor.Current = this.currentCursor;
                this.isFinderWork = false;

                if (this.hWndCurrent != IntPtr.Zero)
                {
                    DrawRevFrame(this.hWndCurrent);
                    this.hWndCurrent = IntPtr.Zero;
                }

                // Raise event.
                if (this.FinishFindWindow != null && this.FinishFindWindow.GetInvocationList().Length > 0)
                {
                    this.FinishFindWindow(this, null);
                }
            }
        }

        private void DrawRevFrame(IntPtr hWnd)
        {
            IntPtr hdc = NativeMethods.GetWindowDC(hWnd);
            Rectangle rect;
            NativeMethods.GetWindowRect(hWnd, out rect);
            NativeMethods.OffsetRect(ref rect, -rect.Left, -rect.Top);

            int frameWidth = 3;
            NativeMethods.PatBlt(hdc, rect.Left, rect.Top, rect.Right - rect.Left, frameWidth, TernaryRasterOperations.DSTINVERT);
            NativeMethods.PatBlt(hdc, rect.Left, rect.Bottom - frameWidth, frameWidth, -(rect.Bottom - rect.Top - 2 * frameWidth), TernaryRasterOperations.DSTINVERT);
            NativeMethods.PatBlt(hdc, rect.Right - frameWidth, rect.Top + frameWidth, frameWidth, rect.Bottom - rect.Top - 2 * frameWidth, TernaryRasterOperations.DSTINVERT);
            NativeMethods.PatBlt(hdc, rect.Right, rect.Bottom - frameWidth, -(rect.Right - rect.Left), frameWidth, TernaryRasterOperations.DSTINVERT);
        }
    }
}
