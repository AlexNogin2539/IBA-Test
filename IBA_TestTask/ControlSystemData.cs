using System;
using System.Text.RegularExpressions;

namespace IBA_TestTask
{
    [Serializable]
    public class ControlSystemData
    {
        public DateTime DateTime { get; set; }

        public string VehicleIDNumber { get; set; }

        public double VehicleSpeed { get; set; }   
    }
}
