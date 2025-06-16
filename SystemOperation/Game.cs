using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.SystemOperation
{
    internal class Game
    {
        public  static void Start()
        {
            List<Sensor> SensorsFactory = new List<Sensor> { new AudioSensor(), new ThermalSensor() };
            IranianAgent agent = new IranianAgent("Junior");

            Console.WriteLine("Welcome  Interrogator !!!");

            do
            {
                Console.WriteLine($"The agent has {agent.SensorWeakSpot.Count} sensors");
                Console.WriteLine("choose index");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("enter a sensor  name");
                string sensorname = Console.ReadLine();

                int counter = 0;
                switch (sensorname)
                {
                    case "Audio":
                        AudioSensor aud = new AudioSensor();
                        counter = agent.Active(aud, index);
                        Console.WriteLine($"You hit in {counter} / {agent.SensorWeakSpot.Count}");
                        break;

                    case "Thermal":
                        ThermalSensor th = new ThermalSensor();
                        counter = agent.Active(th, index);
                        Console.WriteLine($"You hit in {counter} / {agent.SensorWeakSpot.Count}");
                        break;
                }
                if (counter == agent.SensorWeakSpot.Count)
                {
                    Console.WriteLine("The agent was exposed.");
                    break;
                }
            }
            while (true);
            

        }
    }
}
