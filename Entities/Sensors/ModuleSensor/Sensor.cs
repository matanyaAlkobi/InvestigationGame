using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.Entities.Sensors
{
    // Sensors' father class
    internal abstract class Sensor
    {
        public string SensorType { get; set; }
        public string SensorName { get; set; }

        public  Sensor(string SensorType, string SensorName)
        {
            this.SensorType = SensorType;
            this.SensorName = SensorName;
        }


        // Enabling the sensor checks whether it can be enabled.
        public virtual bool Activate(BaseAgent agent,int index)
        {
            Console.WriteLine($"Sensor {SensorName} is Active ");
            if (agent.SensorWeakSpot.Contains(SensorName))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"sensor name: {SensorName}";
        }
    }
}
