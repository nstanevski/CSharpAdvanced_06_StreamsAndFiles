using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        using (var reader = new StreamReader("../../App.config")){
            int n = 0;
            string line;
            while((line = reader.ReadLine()) != null){
                if (n % 2 == 1)
                    Console.WriteLine(line);
                n++;
            }
        }     
    }
}