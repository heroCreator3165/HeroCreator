using System.Runtime.InteropServices;

namespace FileHandling.DragAnDrop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x, y;
        public POINT(int aX, int aY)
        {
            x = aX;
            y = aY;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}