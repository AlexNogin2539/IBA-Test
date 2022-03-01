using System;
using System.Text.RegularExpressions;

namespace IBA_TestTask
{
    internal class UserInputHandler
    {
        static string IDNumberPattern = @"\d{4} [A-Z]{2}-[1-7]{1}";

        public DateTime GetDate()
        {
            Console.Write("Enter the date: ");
            string date = Console.ReadLine();
            Console.WriteLine();
            bool result = DateTime.TryParse(date, out var newDate);
            while (!result)
            {
                Console.Write("Wrong format: ");
                date = Console.ReadLine();
                Console.WriteLine();
                result = DateTime.TryParse(date, out newDate);
            }
            return newDate;
        }

        public double GetSpeed()
        {
            Console.Write("Enter the speed: ");
            string speed = Console.ReadLine();
            Console.WriteLine();
            double newSpeed;
            bool result = double.TryParse(speed, out newSpeed);
            while (!result)
            {
                Console.Write("Wrong format: ");
                speed = Console.ReadLine();
                Console.WriteLine();
                result = double.TryParse(speed, out newSpeed);
            }
            return newSpeed;
        }

        public string GetIDNumber()
        {
            Console.Write("Enter the ID number: ");
            string IDNumber = Console.ReadLine();
            Console.WriteLine();
            while (!Regex.IsMatch(IDNumber, IDNumberPattern))
            {
                Console.WriteLine();
                Console.Write("Please, enter in format [DDDD LL-D]: ");
                IDNumber = Console.ReadLine();
            }
            return IDNumber;
        }
    }
}
