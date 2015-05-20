using System;
using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        using (FileStream source = new FileStream("../../../03_WordCount/bin/Debug/03_WordCount.exe", FileMode.Open))
        {
            using (FileStream dest = new FileStream("../../../03_WordCount/bin/Debug/03_WordCountCopy.exe", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                int len;
                while ((len = source.Read(buffer, 0, buffer.Length)) > 0)
                    dest.Write(buffer, 0, len);
            }
        }
    }
}