using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Sensors
{
    internal abstract class Sensor
    {
        public string SensorType { get; set; }
        public string SensorName { get; set; }

        public  Sensor(string SensorType, string SensorName)
        {
            this.SensorType = SensorType;
            this.SensorName = SensorName;
        }
    }
}
