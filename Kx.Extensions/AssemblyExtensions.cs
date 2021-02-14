using System.IO;
using System.Reflection;
using System.Resources;

namespace Kx.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Assembly" />.
    /// </summary>
    static public class AssemblyExtensions
    {
        /// <summary>
        /// Reads the given manifest resource as a string.
        /// </summary>
        static public string GetManifestResourceString(this Assembly assembly, string resourceName)
        {
            // Get manifest resource stream
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new MissingManifestResourceException($"Resource [{resourceName}] doesn't exist.");

            // Read stream
            using (stream)
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}
