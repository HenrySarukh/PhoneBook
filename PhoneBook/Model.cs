using System;

namespace PhoneBook
{
    public class PersonData
    {
        private string name;
        private string surname;
        private char separator;
        private string phoneNumber;

        public string Name
        {
            get => name;

            set
            {
                if (value == null)
                {
                    throw new Exception("Empty field of Name");
                }
                name = value;
            }
        }

        public string Surname
        {
            get => surname;

            set
            {
                surname = value;
            }
        }

        public char Separator
        {
            get => separator;

            set
            {
                if (!(value == '-' || value == ':'))
                {
                    throw new Exception("Seperator must be  `:` or  `-`");
                }
                separator = value;
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;

            set
            {
                if (value.Length != 9)
                {
                    throw new Exception("Phone number should be 9 digits.");
                }
                else if (!value.StartsWith("0") && IsDigit(value))
                {
                    throw new Exception("Incorrect format of phone number");
                }
                phoneNumber = value;
            }
        }



        public PersonData(string name, string surname, char seperator, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Separator = seperator;
            PhoneNumber = phoneNumber;
        }

        private bool IsDigit(string s)
        {
            foreach (char c in s)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            if (Surname == null || Surname == "")
                return $"{Name} {Separator} {phoneNumber}";
            else
                return $"{Name} {Surname} {Separator} {phoneNumber}";
        }

    }
}
