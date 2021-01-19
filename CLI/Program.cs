using System;
using System.IO;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Missing parameters.");
                return;
            }

            string fileName = args[0];

            using (var writer = File.CreateText(fileName))
            {
                writer.WriteLine("Hello world");
            }

            Console.WriteLine($"Successfully created file: {fileName}");
        }
    }
}
