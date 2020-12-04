using System;
using System.Runtime.InteropServices;

namespace Kx.Extensions
{
    [Flags]
    public enum ThreadAccess : int
    {
        TERMINATE = (0x0001),
        SUSPEND_RESUME = (0x0002),
        GET_CONTEXT = (0x0008),
        SET_CONTEXT = (0x0010),
        SET_INFORMATION = (0x0020),
        QUERY_INFORMATION = (0x0040),
        SET_THREAD_TOKEN = (0x0080),
        IMPERSONATE = (0x0100),
        DIRECT_IMPERSONATION = (0x0200)
    }

    namespace Interop
    {
        static public class Kernel32
        {
            [DllImport("kernel32")]
            static extern public IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32")]
            static extern public IntPtr GetProcAddress(IntPtr module, string procName);

            [DllImport("kernel32")]
            static extern public int FreeLibrary(IntPtr module);

            [DllImport("kernel32", SetLastError = true)]
            static extern public IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

            [DllImport("kernel32", SetLastError = true)]
            static extern public uint SuspendThread(IntPtr hThread);

            [DllImport("kernel32", SetLastError = true)]
            static extern public int ResumeThread(IntPtr hThread);
        }
    }
}
