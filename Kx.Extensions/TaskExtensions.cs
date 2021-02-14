using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Task" /> and <see cref="Task{T}" />.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Executes a task asynchronously on all elements of a sequence in parallel and returns results.
        /// </summary>
        static public async Task<IEnumerable<TResult>> ParallelSelectAsync<T, TResult>(this IEnumerable<T> source, Func<T, Task<TResult>> taskFunc)
        {
            return await Task.WhenAll(source.Select(taskFunc)).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a task asynchronously on all elements of a sequence in parallel.
        /// </summary>
        static public async Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> taskFunc)
        {
            await Task.WhenAll(source.Select(taskFunc)).ConfigureAwait(false);
        }
    }
}
