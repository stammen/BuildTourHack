using System.IO;

namespace Microsoft.Knowzy.Common.Helpers
{
    public static class FileHelper
    {
        public static string ReadTextFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
