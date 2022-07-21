using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PhoneBook
{

    class Program
    {

        static string path;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Input path of file");
                path = Console.ReadLine();
                while (!File.Exists(path))
                {
                    Console.WriteLine("Can not find file with that path,input correct path");
                    path = Console.ReadLine();
                }
                Console.WriteLine();

                DataPB PhoneBook = DataPB.CreateData(path);
                Console.WriteLine("Data from file:\n");
                foreach (PersonData person in PhoneBook.Data)
                {
                    Console.WriteLine(person);
                }
                Console.WriteLine();

                PhoneBook.Sort();
                Console.WriteLine("\nSorted data:");
                foreach (PersonData person in PhoneBook.Data)
                {
                    Console.WriteLine(person);
                }

                Console.WriteLine("Press any key to see Validations...");
                Console.ReadKey();

                Console.WriteLine("\nValidations:");
                foreach (string s in PhoneBook.NonValidLines)
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine("\nPress ESC to exit programm or any key to continue!");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
