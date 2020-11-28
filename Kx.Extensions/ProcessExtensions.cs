using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Kx.Extensions
{
    /// <summary>
    /// Extension for the Process class
    /// </summary>
    static public class ProcessExtensions
    {
        /// <summary>
        /// Thread Access flags.
        /// </summary>
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

        /// <summary>
        /// Opens an existing thread object.
        /// </summary>
        /// <param name="dwDesiredAccess">The access to the thread object.</param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwThreadId">The identifier of the thread to be opened.</param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified thread. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern private IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        /// <summary>
        /// Suspends the specified thread.
        /// </summary>
        /// <param name="hThread">A handle to the thread that is to be suspended.</param>
        /// <returns>If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1. To get extended error information, use the GetLastError function.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern private uint SuspendThread(IntPtr hThread);

        /// <summary>
        /// Decrements a thread's suspend count. When the suspend count is decremented to zero, the execution of the thread is resumed.
        /// </summary>
        /// <param name="hThread">A handle to the thread to be restarted. This handle must have the THREAD_SUSPEND_RESUME access right.</param>
        /// <returns>If the function succeeds, the return value is the thread's previous suspend count. If the function fails, the return value is (DWORD) -1. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern private int ResumeThread(IntPtr hThread);

        /// <summary>
        /// Suspend the thread.
        /// </summary>
        static public void Suspend(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                    break;
                SuspendThread(pOpenThread);
            }
        }

        /// <summary>
        /// Resume the thread.
        /// </summary>
        static public void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                    break;
                ResumeThread(pOpenThread);
            }
        }
    }
}
