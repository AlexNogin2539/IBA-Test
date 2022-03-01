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
                var ControlSystemData = new List<ControlSystemData>();

                using (var filestream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(filestream, ControlSystemData);
                }
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

            Console.WriteLine($"{maxSpeed.DateTime} {maxSpeed.VehicleIDNumber} {maxSpeed.VehicleSpeed}\n");
        }

        public void ReadMinSpeedData(DateTime date)
        {
            var data = DeserializeData();

            var minSpeed = data.Where(p => p.DateTime.Date == date).OrderByDescending(p => p.VehicleSpeed).LastOrDefault();

            Console.WriteLine($"{minSpeed.DateTime} {minSpeed.VehicleIDNumber} {minSpeed.VehicleSpeed}\n");
        }

        public void ReadAllData()
        {
            var data = DeserializeData();

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
            using (var filestream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var controlSystemData = (List<ControlSystemData>)formatter.Deserialize(filestream);
                return controlSystemData;
            }
        }
    }
}
