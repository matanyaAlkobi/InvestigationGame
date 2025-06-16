using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Pepoles
{
    internal class IranianAgent
    {
        public string Rank { get; set; }

        public List<string> SensorWeakSpot { get; set; }

        public Sensor[] SensorDamage { get; set; }


        public IranianAgent(string Rank) 
        {
            this.Rank = Rank;
            //SensorWeakSpot = ConnectingSensors.SensorGenerator(this);
            SensorWeakSpot = new List<string> { "Audio", "Thermal" };
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }


        public int Active(Sensor sensor, int index)
        {
            int counter = 0;


                if (sensor.Activate(this) && SensorWeakSpot[index] == sensor.SensorName)
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
