using System;
using System.Diagnostics;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Process"/>
    /// </summary>
    static public class ProcessExtensions
    {
        /// <summary>
        /// Suspend the thread.
        /// </summary>
        static public void Suspend(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = Interop.Kernel32.OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                    break;
                Interop.Kernel32.SuspendThread(pOpenThread);
            }
        }

        /// <summary>
        /// Resume the thread.
        /// </summary>
        static public void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = Interop.Kernel32.OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                    break;
                Interop.Kernel32.ResumeThread(pOpenThread);
            }
        }
    }
}
