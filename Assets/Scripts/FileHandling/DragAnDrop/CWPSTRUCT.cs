/* * * * *
 * This is a collection of Win API helpers. Mainly dealing with window message hooks
 * and file drag&drop support for Windows standalone Unity applications.
 * 
 * 2019.11.28 - Changed the "UnityDragAndDropHook" class to a static class. This
 *   has been done for IL2CPP support. IL2CPP can not marshall instance method
 *   callbacks passed to native code. So the callbacks must be static methods.
 *   Therefore all fields involved also need to be static.
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2018 Markus Göbel (Bunny83)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 * * * * */

using System;
using System.Runtime.InteropServices;

namespace FileHandling.DragAnDrop
{
    // windows messages

    // WH_CALLWNDPROC
    [StructLayout(LayoutKind.Sequential)]
    public struct CWPSTRUCT
    {
        public IntPtr lParam;
        public IntPtr wParam;
        public WM message;
        public IntPtr hwnd;
    }

    //WH_GETMESSAGE

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN

#endif
}
