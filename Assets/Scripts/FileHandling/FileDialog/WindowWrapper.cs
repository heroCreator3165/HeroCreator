using System;
using System.Windows.Forms;

namespace FileHandling.FileDialog
{
    public class WindowWrapper : IWin32Window {
        private IntPtr _hwnd;
        public WindowWrapper(IntPtr handle) { _hwnd = handle; }
        public IntPtr Handle { get { return _hwnd; } }
    }
}