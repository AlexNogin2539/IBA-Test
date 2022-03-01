using System;
using System.Text.RegularExpressions;

namespace IBA_TestTask
{
    internal class UserInputHandler
    {
        static string IDNumberPattern = @"\d{4} [A-Z]{2}-[1-7]{1}";

        public DateTime GetDate()
        {
            Console.Write("Enter the date [YYYY.MM.DD HH:MM:SS]: ");
            var date = Console.ReadLine();
            Console.WriteLine();
            var result = DateTime.TryParse(date, out var newDate);
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
            Console.Write("Enter the speed [DD,DD]: ");
            var speed = Console.ReadLine();
            Console.WriteLine();
            var result = double.TryParse(speed, out var newSpeed);
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
            Console.Write("Enter the ID number [DDDD LL-D(1-7)]: ");
            var IDNumber = Console.ReadLine();
            Console.WriteLine();
            while (!Regex.IsMatch(IDNumber, IDNumberPattern))
            {
                Console.WriteLine();
                Console.Write("Wrong format: ");
                IDNumber = Console.ReadLine();
            }
            return IDNumber;
        }
    }
}
