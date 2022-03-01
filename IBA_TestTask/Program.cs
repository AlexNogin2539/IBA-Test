using System;
using System.Collections.Generic;

namespace IBA_TestTask
{
    public class Program
    {
        

        public static int DataAccessCheck()
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            DateTime finishTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 00);
            return DateTime.Compare(startTime, DateTime.Now) + DateTime.Compare(finishTime, DateTime.Now); 
        }

        static void Main(string[] args)
        { 
            var userInputHandler = new UserInputHandler();

            string path = AppConfigManager.FileName;
            var controlSystemDataManager = new ControlSystemDataManager(path);

            bool looping = true;
            while (looping)
            {
                if (!(DataAccessCheck() == 0))
                {
                    Console.WriteLine("Service is not avilable!");
                    return;
                }

                Console.WriteLine($"Please, choose an option:\n1. Add ControlSystemData\n2. Read ControlSystemData (OutspeedData)\n3. Read ControlSystemData (MaxMinSpeedData)\n4. Read all ControlSystemData\n5. Exit the application");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        controlSystemDataManager.AddData(userInputHandler.GetDate(), userInputHandler.GetSpeed(), userInputHandler.GetIDNumber());
                        break;
                    case "2":
                        controlSystemDataManager.ReadOutspeedData(userInputHandler.GetDate(), userInputHandler.GetSpeed());
                        break;
                    case "3":
                        DateTime date = userInputHandler.GetDate();
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
