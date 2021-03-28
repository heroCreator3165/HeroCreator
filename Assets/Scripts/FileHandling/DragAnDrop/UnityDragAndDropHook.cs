using System.Collections.Generic;

namespace FileHandling.DragAnDrop
{
    public static class UnityDragAndDropHook
    {
        public delegate void DroppedFilesEvent(List<string> aPathNames, POINT aDropPoint);
        public static event DroppedFilesEvent OnDroppedFiles;

#if UNITY_STANDALONE_WIN && !UNITY_EDITOR_WIN

        private static uint threadId;
        private static IntPtr mainWindow = IntPtr.Zero;
        private static IntPtr m_Hook;
        private static string m_ClassName = "UnityWndClass";

        // attribute required for IL2CPP, also has to be a static method
        [AOT.MonoPInvokeCallback(typeof(EnumThreadDelegate))]
        private static bool EnumCallback(IntPtr W, IntPtr _)
        {
            if (Window.IsWindowVisible(W) && (mainWindow == IntPtr.Zero || (m_ClassName != null && Window.GetClassName(W) == m_ClassName)))
            {
                mainWindow = W;
            }
            return true;
        }

        public static void InstallHook()
        {
            threadId = WinAPI.GetCurrentThreadId();
            if (threadId > 0)
                Window.EnumThreadWindows(threadId, EnumCallback, IntPtr.Zero);

            var hModule = WinAPI.GetModuleHandle(null);
            m_Hook = WinAPI.SetWindowsHookEx(HookType.WH_GETMESSAGE, Callback, hModule, threadId);
            // Allow dragging of files onto the main window. generates the WM_DROPFILES message
            WinAPI.DragAcceptFiles(mainWindow, true);
        }
        public static void UninstallHook()
        {
            WinAPI.UnhookWindowsHookEx(m_Hook);
            WinAPI.DragAcceptFiles(mainWindow, false);
            m_Hook = IntPtr.Zero;
        }

        // attribute required for IL2CPP, also has to be a static method
        [AOT.MonoPInvokeCallback(typeof(HookProc))]
        private static IntPtr Callback(int code, IntPtr wParam, ref MSG lParam)
        {
            if (code == 0 && lParam.message == WM.DROPFILES)
            {
                POINT pos;
                WinAPI.DragQueryPoint(lParam.wParam, out pos);

                // 0xFFFFFFFF as index makes the method return the number of files
                uint n = WinAPI.DragQueryFile(lParam.wParam, 0xFFFFFFFF, null, 0);
                var sb = new System.Text.StringBuilder(1024);

                List<string> result = new List<string>();
                for (uint i = 0; i < n; i++)
                {
                    int len = (int)WinAPI.DragQueryFile(lParam.wParam, i, sb, 1024);
                    result.Add(sb.ToString(0, len));
                    sb.Length = 0;
                }
                WinAPI.DragFinish(lParam.wParam);
                if (OnDroppedFiles != null)
                    OnDroppedFiles(result, pos);
            }
            return WinAPI.CallNextHookEx(m_Hook, code, wParam, ref lParam);
        }
#else
        public static void InstallHook()
        {
        }
        public static void UninstallHook()
        {
        }
#endif
    }
}