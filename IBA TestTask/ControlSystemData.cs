using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IBA_TestTask
{
    [Serializable]
    public class ControlSystemData
    {
        static string IDNumberPattern = @"\d{4} [A-Z]{2}-[1-7]{1}";

        private string _vehicleIDNumber = string.Empty;

        public ControlSystemData (DateTime datetime, string vehicleIDNumber, double vehicleSpeed)
        {
            DateTime = datetime;
            _vehicleIDNumber = vehicleIDNumber;
            VehicleSpeed = vehicleSpeed;
        }

        public DateTime DateTime { get; set; }

        public string VehicleIDNumber
        {
            get { return _vehicleIDNumber; }
            set
            {
                while (!Regex.IsMatch(value, IDNumberPattern))
                {
                    Console.WriteLine();
                    Console.Write("Please, enter in format [DDDD LL-D]: ");
                    value = Console.ReadLine();
                }
                _vehicleIDNumber = value;
            }
        }

        public double VehicleSpeed { get; set; }

        public static DateTime GetDate()
        {
            Console.Write("Enter the date: ");
            string date = Console.ReadLine();
            Console.WriteLine();
            DateTime newDate;
            bool result = DateTime.TryParse(date, out newDate);
            while (!result)
            {
                Console.WriteLine("Wrong format: ");
                date = Console.ReadLine();
                Console.WriteLine();
                result = DateTime.TryParse(date, out newDate);
            }
            return newDate;
        }

        public static double GetSpeed()
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
    }
}
