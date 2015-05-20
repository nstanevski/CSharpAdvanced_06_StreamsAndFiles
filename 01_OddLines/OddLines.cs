using System;
using System.IO;

/*
 * Write a program that reads a text file and prints on the console its odd lines. 
 * Line numbers starts from 0. Use StreamReader.
 */

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