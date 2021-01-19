using CsvHelper;
using System;
using System.Globalization;
using System.IO;

namespace Nuget
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Path.Combine(AppContext.BaseDirectory, "employees.csv");
            using (var streamReader = new StreamReader(file))
            {
                var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

                while (csvReader.Read())
                {
                    string name = csvReader.GetField<string>(0);
                    string salary = csvReader.GetField<string>(1);
                    string department = csvReader.GetField<string>(2);
                    
                    Console.WriteLine($"{name}\t{salary}\t{department}");
                }
            }
        }
    }
}
