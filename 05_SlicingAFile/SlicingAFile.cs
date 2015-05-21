using System;
using System.Collections.Generic;
using System.IO;

/*
 * Write a program that takes any file and slices it to n parts. Write the following methods:
 * Slice(string sourceFile, string destinationDirectory, int parts) - 
 * slices the given source file into n parts and saves them in destinationDirectory.
 * Assemble(List<string> files, string destinationDirectory) - 
 * combines all files into one, in the order they are passed, and saves the result 
 * in destinationDirectory.
 * 
 * NOTE: Due to long to int type casting, the program does now work with files bigger than 2GB.
 */

class SlicingAFile
{
    private static void Slice(string sourceFile, string destinationDir, int numParts)
    {
        FileInfo fileInfo = new FileInfo(sourceFile);

        //calculate size of each part
        int size = (int)fileInfo.Length; //size in bytes
        int partSize = size / numParts;
        int lastPartSize = size - (numParts - 1) * partSize;

        string name = fileInfo.Name;
        string[] nameExtArr = name.Split('.');

        //for each part, read input and write output
        FileStream source = new FileStream(sourceFile, FileMode.Open);
        source.Seek(0, SeekOrigin.Current);
        for (int i = 0; i < numParts; i++)
        {
            int currentSize = (i == (numParts - 1) )? lastPartSize : partSize;
            
            byte[] buffer = new byte[currentSize];
            source.Read(buffer,0, currentSize);

            string currentFilePath = destinationDir + "Part-" + i + "." + nameExtArr[1];
            using (FileStream dest = new FileStream(currentFilePath, FileMode.Create))
                dest.Write(buffer, 0, currentSize);
            
        }
        source.Close();
    }

    private static void Assemble(List<string> files, string destinationDirectory){
        //get the extenstion of the resulting file:
        string ext = files[0].Substring(files[0].LastIndexOf('.'));
        string destinationFile = destinationDirectory + "assembled" + ext;
        using (FileStream dest = new FileStream(destinationFile, FileMode.Append, FileAccess.Write))
        {
            foreach (string inFile in files)
            {
                using (FileStream source = new FileStream(inFile, FileMode.Open))
                {
                    byte[] buffer = new byte[4096];
                    int len;
                    while ((len = source.Read(buffer, 0, buffer.Length)) > 0)
                        dest.Write(buffer, 0, len);
                }
            }
        }
    }

    static void Main()
    {
        string sourceFile = "../../../03_WordCount/bin/Debug/03_WordCount.exe";
        string destinationDir = "../../parts/";
        int numParts = 5;
        Slice(sourceFile,  destinationDir, numParts);
        List<string> files = new List<string> {  
                                "../../parts/Part-0.exe",
                                "../../parts/Part-1.exe",
                                "../../parts/Part-2.exe",
                                "../../parts/Part-3.exe",
                                "../../parts/Part-4.exe",
                             };

        Assemble(files, destinationDir);
    }
}