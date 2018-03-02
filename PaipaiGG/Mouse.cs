using System;
using System.Runtime.InteropServices;

//http://www.cnblogs.com/blackice/p/3418414.html
namespace PaipaiGG
{
    class Mouse
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        public static void MouseLefDownEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);//用屏幕取点工具可以得到坐标
            mouse_event(MouseEventFlag.RightDown| MouseEventFlag.RightUp | MouseEventFlag.Absolute, 0, 0, 0, UIntPtr.Zero);
            //mouse_event(MouseEventFlag.RightUp | MouseEventFlag.Absolute, 607, 385, 0, UIntPtr.Zero);
            //System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, 0);
            //mouse_event(MouseEventFlag.Absolute|MouseEventFlag.Move|MouseEventFlag.RightDown | MouseEventFlag.RightUp, 100 * 65536 / 1366, 100 * 65536 / 768, 0, UIntPtr.Zero);
            //mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
        }
    }
}
