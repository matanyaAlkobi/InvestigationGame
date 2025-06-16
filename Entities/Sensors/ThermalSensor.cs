using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Sensors
{

    // A class that implements a thermal sensor and inherits from Sensor
    internal class ThermalSensor : Sensor
    {

        public ThermalSensor(string SensorType = "Thermal", string SensorName = "Thermal") : base(SensorType, SensorName)
        {
        }
    }
}
