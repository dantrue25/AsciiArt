using System;
using System.Collections.Generic;
using System.Linq;
namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Count())
            {
                case 0:
                    Console.WriteLine("Missing arguments. Must give a filename to a picture. Optionally, give a filename for output to a text file.");
                    Console.WriteLine("Press Enter key to quit...");
                    Console.ReadLine();
                    return;
                case 1:
                    try
                    {
                        ImageToAscii.DrawToConsole(args[0]);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        ImageToAscii.DrawToFile(args[0], args[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect arguments.");
                    break;
            }

            Console.WriteLine("Press Enter key to quit...");
            Console.ReadLine();
        }
    }
}
