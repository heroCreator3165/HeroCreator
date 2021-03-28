using System;

namespace FileHandling.DragAnDrop
{
    public delegate IntPtr HookProc(int code, IntPtr wParam, ref MSG lParam);
}