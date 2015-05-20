using System;
using System.IO;

/*
 Write a program that reads a text file and inserts line numbers in front of each of its lines. 
 *The result should be written to another text file. Use StreamReader in combination with StreamWriter.
 */
class LineNumbers
{
    static void Main()
    {
        using (var reader = new StreamReader("../../App.config"))
        {
            string line;
            int n = 1;
            using (var writer = new StreamWriter("../../AppNumbered.config"))
            {
                while ((line = reader.ReadLine()) != null)
                    writer.WriteLine("{0} {1}", n++, line);
            }  
        } 
    }
}