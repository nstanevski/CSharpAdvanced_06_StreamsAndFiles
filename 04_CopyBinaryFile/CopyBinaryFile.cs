using System;
using System.IO;

/*
 * Write a program that copies the contents of a binary file (e.g. image, video, etc.) 
 * to another using FileStream. 
 * You are not allowed to use the File class or similar helper classes.
 */

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