using System;
using System.Runtime.InteropServices;

namespace Kx.Extensions
{

    [Flags]
    public enum KeyModifier
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        WinKey = 8
    }

    namespace Interop
    {
        static public class User32
        {
            [DllImport("user32")]
            static extern public IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32", SetLastError = true)]
            static extern public bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

            [DllImport("user32", SetLastError = true)]
            static extern public bool UnregisterHotKey(IntPtr hWnd, int id);
        }
    }
}
