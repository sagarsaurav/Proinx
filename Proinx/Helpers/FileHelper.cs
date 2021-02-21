using System;
using System.IO;

namespace Proinx.Helpers
{
    public static class FileHelper
    {
        public static bool TryReadFile(string fullPath, out FileInfo file)
        {
            file = null;
            try
            {
                FileInfo documentFile = new FileInfo(fullPath);
                if (documentFile.Exists)
                {
                    file = documentFile;
                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool WriteJsonToFile(string jsonString, string filename)
        {
            try
            {
                File.WriteAllText(filename, jsonString);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
