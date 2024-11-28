using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    public class FileControls
    {
        public static string ReadFile(string path,Encoding encoding=null)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            if (encoding == null )
            {
                encoding = Encoding.Default;
            }
            string result = "";
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                if (fileStream.Length > 0)
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    result = encoding.GetString(array);
                }
            }
            return result;
        }
    }
}
