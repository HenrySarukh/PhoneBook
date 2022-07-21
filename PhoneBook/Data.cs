using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace PhoneBook
{
    public class DataPB
    {
        public delegate string[] Input(string path);

        public List<string> NonValidLines { get; private set; }

        public List<PersonData> Data { get; private set; }

        public void Sort()
        {
            Console.WriteLine("Please choose an ordering to sort: “Ascending” or “Descending”.");
            string sord = Console.ReadLine();
            while (sord != "Ascending" && sord != "Descending")
            {
                Console.WriteLine("Input is incorrect, input ordering again!");
                sord = Console.ReadLine();
            }

            Console.WriteLine("Please choose criteria: “Name”, “Surname” or “PhoneNumberCode”.");
            string scrit = Console.ReadLine();
            while (scrit != "Name" && scrit != "Surname" && scrit != "PhoneNumberCode")
            {
                Console.WriteLine("Input is incorrect, input criteria again!");
                scrit = Console.ReadLine();
            }

            switch (sord, scrit)
            {

                case ("Ascending", "Name"):
                    Data = Data.OrderBy(x => x.Name).ToList();
                    break;
                case ("Ascending", "Surname"):
                    Data.Sort((PersonData t1, PersonData t2) =>
                    {
                        if (t1.Surname == null)
                            return 1;
                        else if (t2.Surname == null)
                            return -1;
                        return t1.Surname.CompareTo(t2.Surname);
                    });
                    break;
                case ("Ascending", "PhoneNumberCode"):
                    Data = Data.OrderBy(x => x.PhoneNumber.Substring(0, 3)).ToList();
                    break;
                case ("Descending", "Name"):
                    Data = Data.OrderByDescending(x => x.Name).ToList();
                    break;
                case ("Descending", "Surname"):
                    Data.Sort((PersonData t1, PersonData t2) =>
                    {
                        if (t1.Surname == null)
                            return 1;
                        else if (t2.Surname == null)
                            return -1;
                        return t2.Surname.CompareTo(t1.Surname);
                    });
                    break;
                case ("Descending", "PhoneNumberCode"):
                    Data = Data.OrderByDescending(x => x.PhoneNumber.Substring(0, 3)).ToList();
                    break;
                default:
                    break;
            }

        }

        public static DataPB CreateData(string path)
        {
            List<PersonData> data = new List<PersonData>();
            List<string> nonValidLines = new List<string>();

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {

                string[] line = lines[i].Split(" ");
                if (line.Length == 3)
                    line = new string[] { line[0], null, line[1], line[2] };

                string val = DataValid(line, i + 1);

                if (val == $"line{i + 1}:")
                    data.Add(new PersonData(line[0], line[1], char.Parse(line[2]), line[3]));
                else
                    nonValidLines.Add(val);
            }

            return new DataPB(data, nonValidLines);

        }

        private static string DataValid(string[] line, int i)
        {
            string strValid = $"line{i}:";
            if (line[3].Length != 9)
            {
                strValid += "Phone number should be with 9 digits. ";
            }
            if (!(line[2] == ":" || line[2] == "-"))
            {
                strValid += "The separator should be `:` or `-`.";
            }
            return strValid;
        }

        private DataPB(List<PersonData> data, List<string> nonValidLines)
        {
            Data = data;
            NonValidLines = nonValidLines;
        }
    }
}
