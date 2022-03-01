using System;
using System.Collections.Generic;

namespace IBA_TestTask
{
    public class Program
    {
        public static DateTime GetDate()
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

        public static int DataAccessCheck()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);
            DateTime finishTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 00, 00);
            return DateTime.Compare(startTime, DateTime.Now) + DateTime.Compare(finishTime, DateTime.Now); 
        }

        static void Main(string[] args)
        {
            
            string path = "ControlSystemData.dat";

            var controlSystemDataManager = new ControlSystemDataManager(path);

            var dataSample = new List<ControlSystemData>
            {
                new ControlSystemData(new DateTime(2019, 12, 20, 14, 31, 25), "1234 PP - 7", 65.5),
                new ControlSystemData(new DateTime(2019, 12, 20, 14, 32, 25), "1234 PP - 7", 67.5),
                new ControlSystemData(new DateTime(2019, 12, 20, 14, 33, 25), "1235 PP - 7", 61.0),
                new ControlSystemData(new DateTime(2019, 12, 20, 14, 31, 25), "1236 PP - 7", 59.5),
                new ControlSystemData(new DateTime(2020, 12, 20, 14, 31, 25), "1234 PP - 7", 68.5),
            };

            if (!(DataAccessCheck() == 0))
            {
                Console.WriteLine("Service is not avilable!");     
                Environment.Exit(0);
            }

            bool looping = true;
            while (looping)
            {
                Console.WriteLine($"Please, choose an option:\n1. Add ControlSystemData\n2. Read ControlSystemData (OutspeedData)\n3. Read ControlSystemData (MaxMinSpeedData)\n4. Read all ControlSystemData\n5. Exit the application");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        controlSystemDataManager.AddData(dataSample);
                        Console.WriteLine("Data was added!");
                        break;
                    case "2":
                        controlSystemDataManager.ReadOutspeedData(GetDate(), GetSpeed());
                        break;
                    case "3":
                        DateTime date = GetDate();
                        controlSystemDataManager.ReadMaxSpeedData(date);
                        controlSystemDataManager.ReadMinSpeedData(date);
                        break;
                    case "4":
                        controlSystemDataManager.ReadAllData();
                        break;
                    case "5":
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Please, choose the number between 1 and 4");
                        break;
                }
            }

        }
    }
}
