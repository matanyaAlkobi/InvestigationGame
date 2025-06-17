using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Pepoles
{

    // Creating an Iranian agent
    internal class FootSoldier
    {
        public string Rank { get; set; }

        public List<string> SensorWeakSpot { get; set; }

        public Sensor[] SensorDamage { get; set; }


        public FootSoldier(string rank = "FootSoldier") 
        {
            this.Rank = rank;

            SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
            //SensorWeakSpot = new List<string> { "Audio", "Thermal" };
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }

        // Activating the sensor and checking whether the agent has any weaknesses
        public virtual int Active(Sensor sensor, int index)
        {
            int counter = 0;

            if (sensor.Activate(this,index) &&  SensorWeakSpot[index] == sensor.SensorName)
            {
                    SensorDamage[index] = sensor;
            }
                for (int i = 0; i < SensorDamage.Length; i++)
                {
                    if (SensorDamage[i] != null)
                        ++counter;
                }

            return counter;
        }



    }
}
