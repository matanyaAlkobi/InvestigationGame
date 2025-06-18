using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.SystemOperation
{
    internal class AgentExposureAnalyzer
    {
        static PulseSensor pulsesensor = new PulseSensor();



        // /// <summary>
        /// Activates a sensor on the agent at a given index and checks if the agent is fully exposed.
        /// </summary>
        /// <param name="SensorName">The name of the sensor to activate.</param>
        /// <param name="index">The index in the agent's sensor array to activate.</param>
        /// <param name="agent">The IranianAgent on which the sensor is activated.</param>
        /// <returns>True if the agent has been fully exposed; otherwise, false.</returns>
        public static bool TryExposeAgentWithSensor(string SensorName, int index, FootSoldier agent)
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

                case "Pulse":
                    if (pulsesensor.IsBroken)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("Sensor broke. Creating a new one...");
                        Console.ResetColor();
                        pulsesensor = new PulseSensor(); // Creates a new sensor
                    }
                    counter = agent.Active(pulsesensor, index);
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
