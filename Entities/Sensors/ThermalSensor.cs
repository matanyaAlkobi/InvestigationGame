using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Sensors
{
    internal class ThermalSensor : Sensor
    {
        public ThermalSensor(string SensorType = "SensorType", string SensorName = "AudioSensor") : base(SensorType, SensorName)
        {
        }
    }
}
