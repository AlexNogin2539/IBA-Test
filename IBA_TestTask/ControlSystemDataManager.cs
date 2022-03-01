using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IBA_TestTask
{
    public class ControlSystemDataManager
    {
        BinaryFormatter formatter = new BinaryFormatter();

        private string filePath = string.Empty;

        public ControlSystemDataManager(string path)
        {
            filePath = path;

            if (!File.Exists(filePath))
            {
                var controlSystemData = new List<ControlSystemData>();

                SerializeData(controlSystemData);
            }
        }

        public void AddData(DateTime date, double speed, string idNumber)
        {
            var data = DeserializeData();
            var newData = new ControlSystemData()
            {
                DateTime = date,
                VehicleIDNumber = idNumber,
                VehicleSpeed = speed
            };

            data.Add(newData);
            SerializeData(data);
            Console.WriteLine($"Data was added successfully!\n");
        }

        public void ReadOutspeedData(DateTime date, double speed)
        {
            var data = DeserializeData();
            var outSpeed = data.Where(d => d.DateTime.Date == date && d.VehicleSpeed > speed);

            if (outSpeed.Count() == 0)
            {
                Console.WriteLine("No search results\n");
                return;
            }

            foreach (var o in outSpeed)
            {
                Console.WriteLine($"{o.DateTime} {o.VehicleIDNumber} {o.VehicleSpeed}");
            }
            Console.WriteLine();
        }

        public void ReadMaxSpeedData (DateTime date)
        {
            var data = DeserializeData();

            var maxSpeed = data.Where(p => p.DateTime.Date == date).OrderByDescending(p => p.VehicleSpeed).FirstOrDefault();

            Console.WriteLine(maxSpeed == null ? "No search result" : $"{maxSpeed.DateTime} {maxSpeed.VehicleIDNumber} {maxSpeed.VehicleSpeed}");
        }

        public void ReadMinSpeedData(DateTime date)
        {
            var data = DeserializeData();

            var minSpeed = data.Where(p => p.DateTime.Date == date).OrderByDescending(p => p.VehicleSpeed).LastOrDefault();

            Console.WriteLine(minSpeed == null ? "" : $"{minSpeed.DateTime} {minSpeed.VehicleIDNumber} {minSpeed.VehicleSpeed}\n");
        }

        public void ReadAllData()
        {
            var data = DeserializeData();

            if (data.Count() == 0)
            {
                Console.WriteLine("No data in file\n");
                return;
            }

            foreach(var d in data)
            {
                Console.WriteLine($"{d.DateTime} {d.VehicleIDNumber} {d.VehicleSpeed}");
            }
            Console.WriteLine();
        }

        private void  SerializeData(List<ControlSystemData> controlSystemData)
        {
            using (var filestream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, controlSystemData);
            }
        }

        private List<ControlSystemData> DeserializeData()
        {
            try
            {
                using (var filestream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return (List<ControlSystemData>)formatter.Deserialize(filestream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can not deserialize file. Reason: {ex.Message}");
            }

            return new List<ControlSystemData>();
        }
    }
}
