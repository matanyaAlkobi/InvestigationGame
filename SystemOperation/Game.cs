using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;
using InvestigationGame.SetForGame;

namespace InvestigationGame.SystemOperation
{
    //A department responsible for the game's operating system
    internal class Game
    {
        // Starting the game
        public static void Start()
        {
            List<Sensor> SensorsFactory = new List<Sensor> { new AudioSensor(), new ThermalSensor() };
            IranianAgent agent = new IranianAgent("Junior");
            Console.WriteLine("Welcome  Interrogator !!!");
            bool exposed;
            do
            {
                Console.WriteLine($"The agent has {agent.SensorWeakSpot.Count} sensors");
                int index =  GameInputManager.GetValidSensorIndexFromUser(agent);
                string SensorName = GameInputManager.SetSensorName(agent);

                 exposed = TryExposeAgentWithSensor(SensorName, index, agent);

            }
            while (!exposed);
        }


        // /// <summary>
        /// Activates a sensor on the agent at a given index and checks if the agent is fully exposed.
        /// </summary>
        /// <param name="SensorName">The name of the sensor to activate.</param>
        /// <param name="index">The index in the agent's sensor array to activate.</param>
        /// <param name="agent">The IranianAgent on which the sensor is activated.</param>
        /// <returns>True if the agent has been fully exposed; otherwise, false.</returns>
        private static bool TryExposeAgentWithSensor(string SensorName,int index, IranianAgent agent)
        {
            bool exposed = false;
            int counter = 0;
            switch (SensorName)
            {
                case "Audio":
                    counter = agent.Active(new AudioSensor(), index);
                    Console.WriteLine($"You hit in {counter} / {agent.SensorWeakSpot.Count}");
                    break;

                case "Thermal":
                    counter = agent.Active(new ThermalSensor(), index);
                    Console.WriteLine($"You hit in {counter} / {agent.SensorWeakSpot.Count}");
                    break;
            }
            if (counter == agent.SensorWeakSpot.Count)
            {
                Console.WriteLine("The agent was exposed.");
                exposed = true;
            }
            return exposed;
        }
    }
}
