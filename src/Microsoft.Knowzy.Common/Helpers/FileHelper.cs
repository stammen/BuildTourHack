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

        public static void WriteTextFile(string filePath, string content)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(content);
            }
        }
    }
}
