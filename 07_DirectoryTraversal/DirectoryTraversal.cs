using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/*
 * Traverse a given directory for all files with the given extension. Search through the first level
 * of the directory only and write information about each found file in report.txt.
 * The files should be grouped by their extension. Extensions should be ordered by the count of their 
 * files (from most to least). If two extensions have equal number of files, order them by name.
 * Files under an extension should be ordered by their size.
 * report.txt should be saved on the Desktop. Ensure the desktop path is always valid, 
 * regardless of the user.
 */

class DirectoryTraversal
{
    protected class FileProperties
    {
        public string name { get; set; }
        public string extension { get; set; }
        public double length { get; set; }
    }

    protected static List<FileProperties> listFileProp = new List<FileProperties>();

    static void Main()
    {
        //get the content of "My Documents" folder
        string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        DirectoryInfo dirInfo = new DirectoryInfo(myDocuments);
        FileInfo[] filesInfo = dirInfo.GetFiles();

        //init class instances and add them to list:
        foreach (FileInfo fInfo in filesInfo)
        {
            FileProperties fProp = new FileProperties
            {
                name = fInfo.Name,
                extension = fInfo.Extension,
                length = fInfo.Length / 1024.0
            };
            listFileProp.Add(fProp);
        }

        //query files
        var queryFiles =
        from fProp in listFileProp
        orderby fProp.length
        group fProp by fProp.extension into extensionGroup
        orderby extensionGroup.Count() descending, extensionGroup.Key
        select extensionGroup;

        //write the result
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        StreamWriter sw = new StreamWriter(desktop + "/report.txt");
        foreach (var extGroup in queryFiles)
        {
            sw.WriteLine(extGroup.Key);
            foreach (var fProp in extGroup)
                sw.WriteLine("--{0} - {1:f2}kb", fProp.name, fProp.length);
        }
        sw.Close();
    }
}