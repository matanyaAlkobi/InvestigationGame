using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Sensors
{
    internal class AudioSensor :  Sensor
    {

        // A class that implements a audio sensor and inherits from Sensor
        public AudioSensor(string SensorType = "Audio", string  SensorName = "Audio") :base(SensorType, SensorName)
        {
        }
    }
}
