using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.SystemOperation
{
    internal class Game
    {
        public  static void Start()
        {
            List<Sensor> SensorsFactory = new List<Sensor> { new AudioSensor(), new ThermalSensor() };

            Console.WriteLine("Welcome  Interrogator !!!");



        }
    }
}
